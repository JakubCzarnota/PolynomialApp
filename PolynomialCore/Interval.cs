using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore
{
    public class Interval
    {

        public double A { get; set; }

        public double B { get; set; }

        public Interval(double a, double b)
        {
            A = a;
            B = b;
        }

        public bool contains(double x) => x >= A && x <= B;

    }
}
