using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Weather.Models.WeatherResponseModels;

namespace TestTask_Weather.ViewModels
{
    public class WeatherTodayViewModel
    {
        private Forecast forecast;

        public List<WeatherTodayPartViewModel> WeatherTodayParts { get; set; }

        public WeatherTodayViewModel(Forecast forecast)
        {
            this.forecast = forecast;
            WeatherTodayParts = new List<WeatherTodayPartViewModel>();

            if (forecast != null)
                InitModel();
        }

        private void InitModel()
        {
            WeatherTodayParts.Add(new WeatherTodayPartViewModel(forecast.parts.night));
            WeatherTodayParts.Add(new WeatherTodayPartViewModel(forecast.parts.morning));
            WeatherTodayParts.Add(new WeatherTodayPartViewModel(forecast.parts.day));
            WeatherTodayParts.Add(new WeatherTodayPartViewModel(forecast.parts.evening));
        }
    }
}
