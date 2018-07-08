using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Weather.Models
{
    public class DataHttpLoader : IDataWebLoader
    {
        public async Task<string> LoadDataToString(string source, string apiKey = null)
        {
            string result = "";

            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(source),
                    Method = HttpMethod.Get,
                };

                if (apiKey != null)
                {
                    request.Headers.Add("X-Yandex-API-Key", apiKey);
                }

                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }

            return result;
        }
    }
}
