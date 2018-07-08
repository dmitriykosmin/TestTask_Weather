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
    public class Parts
    {
        public Night night { get; set; }
        public Morning morning { get; set; }
        public Day day { get; set; }
        public Evening evening { get; set; }
    }
}
