using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models.APIModels
{
    public class Sys
    {
        public float type { get; set; }
        public float id { get; set; }
        public string country { get; set; }
        public float sunrise { get; set; }
        public float sunset { get; set; }
    }
}
