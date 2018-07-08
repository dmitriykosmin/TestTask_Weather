using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Weather.Models.WeatherResponseModels;

namespace TestTask_Weather.Models
{
    public interface IWeatherRepository
    {
        Task<WeatherResponse> GetWeather(string lat, string lon);
    }
}
