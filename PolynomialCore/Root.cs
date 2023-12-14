using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore
{
    /// <summary>
    /// Represents a polynomial root
    /// </summary>
    public class Root
    {
        /// <summary>
        /// X value of this root
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Multiplicity of this root
        /// </summary>
        public int Multiplicity { get; set; }

        /// <summary>
        /// Creates new root
        /// </summary>
        /// <param name="value">X value</param>
        /// <param name="multiplicity">Multiplicity</param>
        public Root(double value, int multiplicity = 1) 
        { 
            Value = value;
            Multiplicity = multiplicity;
        }

    }
}
