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
    class NegativeValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var poly = value as Polynomial;

            if(poly == null || poly.NegativeValues == null || poly.NegativeValues.Count < 1)
                return "Ø";

            string s = "";

            foreach (var negativeValue in poly.NegativeValues ) 
            {
                s += negativeValue.ToString() + "∪";
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
