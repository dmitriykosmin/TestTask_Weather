using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Weather.Models.WeatherResponseModels
{
    [Serializable]
    [JsonObject]
    public class Forecast
    {
        public string date { get; set; }
        public int date_ts { get; set; }
        public int week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public int moon_code { get; set; }
        public string moon_text { get; set; }
        public Parts parts { get; set; }
    }
}
