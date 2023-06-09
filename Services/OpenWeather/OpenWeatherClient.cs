﻿using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Services.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Services.OpenWeather
{
    public class OpenWeatherClient : IOpenWeatherClient
    {
        private readonly IConfiguration _configuration;
        private readonly IApiCaller _iApiCaller;

        private readonly string _appId;

        private const string url = "http://api.openweathermap.org/data/2.5/";

        public OpenWeatherClient(IOptionsSnapshot<SiteSettings> settings, IApiCaller iApiCaller)
        {
            _appId = settings.Value.ApiKey;
            _iApiCaller = iApiCaller;
        }

        public WeatherResponse GetCurrentWeather(string city, double? lat, double? lon)
        {
            return _iApiCaller.CallApi<WeatherResponse>(Method.GET, url + $"weather?q={city}&lat={lat}&lon={lon}&units=metric&APPID={_appId}");
        }

    }
}
