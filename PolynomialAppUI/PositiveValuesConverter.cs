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
    internal class PositiveValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var poly = value as Polynomial;

            if (poly == null || poly.PositiveValues == null || poly.PositiveValues.Count < 1)
                return "Ø";

            string s = "";

            foreach (var positiveValues in poly.PositiveValues)
            {
                s += positiveValues.ToString() + "∪";
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
