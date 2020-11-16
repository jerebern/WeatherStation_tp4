using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    public class OpenWeatherService : ITemperatureService
    {

        private static OpenWeatherProcessor owp;
        public TemperatureModel LastTemp;

        public OpenWeatherService(string apiKey)
        {
            LastTemp = new TemperatureModel();
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }
        public async Task<TemperatureModel> GetTempAsync()
        {
                
           ///https://github.com/dotnet/runtime/issues/23747
            var result = await owp.GetCurrentWeatherAsync();
            
            long longDate = result.DateTime;
          
            LastTemp.DateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(longDate).ToLocalTime();
            LastTemp.Temperature = result.Main.Temperature;

            return LastTemp;
        }
    }
}
