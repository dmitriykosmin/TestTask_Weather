using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Weather.Models.WeatherResponseModels;

namespace TestTask_Weather.Models
{
    public class WeatherJsonRepository : IWeatherRepository
    {
        private ISerializer<WeatherResponse> serializer;
        private IDataWebLoader loader;

        private string source = "https://api.weather.yandex.ru/v1/forecast";
        private string apiKey = "6209aed2-2e6e-4028-a003-67986871b108";

        public WeatherJsonRepository()
        {
            serializer = new JsonSerializer<WeatherResponse>();
            loader = new DataHttpLoader();
        }

        public async Task<WeatherResponse> GetWeather(string lat, string lon)
        {
            string request = $"{source}?lat={lat}&lon={lon}" +
                $"&lang=ru_RU&limit=2&extra=true";

            string response;
            try
            {
                response = await loader.LoadDataToString(request, apiKey);
            }
            catch
            {
                return null;
            }

            return serializer.DeserializeFromString(response);
        }
    }
}
