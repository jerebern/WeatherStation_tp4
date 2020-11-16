using OpenWeatherAPI;
using System.Windows;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;


        public MainWindow()
        {
            InitializeComponent();
            AppConfiguration.GetValue("APIKEY");

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            var apiKey = AppConfiguration.GetValue("OWApiKey");
            ApiHelper.InitializeClient();

            vm = new TemperatureViewModel();

            DataContext = vm;           
        }
    }
}
