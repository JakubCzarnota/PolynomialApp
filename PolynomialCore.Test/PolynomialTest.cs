using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore.Test
{
    public class PolynomialTest
    {
        const int DECIMAL_PRECISION = 5;

        private static double Round(double x)
        {
            var number = Math.Pow(10, DECIMAL_PRECISION);

            return Math.Round(x * number) / number;
        }

        [InlineData("3x+1", new double[] { 1, 3 }, 1)]
        [InlineData("5x^2+2x-10", new double[] { -10, 2, 5 }, 2)]
        [InlineData("13x^3-20x+0", new double[] { 0, -20, 0, 13 }, 3)]
        [Theory]
        public void Constructor_ForGivenPolynomialFormlua_ReturnsCorrectPolynomial(string polynomialFormula, double[] coefficients, int degree)
        {

            // arrange

            var poly = new Polynomial(polynomialFormula);

            // act

            // assert

            poly.Degree.Should().Be(degree);
            poly.Coefficients.Should().BeEquivalentTo(coefficients);

        }

        [InlineData("3x+1", 2, 7)]
        [InlineData("5x^2+2x-10", 1.5, 4.25)]
        [InlineData("13x^3-20x+0", 0.5, -8.375)]
        [Theory]
        public void Y_ForGivenPolynomialFormlua_ReturnsCorrectValue(string polynomialFormula, double x, double y)
        {
            // arrange 

            var poly = new Polynomial(polynomialFormula);

            // act

            var result = Round(poly.Y(x));

            // assert

            result.Should().Be(Round(y));
        }

        public static IEnumerable<object[]> GetSampleDataForFindRootsTest()
        {
            yield return new object[] { "2x+10", new List<Root>() 
            {
                new Root(-5, 1)
            }};
            yield return new object[] { "x^2-2x+1", new List<Root>() 
            {
                new Root(1, 2)
            }};
            yield return new object[] { "x^2+1", new List<Root>() {}};
            yield return new object[] { "x^3+4x^2-3x-18", new List<Root>() 
            {
                new Root(-3, 2),
                new Root(2, 1)
            }};
            yield return new object[] { "x^4-x^3+2x-1", new List<Root>() 
            {
                new Root(-1.1537213755418, 1),
                new Root(0.5356873867919, 1)
            }};
        }

        [MemberData(nameof(GetSampleDataForFindRootsTest))]
        [Theory]
        public void FindRoots_ForGivenPolynomialFormlua_ReturnsCorrectRoots(string polynomialFormula, List<Root> roots)
        {
            // arrange 

            var number = Math.Pow(10, DECIMAL_PRECISION);

            foreach (var root in roots)
            {
                root.Value = Round(root.Value);
            }

            var poly = new Polynomial(polynomialFormula);

            // act

            poly.FindRoots();

            poly.Roots.Should().NotBeNull();

            foreach (var root in poly.Roots!)
            {
                root.Value = Round(root.Value);
            }

            // assert

            poly.Roots.Should().BeEquivalentTo(roots);

        }

        public static IEnumerable<object[]> GetSampleDataForFindExtremeValuesTest()
        {
            yield return new object[] { "2x+10", new List<Point>() };
            yield return new object[] { "x^2-2x-1", new List<Point>()
            {
                new Point(1, -2)
            }};
            yield return new object[] { "x^3-1", new List<Point>() };
            yield return new object[] { "x^3+4x^2-3x-18", new List<Point>()
            {
                new Point(-3, 0),
                new Point(0.3333333333333, -18.5185185185185)
            }};
        }

        [MemberData(nameof(GetSampleDataForFindExtremeValuesTest))]
        [Theory]
        public void FindExtremeValues_ForGivenPolynomialFormlua_FindsExtremeValues(string polynomialFormula, List<Point> extremeValues)
        {
            // arrange

            var poly = new Polynomial(polynomialFormula);

            foreach (var extremeValue in extremeValues)
            {
                extremeValue.X = Round(extremeValue.X);
                extremeValue.Y = Round(extremeValue.Y);
            }

            // act

            poly.FindExtremeValues();

            poly.ExtremeValues.Should().NotBeNull();

            foreach (var extremeValue in poly.ExtremeValues!)
            {
                extremeValue.X = Round(extremeValue.X);
                extremeValue.Y = Round(extremeValue.Y);
            }

            // assert

            poly.ExtremeValues.Should().BeEquivalentTo(extremeValues);
        }

        public static IEnumerable<object[]> GetSampleDataForFindMonotinicityTest()
        {
            yield return new object[] { "2x+10", (new List<Interval>()
            {
                new Interval(null, null, true)
            },
            new List<Interval>()
            )};

            yield return new object[] { "x^2-2x-1", (new List<Interval>()
            {
                new Interval(1, null, true)
            },
            new List<Interval>()
            {
                new Interval(null, 1, true)
            })};

            yield return new object[] { "x^3-1", (new List<Interval>()
            {
                new Interval(null, null, true)
            },
            new List<Interval>()
            )};

            yield return new object[] { "x^3+4x^2-3x-18", (new List<Interval>()
            {
                new Interval(null, -3, true),
                new Interval(0.3333333333333, null, true)
            },
            new List<Interval>()
            {
                new Interval(-3, 0.3333333333333, true)
            })};
        }

        [MemberData(nameof(GetSampleDataForFindMonotinicityTest))]
        [Theory]
        public void FindMonotinicity_ForGivenPolynomialFormlua_FindsCorrectMonotinicity(string polynomialFormula, (List<Interval> increasing, List<Interval> decreasing) monotinicity)
        {
            // arrange

            var poly = new Polynomial(polynomialFormula);

            foreach (var increasing in monotinicity.increasing)
            {
                increasing.A = increasing.A == null ? null : Round((double)increasing.A);
                increasing.B = increasing.B == null ? null : Round((double)increasing.B);
            }

            foreach (var decreasing in monotinicity.decreasing)
            {
                decreasing.A = decreasing.A == null ? null : Round((double)decreasing.A);
                decreasing.B = decreasing.B == null ? null : Round((double)decreasing.B);
            }

            // act

            poly.FindMonotinicity();

            poly.Monotinicity.Should().NotBeNull();

            foreach (var increasing in poly.Monotinicity!.Value.increasing)
            {
                increasing.A = increasing.A == null ? null : Round((double)increasing.A);
                increasing.B = increasing.B == null ? null : Round((double)increasing.B);
            }

            foreach (var decreasing in poly.Monotinicity!.Value.decreasing)
            {
                decreasing.A = decreasing.A == null ? null : Round((double)decreasing.A);
                decreasing.B = decreasing.B == null ? null : Round((double)decreasing.B);
            }

            // assert

            poly.Monotinicity.Should().BeEquivalentTo(monotinicity);
        }

    }
}
