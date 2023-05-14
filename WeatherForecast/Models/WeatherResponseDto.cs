using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Services.OpenWeather;

namespace WeatherForecast.Models
{
    public class WeatherResponseDto
    {
        public string? Location { get; set; }
        public string? DateTime { get; set; }
        public string? WeatherIcon { get; set; }
        public string? WeatherDescription { get; set; }
        public int Temperature { get; set; }
        public int TemperatureMax { get; set; }
        public int TemperatureMin { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
    }

    public static class WeatherResponseDtoExtensions
    {
        public static WeatherResponseDto WeatherResponseToDto(this WeatherResponse weatherResponse)
        {
            return new WeatherResponseDto()
            {
                Location = weatherResponse.Name,
                WeatherIcon = weatherResponse.Weather?.First().Icon,
                WeatherDescription = weatherResponse.Weather?.First().Description,
                Temperature = (int)(weatherResponse.Main?.Temp ?? 0),
                TemperatureMax = (int)(weatherResponse.Main?.Temp_Max ?? 0),
                TemperatureMin = (int)(weatherResponse.Main?.Temp_Min ?? 0),
                Humidity = (weatherResponse.Main?.Humidity ?? 0),
                WindSpeed = (int)(weatherResponse.Wind?.Speed ?? 0)
            };
        }

    }
}
