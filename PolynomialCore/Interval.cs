using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore
{
    /// <summary>
    /// Represents an interval (A; B)
    /// If A or B is null they are respectively -∞ and +∞
    /// </summary>
    public class Interval
    {
        /// <summary>
        /// Left value of this interval
        /// </summary>
        public double? A { get; set; }

        /// <summary>
        /// Is this interval closed on the left side
        /// </summary>
        public bool isAClosed { get; set; } = false;

        /// <summary>
        /// Right value of this interval
        /// </summary>
        public double? B { get; set; }

        /// <summary>
        /// Is this interval closed on the right side
        /// </summary>
        public bool isBClosed { get; set; } = false;

        /// <summary>
        /// Generates new interval 
        /// </summary>
        /// <param name="a">Left value</param>
        /// <param name="b">Right value</param>
        /// <param name="autoClose">Should it be automaticly closed</param>
        public Interval(double? a, double? b, bool autoClose = false)
        {
            A = a;
            isAClosed = a == null ? false : autoClose;
            B = b;
            isBClosed = b == null ? false : autoClose;
        }

        /// <summary>
        /// Generates new interval 
        /// </summary>
        /// <param name="a">Left value</param>
        /// <param name="isAClosed">Is it closed on the left side</param>
        /// <param name="b">Right value</param>
        /// <param name="isBClosed">Is it closed on the right side</param>
        public Interval(double? a, bool isAClosed, double? b, bool isBClosed)
        {
            A = a;
            this.isAClosed = isAClosed;
            B = b;
            this.isBClosed = isBClosed;
        }

        /// <summary>
        /// Gets if this interval contains x 
        /// </summary>
        /// <param name="x">X value</param>
        /// <returns>True/false</returns>
        public bool contains(double x) => x >= A && x <= B;

        /// <summary>
        /// Gets this interval as a string
        /// </summary>
        /// <returns>This interval as a string</returns>
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
