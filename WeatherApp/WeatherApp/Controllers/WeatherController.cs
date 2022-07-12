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
            string toReplace = " ";
            string replaceWith = "%20";
            searchTerm = searchTerm.Trim().Replace(toReplace, replaceWith);
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var apiKey = configuration.GetValue<string>("ApiKeys:RapidApiKey");
            var ApiHostWeather = configuration.GetValue<string>("ApiKeys:RapidApiHostWeather");

            var apiUri = $"https://community-open-weather-map.p.rapidapi.com/weather?q={searchTerm}&units=imperial";

            var apiTask = apiUri.WithHeaders(new
            {
                X_RapidAPI_Host = ApiHostWeather,
                X_RapidAPI_Key = apiKey
            }).GetJsonAsync<ApiResultViewModel>();
            apiTask.Wait();

            ApiResultViewModel result = new ApiResultViewModel();
            result.coord = apiTask.Result.coord;
            result.weather = apiTask.Result.weather;
            result.main = apiTask.Result.main;
            result.visibility = apiTask.Result.visibility;
            result.wind = apiTask.Result.wind;
            result.clouds = apiTask.Result.clouds;
            result.dt = apiTask.Result.dt;
            result.sys = apiTask.Result.sys;
            result.timezone = apiTask.Result.timezone;
            result.name = apiTask.Result.name;
            result.cod = apiTask.Result.cod;
            result.iconUrl = $"http://openweathermap.org/img/w/{apiTask.Result.weather.First().icon}.png";

            return View(result);
        }
    }
}
