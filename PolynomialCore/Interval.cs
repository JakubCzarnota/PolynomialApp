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
        /// Represents plus and minus infinity
        /// </summary>
        public static readonly double? Infinity = null;

        /// <summary>
        /// Left value of this interval
        /// </summary>
        public double? A { get; set; }

        /// <summary>
        /// Is this interval closed on the left side
        /// </summary>
        public bool IsAClosed { get; set; } = false;

        /// <summary>
        /// Right value of this interval
        /// </summary>
        public double? B { get; set; }

        /// <summary>
        /// Is this interval closed on the right side
        /// </summary>
        public bool IsBClosed { get; set; } = false;

        /// <summary>
        /// Generates new interval 
        /// </summary>
        /// <param name="a">Left value</param>
        /// <param name="b">Right value</param>
        /// <param name="autoClose">Should it be automaticly closed</param>
        public Interval(double? a, double? b, bool autoClose = false)
        {
            A = a;
            IsAClosed = a == null ? false : autoClose;
            B = b;
            IsBClosed = b == null ? false : autoClose;
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
            this.IsAClosed = isAClosed;
            B = b;
            this.IsBClosed = isBClosed;
        }

        /// <summary>
        /// Gets if this interval contains x 
        /// </summary>
        /// <param name="x">X value</param>
        /// <returns>True/false</returns>
        public bool Contains(double x) => x >= A && x <= B;

        /// <summary>
        /// Gets this interval as a string
        /// </summary>
        /// <returns>This interval as a string</returns>
        public override string ToString()
        {
            if (A == B && A != Infinity)
                return "{" + A + "}";

            string s = "";

            s += IsAClosed ? "<" : "(";
            s += A == Infinity ? "-∞" : ((double)A!).ToString("0.#####");

            s += "; ";

            s += B == Infinity ? "+∞" : ((double)B!).ToString("0.#####");
            s += IsBClosed ? ">" : ")";

            return s;
        }
    }
}
