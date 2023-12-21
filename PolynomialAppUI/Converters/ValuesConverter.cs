using PolynomialCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PolynomialAppUI.Converters
{
    class ValuesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var poly = value as Polynomial;

            if(poly == null)
                return "Ø";

            List<Interval>? intervals;

            var valuesType = (ValuesType)Enum.Parse(typeof(ValuesType), parameter.ToString()!);

            switch (valuesType)
            {
                case ValuesType.Negative:
                    intervals = poly.NegativeValues;
                    break;
                case ValuesType.Positive:
                    intervals = poly.PositiveValues;
                    break;
                default:
                    throw new ArgumentException("Invalid values type");
            }

            if (intervals == null || intervals.Count < 1)
                return "Ø";

            string s = "";

            foreach (var negativeValue in intervals ) 
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
