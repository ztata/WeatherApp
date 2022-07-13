using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models.GeocodingApiModels;

namespace WeatherApp.Models
{
    public class GeocodingApiResultModel
    {
        public List<City> cities { get; set; }
    }
}
