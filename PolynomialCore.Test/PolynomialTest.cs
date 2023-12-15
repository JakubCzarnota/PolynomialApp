using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore.Test
{
    public class PolynomialTest
    {
        [InlineData("3x+1", new double[] {1, 3}, 1)]
        [InlineData("5x^2+2x-10", new double[] { -10, 2, 5 }, 2)]
        [InlineData("13x^3-20x+0", new double[] {0, -20, 0, 13}, 3)]
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

    }
}
