using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestTask_Weather.Models.WeatherResponseModels
{
    [Serializable]
    [JsonObject]
    public class Info
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public int geoid { get; set; }
        public string slug { get; set; }
        public int def_pressure_mm { get; set; }
        public int def_pressure_pa { get; set; }
        public string url { get; set; }
    }
}
