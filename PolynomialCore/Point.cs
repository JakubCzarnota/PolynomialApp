using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore
{
    /// <summary>
    /// Represents a point in cartesian coordinate system
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X value of this point
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y value of this point
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Generates new point
        /// </summary>
        /// <param name="x">X value</param>
        /// <param name="y">Y value</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
