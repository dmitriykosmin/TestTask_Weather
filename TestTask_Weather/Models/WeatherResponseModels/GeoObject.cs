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
    public class GeoObject
    {
        public Locality locality { get; set; }
        public Province province { get; set; }
        public Country country { get; set; }
    }
}
