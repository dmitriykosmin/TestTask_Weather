using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTask_Weather.Models;

namespace TestTask_Weather.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICountryRepository countryRepository;
        private IWeatherRepository weatherRepository;

        private Region selectedRegion;

        private WeatherNowViewModel weatherNow;
        private WeatherTodayViewModel weatherToday;

        private string search = "";

        public ObservableCollection<Country> Countries { get; set; }

        public Region SelectedRegion
        {
            get
            {
                return selectedRegion;
            }
            set
            {
                selectedRegion = value;
                OnPropertyChanged("SelectedCountry");
                if (selectedRegion != null)
                {
                    LoadWeatherAsync(selectedRegion.Latitude,
                        selectedRegion.Longtitude);
                }
            }
        }

        public WeatherNowViewModel WeatherNow
        {
            get
            {
                return weatherNow;
            }
            set
            {
                weatherNow = value;
                OnPropertyChanged("WeatherNow");
            }
        }

        public WeatherTodayViewModel WeatherToday
        {
            get
            {
                return weatherToday;
            }
            set
            {
                weatherToday = value;
                OnPropertyChanged("WeatherToday");
            }
        }

        public string Search
        {
            get
            {
                return search;
            }
            set
            {
                search = value;
                OnPropertyChanged("Search");
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                    (searchCommand = new RelayCommand(obj =>
                    {
                        TreeSearch(Search);
                    }));
            }
        }

        private RelayCommand updateTreeCommand;
        public RelayCommand UpdateTreeCommand
        {
            get
            {
                return updateTreeCommand ??
                    (updateTreeCommand = new RelayCommand(obj =>
                    {
                        Countries.Clear();
                        LoadCountriesAsync();
                    }));
            }
        }

        private RelayCommand updateWeatherCommand;
        public RelayCommand UpdateWeatherCommand
        {
            get
            {
                return updateWeatherCommand ??
                    (updateWeatherCommand = new RelayCommand(obj =>
                    {
                        if (selectedRegion != null)
                        {
                            LoadWeatherAsync(selectedRegion.Latitude,
                                selectedRegion.Longtitude);
                        }
                    }));
            }
        }

        public MainWindowViewModel(
            ICountryRepository countryRepository,
            IWeatherRepository weatherRepository
            )
        {
            this.countryRepository = countryRepository;
            this.weatherRepository = weatherRepository;

            Countries = new ObservableCollection<Country>();
            LoadCountriesAsync();

        }

        private async void LoadWeatherAsync(string lat, string lon)
        {
            var weather = await weatherRepository.GetWeather(lat, lon);

            if (weather != null)
            {
                WeatherNow = new WeatherNowViewModel(weather.fact);
                WeatherToday = new WeatherTodayViewModel(weather.forecasts.FirstOrDefault());
            }
        }

        private async void LoadCountriesAsync()
        {
            var newCountries = await countryRepository.LoadCountries();
            foreach (var country in newCountries)
            {
                Countries.Add(country);
            }
            SelectedRegion = newCountries.FirstOrDefault()?.Regions.FirstOrDefault();
            SelectedRegion.IsSelected = true;
        }

        private void LoadCountries()
        {
            var newCountries = Task.Run(countryRepository.LoadCountries).Result;
            foreach (var country in newCountries)
            {
                Countries.Add(country);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void TreeSearch(string search)
        {
            Countries.Clear();
            LoadCountries();

            if (String.IsNullOrWhiteSpace(search))
            {
                return;
            }

            ObservableCollection<Region> filteredRegions = new ObservableCollection<Region>();
            List<Country> emptyCountries = new List<Country>();
            for (int c = 0; c < Countries.Count; c++)
            {
                filteredRegions.Clear();
                foreach (var region in Countries[c].Regions)
                {
                    if (region.Name.ToLower()
                        .Contains(search.ToLower()))
                    {
                        filteredRegions.Add(region);
                    }
                }
                Countries[c].Regions.Clear();
                if (filteredRegions.Count > 0)
                {
                    foreach (var item in filteredRegions)
                    {
                        Countries[c].Regions.Add(item);
                    }
                }
                else
                {
                    emptyCountries.Add(Countries[c]);
                }
            }

            foreach (var c in emptyCountries)
            {
                Countries.Remove(c);
            }
        }
    }
}
