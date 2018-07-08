using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Weather.Models
{
    public interface ISerializer<T>
    {
        string SerializeToString(T input);

        T DeserializeFromString(string input);
    }
}
