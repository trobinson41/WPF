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

        public static async Task<AccuWeather> GetWeatherInformationAsync (string cityName)
        {
            AccuWeather result = new AccuWeather();

            string locationCode = "347628";

            string url = "/forecasts/v1/daily/1day/" + locationCode +"?apikey=" + API_KEY;

            using (HttpClient client = new HttpClient())
            {
                /*
                Accept:\/*\/
                Accept-Encoding: gzip
                Accept-Language: en - US
                Host: dataservice.accuweather.com
                User-Agent: Mozilla/5.0(Windows NT 10.0; Win64; x64) AppleWebKit/537.36(KHTML
                X-Forwarded-For: 72.220.221.182
                X-Forwarded-Port: 443
                X-Forwarded-Proto: https
                */

                client.BaseAddress = new Uri(BASE_URL);
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<AccuWeather>(json);
            }

            return result;
        }
    }
}
