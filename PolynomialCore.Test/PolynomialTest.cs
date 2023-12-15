using System;
using System.Collections.Generic;
using System.Linq;
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

        [InlineData("2x+10", new double[] { -5 }, new int[] { 1 })]
        [InlineData("x^2-2x+1", new double[] { 1 }, new int[] { 2 })]
        [InlineData("x^2+1", new double[0], new int[0])]
        [InlineData("x^3+4x^2-3x-18", new double[] { -3, 2 }, new int[] { 2, 1 })]
        [InlineData("x^4-x^3+2x-1", new double[] { -1.1537213755418, 0.5356873867919 }, new int[] { 1, 1 })]
        [Theory]
        public void FindRoots_ForGivenPolynomialFormlua_ReturnsCorrectRoots(string polynomialFormula, double[] rootsValue, int[] rootsMultiplicity)
        {
            // arrange 

            var number = Math.Pow(10, DECIMAL_PRECISION);

            var poly = new Polynomial(polynomialFormula);


            // act

            poly.FindRoots();

            // assert

            poly.Roots.Should().NotBeNull();
            poly.Roots!.Count.Should().Be(rootsValue.Length);

            for (int i = 0; i < poly.Roots.Count; i++)
            {
                var root = poly.Roots![i];

                var rootValue = rootsValue[i];

                var rootMultiplicity = rootsMultiplicity[i];

                Round(root.Value).Should().Be(Round(rootValue));
                root.Multiplicity.Should().Be(rootMultiplicity);
            }


        }

        [InlineData("2x+10", new double[0], new double[0])]
        [InlineData("x^2-2x-1", new double[] { 1 }, new double[] { -2 })]
        [InlineData("x^3-1", new double[0], new double[0])]
        [InlineData("x^3+4x^2-3x-18", new double[] { -3, 0.33333333333333 }, new double[] { 0, -18.5185185185185 })]
        [Theory]
        public void FindExtremeValues_ForGivenPolynomialFormlua_FindsCorrectExtremeValues(string polynomialFormula, double[] extremeValuesX, double[] extremeValuesY)
        {
            // arrange

            var poly = new Polynomial(polynomialFormula);

            var extremeValues = new List<Point>();

            for (int i = 0; i < extremeValuesX.Length; i++)
            {
                extremeValues.Add(new Point(Round(extremeValuesX[i]), Round(extremeValuesY[i])));
            }

            // act

            poly.FindExtremeValues();

            for (int i = 0; i < poly.ExtremeValues!.Count; i++)
            {
                poly.ExtremeValues![i].X = Round(poly.ExtremeValues![i].X);
                poly.ExtremeValues![i].Y = Round(poly.ExtremeValues![i].Y);
            }

            // assert

            poly.ExtremeValues.Should().BeEquivalentTo(extremeValues);
        }
    }
}
