using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using Flurl.Http;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchResult(string searchTerm)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var apiKey = configuration.GetValue<string>("ApiKeys:RapidApiKey");
            var ApiHostWeather = configuration.GetValue<string>("ApiKeys:RapidApiHostWeather");

            var apiUri = $"";

            var apiTask = apiUri.WithHeaders(new
            {
                X_RapidAPI_Host = ApiHostWeather,
                X_RapidAPI_Key = apiKey
            }).GetJsonAsync<ApiResult>();
            apiTask.Wait();





            return View();
        }
    }
}
