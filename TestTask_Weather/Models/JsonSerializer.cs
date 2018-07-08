using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestTask_Weather.Models
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        public T DeserializeFromString(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public string SerializeToString(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
