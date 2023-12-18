using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore.Test
{
    public class PolynomialTest
    {
        const int DECIMAL_PRECISION = 5;

        private static double? Round(double? x)
        {
            if (x == null)
                return null;

            return Round((double)x);

        }

        private static double Round(double x)
        {

            var number = Math.Pow(10, DECIMAL_PRECISION);

            return Math.Round((double)(x * number)) / number;
        }

        [InlineData("25", new double[] { 25 }, 0)]
        [InlineData("x", new double[] { 1, 0 }, 1)]
        [InlineData("3x+1", new double[] { 1, 3 }, 1)]
        [InlineData("5x^2+2x-10", new double[] { -10, 2, 5 }, 2)]
        [InlineData("13x^3-20x+0", new double[] { 0, -20, 0, 13 }, 3)]
        [Theory]
        public void Constructor_ForGivenPolynomialFormula_ReturnsCorrectPolynomial(string polynomialFormula, double[] coefficients, int degree)
        {

            // arrange

            var poly = new Polynomial(polynomialFormula);

            // act

            // assert

            poly.Degree.Should().Be(degree);
            poly.Coefficients.Should().BeEquivalentTo(coefficients);

        }

        public static IEnumerable<object[]> GetSampleDataForYTests()
        {
            yield return new object[] { new Polynomial("35"), -2, 35 };
            yield return new object[] { new Polynomial("-35"), 0, -35 };
            yield return new object[] { new Polynomial("3x+1"), 2, 7 };
            yield return new object[] { new Polynomial("5x^2+2x-10"), 1.5, 4.25 };
            yield return new object[] { new Polynomial("13x^3-20x+0"), 0.5, -8.375 };
        }

        [MemberData(nameof(GetSampleDataForYTests))]
        [Theory]
        public void Y_ForGivenXValue_ReturnsCorrectYValue(Polynomial polynomial, double x, double y)
        {
            // arrange 

            // act

            var result = Round(polynomial.Y(x));

            // assert

            result.Should().Be(Round(y));
        }

        public static IEnumerable<object[]> GetSampleDataForFindRootsTests()
        {
            yield return new object[] { new Polynomial("35"), new List<Root>() { } };
            
            yield return new object[] { new Polynomial("2x+10"),
                new List<Root>()
                {
                    new Root(-5, 1)
                }
            };

            yield return new object[] { new Polynomial("x^2-2x+1"),
                new List<Root>()
                {
                    new Root(1, 2)
                }
            };

            yield return new object[] { new Polynomial("x^2+1"), new List<Root>() { } };

            yield return new object[] { new Polynomial("x^3+4x^2-3x-18"),
                new List<Root>()
                {
                    new Root(-3, 2),
                    new Root(2, 1)
                }
            };

            yield return new object[] { new Polynomial("x^4-x^3+2x-1"),
                new List<Root>()
                {
                    new Root(-1.1537213755418, 1),
                    new Root(0.5356873867919, 1)
                }
            };
        }

        [MemberData(nameof(GetSampleDataForFindRootsTests))]
        [Theory]
        public void FindRoots_FindsCorrectRoots(Polynomial polynomial, List<Root> roots)
        {
            // arrange 

            foreach (var root in roots)
            {
                root.Value = Round(root.Value);
            }

            // act

            polynomial.FindRoots();

            polynomial.Roots.Should().NotBeNull();

            foreach (var root in polynomial.Roots!)
            {
                root.Value = Round(root.Value);
            }

            // assert

            polynomial.Roots.Should().BeEquivalentTo(roots);

        }

        public static IEnumerable<object[]> GetSampleDataForFindExtremeValuesTests()
        {
            yield return new object[] { new Polynomial("35"), new List<Point>() };

            yield return new object[] { new Polynomial("2x+10"), new List<Point>() };

            yield return new object[] { new Polynomial("x^2-2x-1"),
                new List<Point>()
                {
                    new Point(1, -2)
                }
            };

            yield return new object[] { new Polynomial("x^3-1"), new List<Point>() };

            yield return new object[] { new Polynomial("x^3+4x^2-3x-18"),
                new List<Point>()
                {
                    new Point(-3, 0),
                    new Point(0.3333333333333, -18.5185185185185)
                }
            };
        }

        [MemberData(nameof(GetSampleDataForFindExtremeValuesTests))]
        [Theory]
        public void FindExtremeValues_FindsCorrectExtremeValues(Polynomial polynomial, List<Point> extremeValues)
        {
            // arrange

            foreach (var extremeValue in extremeValues)
            {
                extremeValue.X = Round(extremeValue.X);
                extremeValue.Y = Round(extremeValue.Y);
            }

            // act

            polynomial.FindExtremeValues();

            polynomial.ExtremeValues.Should().NotBeNull();

            foreach (var extremeValue in polynomial.ExtremeValues!)
            {
                extremeValue.X = Round(extremeValue.X);
                extremeValue.Y = Round(extremeValue.Y);
            }

            // assert

            polynomial.ExtremeValues.Should().BeEquivalentTo(extremeValues);
        }

        public static IEnumerable<object[]> GetSampleDataForFindMonotinicityTests()
        {
            yield return new object[] { new Polynomial("35"), (new List<Interval>(), new List<Interval>()) };

            yield return new object[] { new Polynomial("2x+10"),
                (new List<Interval>()
                {
                    new Interval(Interval.Infinity, Interval.Infinity, true)
                },
                new List<Interval>())
            };

            yield return new object[] { new Polynomial("x^2-2x-1"),
                (new List<Interval>()
                {
                    new Interval(1, Interval.Infinity, true)
                },
                new List<Interval>()
                {
                    new Interval(Interval.Infinity, 1, true)
                })
            };

            yield return new object[] { new Polynomial("x^3-1"),
                (new List<Interval>()
                {
                    new Interval(Interval.Infinity, Interval.Infinity, true)
                },
                new List<Interval>())
            };

            yield return new object[] { new Polynomial("x^3+4x^2-3x-18"),
                (new List<Interval>()
                {
                    new Interval(Interval.Infinity, -3, true),
                    new Interval(0.3333333333333, Interval.Infinity, true)
                },
                new List<Interval>()
                {
                    new Interval(-3, 0.3333333333333, true)
                })
            };
        }

        [MemberData(nameof(GetSampleDataForFindMonotinicityTests))]
        [Theory]
        public void FindMonotinicityFindsCorrectMonotinicity(Polynomial polynomial, (List<Interval> increasing, List<Interval> decreasing) monotinicity)
        {
            // arrange

            foreach (var increasing in monotinicity.increasing)
            {
                increasing.A = Round(increasing.A);
                increasing.B = Round(increasing.B);
            }

            foreach (var decreasing in monotinicity.decreasing)
            {
                decreasing.A = Round(decreasing.A);
                decreasing.B = Round(decreasing.B);
            }

            // act

            polynomial.FindMonotinicity();

            polynomial.Monotinicity.Should().NotBeNull();

            foreach (var increasing in polynomial.Monotinicity!.Value.increasing)
            {
                increasing.A = Round(increasing.A);
                increasing.B = Round(increasing.B);
            }

            foreach (var decreasing in polynomial.Monotinicity!.Value.decreasing)
            {
                decreasing.A = Round(decreasing.A);
                decreasing.B = Round(decreasing.B);
            }

            // assert

            polynomial.Monotinicity.Should().BeEquivalentTo(monotinicity);
        }

        public static IEnumerable<object[]> GetSampleDataForFindPositiveAndNegativeValuesTests()
        {
            yield return new object[] { new Polynomial("35"),
                new List<Interval>()
                {
                    new Interval(Interval.Infinity, Interval.Infinity)
                },
                new List<Interval>()
            };         
            
            yield return new object[] { new Polynomial("-35"),
                new List<Interval>(),
                new List<Interval>()
                {
                    new Interval(Interval.Infinity, Interval.Infinity)
                }
            };

            yield return new object[] { new Polynomial("2x+10"),
                new List<Interval>()
                {
                    new Interval(-5, Interval.Infinity)
                },
                new List<Interval>()
                {
                    new Interval(Interval.Infinity, -5)
                }
            };

            yield return new object[] { new Polynomial("x^2-2x-1"),
                new List<Interval>()
                {
                    new Interval(Interval.Infinity, -0.4142135623731),
                    new Interval(2.4142135623731, Interval.Infinity)
                },
                new List<Interval>()
                {
                    new Interval(-0.4142135623731, 2.4142135623731)
                }
            };

            yield return new object[] { new Polynomial("x^3-1"),
                new List<Interval>()
                {
                    new Interval(1, Interval.Infinity)
                },
                new List<Interval>()
                {
                    new Interval(Interval.Infinity, 1)
                }
            };

            yield return new object[] { new Polynomial("x^3+4x^2-3x-18"),
            new List<Interval>()
                {
                    new Interval(2, Interval.Infinity)
                },
                new List<Interval>()
                {
                    new Interval(Interval.Infinity, -3),
                    new Interval(-3, 2)
                }
            };
        }

        [MemberData(nameof(GetSampleDataForFindPositiveAndNegativeValuesTests))]
        [Theory]
        public void FindPositiveAndNegativeValues_FindsCorrectPositiveAndNegativeValues(Polynomial polynomial, List<Interval> positiveValues, List<Interval> negativeValues)
        {
            // arrange

            foreach (var interval in positiveValues)
            {
                interval.A = Round(interval.A);
                interval.B = Round(interval.B);
            }

            foreach (var interval in negativeValues)
            {
                interval.A = Round(interval.A);
                interval.B = Round(interval.B);
            }

            // act

            polynomial.FindPositiveAndNegativeValues();

            polynomial.PositiveValues.Should().NotBeNull();
            polynomial.NegativeValues.Should().NotBeNull();

            foreach (var interval in polynomial.PositiveValues!)
            {
                interval.A = Round(interval.A);
                interval.B = Round(interval.B);
            }

            foreach (var interval in polynomial.NegativeValues!)
            {
                interval.A = Round(interval.A);
                interval.B = Round(interval.B);
            }

            // assert

            polynomial.PositiveValues.Should().BeEquivalentTo(positiveValues);
            polynomial.NegativeValues.Should().BeEquivalentTo(negativeValues);
        }

        public static IEnumerable<object[]> GetSampleDataForFindValuesSetTests()
        {
            yield return new object[] { new Polynomial("35"), new Interval(35, 35, true) };
            yield return new object[] { new Polynomial("-35"), new Interval(-35, -35, true) };
            yield return new object[] { new Polynomial("2x+10"), new Interval(Interval.Infinity, Interval.Infinity, true) };
            yield return new object[] { new Polynomial("x^2-2x-1"), new Interval(-2, Interval.Infinity, true) };
            yield return new object[] { new Polynomial("x^3-1"), new Interval(Interval.Infinity, Interval.Infinity, true) };
            yield return new object[] { new Polynomial("x^3+4x^2-3x-18"), new Interval(Interval.Infinity, Interval.Infinity, true) };
        }

        [MemberData(nameof(GetSampleDataForFindValuesSetTests))]
        [Theory]
        public void FindValuesSet_FindsCorrectValuesSet(Polynomial polynomial, Interval valuesSet)
        {
            // arrange 

            valuesSet.A = Round(valuesSet.A);
            valuesSet.B = Round(valuesSet.B);

            // act

            polynomial.FindValuesSet();

            polynomial.ValuesSet.Should().NotBeNull();

            polynomial.ValuesSet!.A = Round(polynomial.ValuesSet!.A);
            polynomial.ValuesSet!.B = Round(polynomial.ValuesSet!.B);

            // assert

            polynomial.ValuesSet.Should().BeEquivalentTo(valuesSet);

        }

        public static IEnumerable<object[]> GetSampleDataForGetPointsForGraphTests()
        {
            yield return new object[] { new Polynomial("35"),
                new List<Point>()
                {
                    new Point(-2, 35),
                    new Point(2, 35),
                }
            };
            
            yield return new object[] { new Polynomial("2x+10"),
                new List<Point>()
                {
                    new Point(-7, -4),
                    new Point(-5, 0),
                    new Point(7, 24),
                }
            };

            yield return new object[] { new Polynomial("x^2-2x-1"),
                new List<Point>()
                {
                    new Point(-5, 34),
                    new Point(-0.4142135623731, 0),
                    new Point(1, -2),
                    new Point(2.4142135623731, 0),
                    new Point(5, 14)
                }
            };

            yield return new object[] { new Polynomial("x^3-1"),
                new List<Point>()
                {
                    new Point(-3, -28),
                    new Point(1, 0),
                    new Point(3, 26),
                }
            };

            yield return new object[] { new Polynomial("x^3+4x^2-3x-18"),
                new List<Point>()
                {
                    new Point(-5, -28),
                    new Point(-3, 0),
                    new Point(0.3333333333333, -18.5185185185185),
                    new Point(2, 0),
                    new Point(5, 192)
                }
            };
        }

        [MemberData(nameof(GetSampleDataForGetPointsForGraphTests))]
        [Theory]
        public void GetPointsForGraph_ReturnsCorrectPoints(Polynomial polynomial, List<Point> points)
        {

            // arrange

            foreach (var point in points)
            {
                point.X = Round(point.X);
                point.Y = Round(point.Y);
            }

            // act

            var result = polynomial.GetPointsForGraph();

            foreach (var point in result)
            {
                point.X = Round(point.X);
                point.Y = Round(point.Y);
            }

            // assert

            result.Should().BeEquivalentTo(points);

        }

        public static IEnumerable<object[]> GetSampleDataForOperatorsTests()
        {
            yield return new object[]
            {
                new Polynomial("x^2-2x-1"),
                new Polynomial("2x+10"),
                new Polynomial("x^2+9"),
                Operators.add
            };

            yield return new object[]
            {
              new Polynomial("x^2-2x-1"),
              new Polynomial("2x+10"),            
              new Polynomial("x^2-4x-11"),
              Operators.subtract
            };

            yield return new object[]
            {
                new Polynomial("x^2-2x-1"),
                new Polynomial("2x+10"),
                new Polynomial("2x^3+6x^2-22x-10"),
                Operators.multiply
            };

            yield return new object[]
            {
                new Polynomial("x^2-2x-1"),
                new Polynomial("2x+10"),
                new Polynomial("0,5x-3,5"),
                Operators.devide
            };

            yield return new object[]
            {
                new Polynomial("x^2-2x-1"),
                new Polynomial("2x+10"),
                new Polynomial("34"),
                Operators.modulo
            };

            ///////////////////////////////

            yield return new object[]
            {
                new Polynomial("x^3-1"),
                new Polynomial("x^3+4x^2-3x-18"),
                new Polynomial("2x^3+4x^2-3x-19"),
                Operators.add
            };

            yield return new object[]
            {
              new Polynomial("x^3-1"),
              new Polynomial("x^3+4x^2-3x-18"),
              new Polynomial("-4x^2+3x+17"),
              Operators.subtract
            };

            yield return new object[]
            {
                new Polynomial("x^3-1"),
                new Polynomial("x^3+4x^2-3x-18"),
                new Polynomial("x^6+4x^5-3x^4-19x^3-4x^2+3x+18"),
                Operators.multiply
            };

            yield return new object[]
            {
                new Polynomial("x^3-1"),
                new Polynomial("x^3+4x^2-3x-18"),
                new Polynomial("1"),
                Operators.devide
            };

            yield return new object[]
            {
                new Polynomial("x^3-1"),
                new Polynomial("x^3+4x^2-3x-18"),
                new Polynomial("-4x^2+3x+17"),
                Operators.modulo
            };

        }

        [MemberData(nameof(GetSampleDataForOperatorsTests))]
        [Theory]
        public void Operators_ForGivenTwoPolynomials_ReturnCorrectPolynomial(Polynomial a, Polynomial b, Polynomial resultPolynomial, Operators op)
        {
            // arange

            var resultPolynomialCoefficients = resultPolynomial.Coefficients;

            for (int i = 0; i < resultPolynomialCoefficients.Length; i++)
            {
                resultPolynomialCoefficients[i] = Round(resultPolynomialCoefficients[i]);
            }

            // act

            Polynomial result;

            switch (op)
            {
                case Operators.add:
                    result = (a + b);
                    break;
                case Operators.subtract:
                    result = a - b;
                    break;
                case Operators.multiply:
                    result = a * b;
                    break;
                case Operators.devide:
                    result = a / b;
                    break;
                case Operators.modulo:
                    result = a % b;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            var resultCoefficients = result.Coefficients;

            for (int i = 0; i < resultCoefficients.Length; i++)
            {
                resultCoefficients[i] = Round(resultCoefficients[i]);
            }

            // assert 

            resultCoefficients.Should().BeEquivalentTo(resultPolynomialCoefficients);
        }

        public static IEnumerable<object[]> GetSampleDataForToStringTests()
        {
            yield return new object[] { new Polynomial("35"), "35" };
            yield return new object[] { new Polynomial("-35"),"-35" };
            yield return new object[] { new Polynomial("3x+1"), "3x+1" };
            yield return new object[] { new Polynomial("-x^3-x^2-x-1"), "-x^3-x^2-x-1" };
            yield return new object[] { new Polynomial("x"), "x" };
            yield return new object[] { new Polynomial("5x^2+2x-10"), "5x^2+2x-10" };
            yield return new object[] { new Polynomial("13x^3-20x+0"), "13x^3-20x" };
        }

        [MemberData(nameof(GetSampleDataForToStringTests))]
        [Theory]
        public void ToString_ReturnsCorrectString(Polynomial polynomial, string formula)
        {
            // arrange

            // act

            var result = polynomial.ToString();

            // assert

            result.Should().Be(formula);
        }

    }
}
