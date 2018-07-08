using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TestTask_Weather.Models
{
    public class CountryJsonRepository : ICountryRepository
    {
        private ISerializer<IEnumerable<Country>> serializer;

        private string source = "countries.json";

        public CountryJsonRepository()
        {
            serializer = new JsonSerializer<IEnumerable<Country>>();
        }

        public async Task<IEnumerable<Country>> LoadCountries()
        {
            if (!File.Exists(source))
            {
                await SaveDefaultCountries();
            }

            FileInfo countriesFile = new FileInfo(source);
            var reader = countriesFile.OpenText();
            string serialized = await reader.ReadToEndAsync();
            reader.Close();

            return serializer.DeserializeFromString(serialized);
        }

        private async Task SaveDefaultCountries()
        {
            Country[] countries = {
                new Country {
                    Name = "Россия",
                    Regions = new ObservableCollection<Region>(new [] {
                        new Region
                        {
                            Name = "Москва",
                            Longtitude = "37.620393",
                            Latitude = "55.75396"
                        },
                        new Region
                        {
                            Name = "Санкт-Петербург",
                            Longtitude = "30.315868",
                            Latitude = "59.939095"
                        },
                        new Region
                        {
                            Name = "Великий Новгород",
                            Longtitude = "31.275475",
                            Latitude = "58.521475"
                        },
                        new Region
                        {
                            Name = "Тверь",
                            Longtitude = "35.911896",
                            Latitude = "56.859611"
                        }
                    })
                },
                new Country {
                    Name = "Украина",
                    Regions = new ObservableCollection<Region>(new [] {
                        new Region
                        {
                            Name = "Киев",
                            Longtitude = "30.523541",
                            Latitude = "50.450418"
                        },
                        new Region
                        {
                            Name = "Одесса",
                            Longtitude = "30.732597",
                            Latitude = "46.484579"
                        },
                    })
                },
                new Country {
                    Name = "Беларусь",
                    Regions = new ObservableCollection<Region>(new [] {
                        new Region
                        {
                            Name = "Могилёв",
                            Longtitude = "30.331014",
                            Latitude = "53.894617"
                        },
                        new Region
                        {
                            Name = "Минск",
                            Longtitude = "27.561831",
                            Latitude = "53.902257"
                        }
                    })
                }
            };

            string serialized = await Task.Run(() =>
            {
                return serializer.SerializeToString(countries);
            });
            FileInfo countriesFile = new FileInfo(source);

            var writer = countriesFile.CreateText();
            await writer.WriteLineAsync(serialized);
            writer.Close();
        }
    }
}
