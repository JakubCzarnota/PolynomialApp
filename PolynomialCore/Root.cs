using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialCore
{
    public class Root
    {
        public double Value { get; set; }

        public int Multiplicity { get; set; }

        public Root(double value, int multiplicity = 1) 
        { 
            Value = value;
            Multiplicity = multiplicity;
        }

    }
}
