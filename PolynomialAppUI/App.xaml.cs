using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PolynomialAppUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LiveCharts.Configure(config =>
                config
                    .AddDarkTheme()
                    .AddSkiaSharp()
                    .AddDefaultMappers()
                );
        }
    }

}
