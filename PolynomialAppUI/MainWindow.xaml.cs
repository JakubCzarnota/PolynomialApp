using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WPF;
using PolynomialCore;
using SkiaSharp;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Point = PolynomialCore.Point;

namespace PolynomialAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowDataContext _dataContext;

        /// <summary>
        /// Initialize main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            _dataContext = new MainWindowDataContext();
            this.DataContext = _dataContext;
        }

        private void FormulaInput1_DataContextChanged(object sender, TextChangedEventArgs args)
        {
            try
            {

                var newPoly = new Polynomial(_dataContext.PolynomialFormula);

                newPoly.FindRoots();
                newPoly.FindExtremeValues();
                newPoly.FindMonotinicity();
                newPoly.FindPositiveAndNegativeValues();
                newPoly.FindValuesSet();

                _dataContext.Polynomial = newPoly;

                var series = getLineSeries(newPoly);

                _dataContext.Series = series;

                var chart = (CartesianChart)FindName("chart");


                chart.YAxes.First().MinLimit = null;
                chart.YAxes.First().MaxLimit = null;

                chart.XAxes.First().MinLimit = null;
                chart.XAxes.First().MaxLimit = null;

            }
            catch (Exception)
            {
                _dataContext.Polynomial = null;
                _dataContext.Series = new ISeries[0];
            }
        }

        private ISeries[] getLineSeries(Polynomial poly)
        {

            var points = poly.GetPointsForGraph();

            var observablePoints = new ObservablePoint[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i];
                observablePoints[i] = new ObservablePoint(point.X, point.Y);
            }

            var colors = new SKColor[]
            {
                SKColors.AliceBlue,
                SKColors.AntiqueWhite,
                SKColors.Aqua,
                SKColors.Aquamarine,
                SKColors.Azure,
                SKColors.Beige,
                SKColors.Bisque,
                SKColors.BlanchedAlmond,
                SKColors.Blue,
                SKColors.BlueViolet,
                SKColors.Brown,
                SKColors.BurlyWood,
                SKColors.CadetBlue,
                SKColors.Chartreuse,
                SKColors.Chocolate,
                SKColors.Coral,
                SKColors.CornflowerBlue,
                SKColors.Cornsilk,
                SKColors.Crimson,
                SKColors.Cyan,
/*                SKColors.DarkBlue,
                SKColors.DarkCyan,
                SKColors.DarkGoldenrod,
                SKColors.DarkGray,
                SKColors.DarkGreen,
                SKColors.DarkKhaki,
                SKColors.DarkMagenta,
                SKColors.DarkOliveGreen,
                SKColors.DarkOrange,
                SKColors.DarkOrchid,
                SKColors.DarkRed,
                SKColors.DarkSalmon,
                SKColors.DarkSeaGreen,
                SKColors.DarkSlateBlue,
                SKColors.DarkSlateGray,
                SKColors.DarkTurquoise,
                SKColors.DarkViolet,*/
                SKColors.DeepPink,
                SKColors.DeepSkyBlue,
                SKColors.DimGray,
                SKColors.DodgerBlue,
                SKColors.Firebrick,
                SKColors.FloralWhite,
                SKColors.ForestGreen,
                SKColors.Fuchsia,
                SKColors.Gainsboro,
                SKColors.GhostWhite,
                SKColors.Gold,
                SKColors.Goldenrod,
                SKColors.Gray,
                SKColors.Green,
                SKColors.GreenYellow,
                SKColors.Honeydew,
                SKColors.HotPink,
                SKColors.IndianRed,
                SKColors.Indigo,
                SKColors.Ivory,
                SKColors.Khaki,
                SKColors.Lavender,
                SKColors.LavenderBlush,
                SKColors.LawnGreen,
                SKColors.LemonChiffon,
                SKColors.LightBlue,
                SKColors.LightCoral,
                SKColors.LightCyan,
                SKColors.LightGoldenrodYellow,
                SKColors.LightGray,
                SKColors.LightGreen,
                SKColors.LightPink,
                SKColors.LightSalmon,
                SKColors.LightSeaGreen,
                SKColors.LightSkyBlue,
                SKColors.LightSlateGray,
                SKColors.LightSteelBlue,
                SKColors.LightYellow,
                SKColors.Lime,
                SKColors.LimeGreen,
                SKColors.Linen,
                SKColors.Magenta,
                SKColors.Maroon,
                SKColors.MediumAquamarine,
                SKColors.MediumBlue,
                SKColors.MediumOrchid,
                SKColors.MediumPurple,
                SKColors.MediumSeaGreen,
                SKColors.MediumSlateBlue,
                SKColors.MediumSpringGreen,
                SKColors.MediumTurquoise,
                SKColors.MediumVioletRed,
                SKColors.MidnightBlue,
                SKColors.MintCream,
                SKColors.MistyRose,
                SKColors.Moccasin,
                SKColors.NavajoWhite,
                SKColors.Navy,
                SKColors.OldLace,
                SKColors.Olive,
                SKColors.OliveDrab,
                SKColors.Orange,
                SKColors.OrangeRed,
                SKColors.Orchid,
                SKColors.PaleGoldenrod,
                SKColors.PaleGreen,
                SKColors.PaleTurquoise,
                SKColors.PaleVioletRed,
                SKColors.PapayaWhip,
                SKColors.PeachPuff,
                SKColors.Peru,
                SKColors.Pink,
                SKColors.Plum,
                SKColors.PowderBlue,
                SKColors.Purple,
                SKColors.Red,
                SKColors.RosyBrown,
                SKColors.RoyalBlue,
                SKColors.SaddleBrown,
                SKColors.Salmon,
                SKColors.SandyBrown,
                SKColors.SeaGreen,
                SKColors.SeaShell,
                SKColors.Sienna,
                SKColors.Silver,
                SKColors.SkyBlue,
                SKColors.SlateBlue,
                SKColors.SlateGray,
                SKColors.Snow,
                SKColors.SpringGreen,
                SKColors.SteelBlue,
                SKColors.Tan,
                SKColors.Teal,
                SKColors.Thistle,
                SKColors.Tomato,
                SKColors.Turquoise,
                SKColors.Violet,
                SKColors.Wheat,
                SKColors.White,
                SKColors.WhiteSmoke,
                SKColors.Yellow,
                SKColors.YellowGreen,
            };

            var rnd = new Random();

            var color = colors[rnd.Next(0, colors.Length)];

            var colorHex = new StringBuilder(color.ToString());

            colorHex[1] = '2';
            colorHex[2] = '0';

            var colorSemiTransparent = SKColor.Parse(colorHex.ToString());

            var aplha = colorSemiTransparent.Alpha;

            var scatterSeries = new ScatterSeries<ObservablePoint>()
            {

                Stroke = new SolidColorPaint(color) { StrokeThickness = 4 },

                Fill = new SolidColorPaint(colorSemiTransparent),

                GeometrySize = 15,

                Values = observablePoints,


                YToolTipLabelFormatter = (charPoint) =>
                {
                    return $"{charPoint.Coordinate.SecondaryValue.ToString("0.#####")}; {charPoint.Coordinate.PrimaryValue.ToString("0.#####")}";
                }
            };

            double left = -2;
            double right = 2;

            if (points.Length > 0)
            {
                left += points[0].X;
                right += points[points.Length - 1].X;
            }

            var edgeValue = Math.Abs(left) > Math.Abs(right) ? Math.Abs(left) : Math.Abs(right);

            List<ObservablePoint> observablePoints2 = new List<ObservablePoint>();

            var distance = Math.Abs(-edgeValue - edgeValue);

            double shift = 0.005;

            while (distance / shift > 500)
            {
                shift *= 2;
            }

            for (double i = -edgeValue; i <= edgeValue; i += shift)
            {
                i = Math.Round(i * 10000) / 10000;
                observablePoints2.Add(new ObservablePoint(i, poly.Y(i)));
            }

            var lineSeries = new LineSeries<ObservablePoint>()
            {
                Stroke = new SolidColorPaint(color) { StrokeThickness = 4 },

                Fill = new SolidColorPaint(colorSemiTransparent),

                Values = observablePoints2,

                GeometryStroke = new SolidColorPaint(SKColors.Transparent),
                GeometryFill = new SolidColorPaint(SKColors.Transparent),

                YToolTipLabelFormatter = (charPoint) =>
                {
                    return $"{charPoint.Coordinate.SecondaryValue.ToString("0.#####")}; {charPoint.Coordinate.PrimaryValue.ToString("0.#####")}";
                },

            };

            var series = new ISeries[]
            {
                lineSeries,
                scatterSeries,
            };

            return series;
        }

        private void FormulaInput2_DataContextTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var newPoly = new Polynomial(_dataContext.SecondPolynomialFormula);

                _dataContext.SecondPolynomial = newPoly;
            }
            catch (Exception)
            {
                _dataContext.SecondPolynomial = null;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (_dataContext.Polynomial != null && _dataContext.SecondPolynomial != null)
            {
                var newPoly = _dataContext.Polynomial + _dataContext.SecondPolynomial;

                _dataContext.Polynomial = newPoly;
                _dataContext.PolynomialFormula = _dataContext.Polynomial.ToString();
            }
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            if (_dataContext.Polynomial != null && _dataContext.SecondPolynomial != null)
            {
                var newPoly = _dataContext.Polynomial - _dataContext.SecondPolynomial;

                _dataContext.Polynomial = newPoly;
                _dataContext.PolynomialFormula = _dataContext.Polynomial.ToString();
            }
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (_dataContext.Polynomial != null && _dataContext.SecondPolynomial != null)
            {
                var newPoly = _dataContext.Polynomial * _dataContext.SecondPolynomial;

                _dataContext.Polynomial = newPoly;
                _dataContext.PolynomialFormula = _dataContext.Polynomial.ToString();
            }
        }

        private void Devide_Click(object sender, RoutedEventArgs e)
        {
            if (_dataContext.Polynomial != null && _dataContext.SecondPolynomial != null)
            {
                Polynomial rest;

                var newPoly = Polynomial.Devide(_dataContext.Polynomial, _dataContext.SecondPolynomial, out rest);

                _dataContext.Polynomial = newPoly;
                _dataContext.PolynomialFormula = _dataContext.Polynomial.ToString();
                _dataContext.Rest = rest.ToString();
            }
        }
    }
}