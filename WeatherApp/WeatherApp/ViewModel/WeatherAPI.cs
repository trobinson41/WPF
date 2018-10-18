using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    public class WeatherAPI
    {
        public const string API_KEY = "PSte10pDS2m7JZ6e2Afd8rtLcK8kRquo";
        public const string BASE_URL = "http://dataservice.accuweather.com/forecasts/v1/daily/1day/";
        public const string BASE_URL_AUTOCOMPLETE = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}";

        public static async Task<AccuWeather> GetWeatherInformationAsync (string locationCode)
        {
            AccuWeather result = new AccuWeather();

            if (locationCode != "")
            {
                //string locationCode = "347628";

                string url = "/forecasts/v1/daily/1day/" + locationCode + "?apikey=" + API_KEY;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BASE_URL);
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<AccuWeather>(json);
                    result.DailyForecastDay1.MaximumTemperature = result.DailyForecasts[0].Temperature.Maximum.Value.ToString() + " °" + result.DailyForecasts[0].Temperature.Maximum.Unit;
                    result.DailyForecastDay1.MinimumTemperature = result.DailyForecasts[0].Temperature.Minimum.Value.ToString() + " °" + result.DailyForecasts[0].Temperature.Minimum.Unit;
                    result.DailyForecastDay1.DayText = result.DailyForecastDay1.Day.IconPhrase;
                    result.DailyForecastDay1.NightText = result.DailyForecastDay1.Night.IconPhrase;
                }
            }
            else
            {
                result.DailyForecastDay1.Temperature.Minimum.Value = 0;
                result.DailyForecastDay1.Temperature.Maximum.Value = 0;
            }

            return result;
        }

        public static async Task<CityForList[]> GetAutocompleteAsync(string query)
        {
            Result[] cities;
            List<CityForList> citiesForList = new List<CityForList>();

            string url = string.Format(BASE_URL_AUTOCOMPLETE, API_KEY, query);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();
                    var city = JsonConvert.DeserializeObject<List<Result>>(json);
                    cities = city.ToArray();
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("Could not retrieve list of cities.", "Error Retrieving List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return null;
            }

            foreach (var city in cities)
            {
                citiesForList.Add(new CityForList()
                {
                    DisplayLabel = city.LocalizedName + ", " + city.AdministrativeArea.LocalizedName + ", " + city.Country.LocalizedName,
                    LocationCode = city.Key
                });
            }

            return citiesForList.ToArray();
        }
    }
}
