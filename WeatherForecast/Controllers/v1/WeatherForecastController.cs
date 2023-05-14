using Common.Api;
using Common.Exceptions;
using Common.Utilities;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Models;
using WeatherForecast.Services.OpenWeather;
using WebFramework.Api;

namespace WeatherForecast.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1")]
    public class WeatherForecastController : BaseController
    {
        private readonly IOpenWeatherClient _openWeatherClient;
        private readonly IRepository<Location> _locationRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="openWeatherClient"></param>
        /// <param name="locationRepository"></param>
        public WeatherForecastController(IOpenWeatherClient openWeatherClient, IRepository<Location> locationRepository)
        {
            _openWeatherClient = openWeatherClient;
            _locationRepository = locationRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet]
        public WeatherResponseDto GetForecastByCity(string cityName)
        {
            if (!cityName.HasValue())
            {
                throw new BadRequestException(Messages.GetMessage(Messages.MessageType.ErrorNotFound, text: "cityName"));
            }

            WeatherResponse currentWeather = _openWeatherClient.GetCurrentWeather(cityName);

            return currentWeather.WeatherResponseToDto();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet]
        public WeatherResponseDto GetForecastByCoord(float? lat = null, float? lon = null)
        {
            if (lat == null)
            {
                throw new BadRequestException(Messages.GetMessage(Messages.MessageType.ErrorNotFound, text: "lat"));
            }
            if (lon == null)
            {
                throw new BadRequestException(Messages.GetMessage(Messages.MessageType.ErrorNotFound, text: "lon"));
            }

            WeatherResponse currentWeather = _openWeatherClient.GetCurrentWeather(lat: lat, lon: lon);

            return currentWeather.WeatherResponseToDto();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet]
        public WeatherResponseDto GetForecastByLocationId(int? id)
        {
            if (id == null)
            {
                throw new BadRequestException(Messages.GetMessage(Messages.MessageType.ErrorNotFound, text: "Id"));
            }

            var location = _locationRepository.GetById(id);

            if (location == null)
            {
                throw new BadRequestException(Messages.GetMessage(Messages.MessageType.ErrorNotFoundItem, text: "مکانی"));
            }

            WeatherResponse currentWeather = _openWeatherClient.GetCurrentWeather(location.Name, location.Latitude, location.Longitude);

            return currentWeather.WeatherResponseToDto();
        }
    }
}
