using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using PolynomialCore;
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
                var series = new ISeries[1];
                _dataContext.Series = series;

                var newPoly = new Polynomial(_dataContext.PolynomialFormula);

                newPoly.findRoots();
                newPoly.findExtremeValues();

                _dataContext.Polynomial = newPoly;

                series[0] = getLineSeries(newPoly);

                _dataContext.Series = series;
            }
            catch (Exception)
            {
                _dataContext.Polynomial = null;
                _dataContext.Series = new ISeries[0];
            }
        }

        private LineSeries<ObservablePoint> getLineSeries(Polynomial poly)
        {

            double left = -2;
            double right = 2;

            if (poly.Roots != null && poly.ExtremeValues != null && poly.Roots.Count > 0 && poly.ExtremeValues.Count > 0)
            {
                left = poly.Roots[0].Value < poly.ExtremeValues![0].X ? poly.Roots[0].Value - 2 : poly.ExtremeValues[0].X - 2;

                right = poly.Roots.Last().Value > poly.ExtremeValues!.Last().X ? poly.Roots.Last().Value + 2 : poly.ExtremeValues.Last().X + 2;
            }
            else if (poly.Roots != null && poly.Roots.Count > 0) {
                left = poly.Roots[0].Value - 2;

                right = poly.Roots.Last().Value + 2;
            }
            else if (poly.ExtremeValues != null && poly.ExtremeValues.Count > 0)
            {
                left = poly.ExtremeValues[0].X - 2;

                right = poly.ExtremeValues.Last().X + 2;
            }

            var edgeValue = Math.Abs(left) > Math.Abs(right) ? Math.Abs(left) : Math.Abs(right);

            List<ObservablePoint> points = new List<ObservablePoint>();

            points.Add(new ObservablePoint(-edgeValue, poly.y(-edgeValue)));

            if (poly.Roots != null)
                foreach (var root in poly.Roots)
                {
                    points.Add(new ObservablePoint(root.Value, 0));
                }

            if (poly.ExtremeValues != null)
                foreach (var extremeValue in poly.ExtremeValues)
                {
                    points.Add(new ObservablePoint(extremeValue.X, extremeValue.Y));
                }

            points.Add(new ObservablePoint(edgeValue, poly.y(edgeValue)));

            var lineSeries = new LineSeries<ObservablePoint>()
            {

                Values = points.Distinct().OrderBy(p => p.X).ToArray(),

                LineSmoothness = 0.75,

                YToolTipLabelFormatter = (charPoint) =>
                {
                    return $"{charPoint.Coordinate.SecondaryValue.ToString("0.#####")}; {charPoint.Coordinate.PrimaryValue.ToString("0.#####")}";
                }
            };

            return lineSeries;
        }
    }
}