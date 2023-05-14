using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WeatherForecast.Services.OpenWeather
{
    public class Coord
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }
}
