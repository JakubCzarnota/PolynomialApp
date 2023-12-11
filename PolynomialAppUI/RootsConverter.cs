using PolynomialCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PolynomialAppUI
{
    class RootsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var poly = value as Polynomial;

            string s = "x∈";

            if (poly == null || poly.Roots == null || poly.Roots.Count == 0)
                return s + "Ø";

            s += "{";

            foreach (var root in poly.Roots)
            {
                s += root.Value.ToString("0.######");
                s += "; ";
            }

           s = s.Substring(0, s.Length - 2) + "}";

            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null!;
        }
    }
}
