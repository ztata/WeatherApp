using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models.ForecastApiModels
{
    public class ForecastCity
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
    }
}
