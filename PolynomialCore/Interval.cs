using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore
{
    /// <summary>
    /// Represents an interval <A; B> or (A; B) etc
    /// If A or B is null they are respectively -∞ and +∞
    /// </summary>
    public class Interval
    {

        public double? A { get; set; }

        public bool isAClosed { get; set; } = false;

        public double? B { get; set; }

        public bool isBClosed { get; set; } = false;

        public Interval(double? a, double? b, bool autoClose = false)
        {
            A = a;
            isAClosed = a == null ? false : autoClose;
            B = b;
            isBClosed = b == null ? false : autoClose;
        }

        public Interval(double? a, bool isAClosed, double? b, bool isBClosed)
        {
            A = a;
            this.isAClosed = isAClosed;
            B = b;
            this.isBClosed = isBClosed;
        }

        public bool contains(double x) => x >= A && x <= B;

        public override string ToString()
        {
            string s = "";

            s += isAClosed ? "<" : "(";
            s += A == null ? "-∞" : ((double)A).ToString("0.#####");

            s += "; ";

            s += B == null ? "+∞" : ((double)B).ToString("0.#####");
            s += isBClosed ? ">" : ")";

            return s;
        }
    }
}
