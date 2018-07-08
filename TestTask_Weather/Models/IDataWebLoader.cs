using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Weather.Models
{
    public interface IDataWebLoader
    {
        Task<string> LoadDataToString(string source, string apiKey = null);
    }
}
