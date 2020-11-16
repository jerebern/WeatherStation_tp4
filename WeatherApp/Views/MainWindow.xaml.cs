using OpenWeatherAPI;
using System.Windows;
using WeatherApp.Services;
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

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            string apiKey = AppConfiguration.GetValue("OWApiKey");
            ApiHelper.InitializeClient();
            ITemperatureService temperatureService = new OpenWeatherService(apiKey);
            vm = new TemperatureViewModel(temperatureService);

            DataContext = vm;           
        }
    }
}
