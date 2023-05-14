using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services.OpenWeather
{
    public interface IOpenWeatherClient
    {
        WeatherResponse GetCurrentWeather(string city = "", double? lat = null, double? lon = null);
    }
}
