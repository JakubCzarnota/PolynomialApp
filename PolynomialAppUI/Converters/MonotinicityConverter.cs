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
    class MonotinicityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var poly = value as Polynomial;

            if (poly == null || poly.Monotinicity == null)
                return "∅";

            var monotonicityType = (MonotonicityType)Enum.Parse(typeof(MonotonicityType), parameter.ToString()!);

            List<Interval> intervals;

            switch (monotonicityType)
            {
                case MonotonicityType.Increasing:
                    intervals = poly.Monotinicity.Value.increasing;
                    break;
                case MonotonicityType.Decreasing:
                    intervals = poly.Monotinicity.Value.decreasing;
                    break;
                default:
                    throw new ArgumentException("Invalid monotonicity type");
            }

            if(intervals.Count < 1)
                return "∅";

            string s = "";

            foreach (var interval in intervals)
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
