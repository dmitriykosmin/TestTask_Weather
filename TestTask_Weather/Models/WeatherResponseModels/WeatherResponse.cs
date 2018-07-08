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
    public class WeatherResponse
    {
        public int now { get; set; }
        public DateTime now_dt { get; set; }
        public Info info { get; set; }
        public GeoObject geo_object { get; set; }
        public Fact fact { get; set; }
        public IEnumerable<Forecast> forecasts { get; set; }
    }
}
