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
    class MonotinicityDecreasingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var poly = value as Polynomial;

            string s = "f(x)↓∈";

            if (poly == null || poly.Monotinicity == null || poly.Monotinicity.Value.decreasing.Count() < 1)
                return s + "∅";

            List<Interval> decreasing = poly.Monotinicity.Value.decreasing;

            foreach (var interval in decreasing)
            {
                s += $"{interval}∪";
            }

            s = s.Substring(0, s.Length - 1);

            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null!;
        }
    }
}
