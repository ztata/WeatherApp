using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models.ForecastApiModels;

namespace WeatherApp.Models
{
    public class ForecastApiResultModel
    {
        public int cnt { get; set; }
        public List<Forecast> list { get; set; }
        public City city { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }
}
