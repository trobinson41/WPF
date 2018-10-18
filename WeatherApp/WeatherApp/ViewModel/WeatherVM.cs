using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;

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

        private CityForList selectedResult;
        public CityForList SelectedResult
        {
            get { return selectedResult; }
            set
            {
                selectedResult = value;
                GetWeather();
            }
        }

        public RefreshCommand RefreshCommand { get; set; }

        public WeatherVM()
        {
            Weather = new AccuWeather();
            Cities = new ObservableCollection<CityForList>();
            SelectedResult = new CityForList();
            RefreshCommand = new RefreshCommand(this);
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

        public async void GetWeather()
        {
            var weather = await WeatherAPI.GetWeatherInformationAsync(selectedResult.LocationCode);
            Weather.Headline.ForecastText = weather.Headline.ForecastText;
            Weather.Headline.EffectiveDate = weather.Headline.EffectiveDate;
            Weather.DailyForecastDay1.MaximumTemperature = weather.DailyForecasts[0].Temperature.Maximum.Value.ToString() + " °" + weather.DailyForecasts[0].Temperature.Maximum.Unit;
            Weather.DailyForecastDay1.MinimumTemperature = weather.DailyForecasts[0].Temperature.Minimum.Value.ToString() + " °" + weather.DailyForecasts[0].Temperature.Minimum.Unit;
            Weather.DailyForecastDay1.DayText = weather.DailyForecasts[0].Day.IconPhrase;
            Weather.DailyForecastDay1.NightText = weather.DailyForecasts[0].Night.IconPhrase;
        }
    }
}
