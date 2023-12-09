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
                var newPoly = new Polynomial(_dataContext.PolynomialFormula);

                newPoly.findRoots();
                newPoly.findExtremeValues();

                _dataContext.Polynomial = newPoly;
            }
            catch (Exception)
            {
                _dataContext.Polynomial = null;
            }
        }
    }
}