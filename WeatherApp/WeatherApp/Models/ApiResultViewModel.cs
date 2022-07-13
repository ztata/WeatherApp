using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models.APIModels;

namespace WeatherApp.Models
{
    public class ApiResultViewModel
    {
        public Coordinates coord { get; set; }
        public List<Weather> weather { get; set; }

        //public string base { get; set; }
        public Main main { get; set; }
        public float visibility { get; set; }
        public Wind wind { get; set; }
        public Cloud clouds { get; set; }
        public float dt { get; set; }
        public Sys sys { get; set; }
        public float timezone { get; set; }
        public float id { get; set; }
        public string name { get; set; }
        public float cod { get; set; }
        public string iconUrl { get; set; }
        public string windDirection { get; set; }
        public string countryCode { get; set; }
        public ForecastApiResultModel forecast { get; set; }

    }
}
