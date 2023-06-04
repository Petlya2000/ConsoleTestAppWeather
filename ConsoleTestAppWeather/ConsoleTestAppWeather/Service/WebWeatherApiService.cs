using ConsoleTestAppWeather.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;



namespace ConsoleTestAppWeather.Service
{
    public class WebWeatherApiService
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _url;

        public WebWeatherApiService(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(nameof(url));
            }

            _url = url;
        }

        public async Task<IEnumerable<Weather>> GetWeatherAsync()
        {
            var result = new List<Weather>();
            WebWeathers webWeather = null;

            try
            {
                using (var response = await _client.GetAsync(_url))
                using (var stream = await response.Content.ReadAsStreamAsync())
                
                    webWeather = await JsonSerializer.DeserializeAsync<WebWeathers>(stream);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            if (webWeather != null && webWeather.count > 0)
            {
                foreach (var wc in webWeather.list)
                {
                    var car = new Weather
                    {
                        id = wc.id,
                        country=wc.sys.country,
                        name = wc.name,
                        pressure = wc.main.pressure,
                        temp = wc.main.temp,
                        humidity = wc.main.humidity,
                        wind_speed=wc.wind.speed,
                    };
                    result.Add(car);
                }
            }

            return result;
        }

    }
}
