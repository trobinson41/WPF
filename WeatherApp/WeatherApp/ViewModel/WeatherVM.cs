using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherVM
    {
        public AccuWeather Weather { get; set; }

        private string query;
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                GetCities();
            }
        }

        public ObservableCollection<CityForList> Cities { get; set; }

        public WeatherVM()
        {
            Weather = new AccuWeather();
            Cities = new ObservableCollection<CityForList>();
        }

        private async void GetCities()
        {
            var cities = await WeatherAPI.GetAutocompleteAsync(Query);
            if (cities == null)
            {
                Cities.Clear();
                return;
            }

            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }
    }
}
