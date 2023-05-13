using AutoMapper;
using Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebFramework.Api;

namespace WeatherForecast.Models
{
    public class LocationDto : BaseDto<LocationDto, Location, int>
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را مشخص کنید")]
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }

    public class LocationSelectDto : BaseDto<LocationSelectDto, Location, int>
    {
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }



        public override void CustomMappings(IMappingExpression<Location, LocationSelectDto> mappingExpression)
        {
            //mappingExpression.ForMember(
            //        dest => dest.Name,
            //        config => config.MapFrom(src => $""));
        }
    }
}
