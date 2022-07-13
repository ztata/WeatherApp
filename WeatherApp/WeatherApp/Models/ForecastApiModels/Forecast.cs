using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models.APIModels;

namespace WeatherApp.Models.ForecastApiModels
{
    public class Forecast
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Cloud clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public string dt_txt { get; set; }
    }
}
