﻿using PolynomialCore;
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
            Polynomial? poly = value as Polynomial;

            if (poly == null)
                return "";

            List<Root>? roots = poly.Roots;

            if (roots == null || roots.Count == 0)
                return "";

            string s = "";

            foreach (var root in roots)
            {
                s += root.Value.ToString("0.######");
                s += "; ";
            }

           s = s.Substring(0, s.Length - 2);

            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null!;
        }
    }
}