using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Weather.Models
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> LoadCountries();
    }
}
