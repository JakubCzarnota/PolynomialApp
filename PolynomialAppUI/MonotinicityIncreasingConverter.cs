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
    class MonotinicityIncreasingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var poly = value as Polynomial;

            string s = "f(x)↑⇔x∈";

            if (poly == null || poly.Monotinicity == null || poly.Monotinicity.Value.increasing.Count() < 1)
                return s + "∅";

            List<Interval> increasing = poly.Monotinicity.Value.increasing;

            foreach (var interval in increasing)
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
