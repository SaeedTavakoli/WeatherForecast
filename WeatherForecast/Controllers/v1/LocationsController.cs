using AutoMapper;
using Data.Repositories;
using Entities;
using WeatherForecast.Models;
using System;
using WebFramework.Api;

namespace WeatherForecast.Controllers.v1
{
    /// <summary>
    /// Location Crud Controller
    /// </summary>
    public class LocationsController : CrudController<LocationDto, LocationSelectDto, Location, int>
    {
        public LocationsController(IRepository<Location> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
