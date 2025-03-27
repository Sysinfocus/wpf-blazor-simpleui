using Microsoft.Extensions.DependencyInjection;
using Sysinfocus.AspNetCore.Components;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;
using WpfBlazorSimpleUI.Data;

namespace WpfBlazorSimpleUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddScoped(_ => new HttpClient { BaseAddress = new Uri("http://0.0.0.0") });
            serviceCollection.AddSingleton<WeatherForecastService>();
            serviceCollection.AddSysinfocus(false);
            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}