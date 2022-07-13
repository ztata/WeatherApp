using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using Flurl.Http;
using WeatherApp.Models.APIModels;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            if (DateTime.Now.Hour >= 4 && DateTime.Now.Hour < 12)
            {
                model.welcomeMessage = "Good Morning";
            }
            else if(DateTime.Now.Hour>=12 && DateTime.Now.Hour < 17)
            {
                model.welcomeMessage = "Good Afternoon";
            }
            else
            {
                model.welcomeMessage = "Good Evening";
            }
            return View(model);
        }

        public IActionResult SearchResult(string searchTerm)
        {
            //ACTUAL BUSINESS LOGIC BELOW. THIS IS THE FINISHED CODE 

            //string toReplace = " ";
            //string replaceWith = "%20";
            //searchTerm = searchTerm.Trim().Replace(toReplace, replaceWith);
            //var builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json", optional: false);
            //var configuration = builder.Build();

            //var apiKey = configuration.GetValue<string>("ApiKeys:RapidApiKey");
            //var ApiHostWeather = configuration.GetValue<string>("ApiKeys:RapidApiHostWeather");

            //var apiUri = $"https://community-open-weather-map.p.rapidapi.com/weather?q={searchTerm}&units=imperial";

            //var apiTask = apiUri.WithHeaders(new
            //{
            //    X_RapidAPI_Host = ApiHostWeather,
            //    X_RapidAPI_Key = apiKey
            //}).GetJsonAsync<ApiResultViewModel>();
            //apiTask.Wait();

            //ApiResultViewModel result = new ApiResultViewModel();
            //result.coord = apiTask.Result.coord;
            //result.weather = apiTask.Result.weather;
            //result.main = apiTask.Result.main;
            //result.visibility = apiTask.Result.visibility;
            //result.wind = apiTask.Result.wind;
            //result.clouds = apiTask.Result.clouds;
            //result.dt = apiTask.Result.dt;
            //result.sys = apiTask.Result.sys;
            //result.timezone = apiTask.Result.timezone;
            //result.name = apiTask.Result.name;
            //result.cod = apiTask.Result.cod;
            //result.iconUrl = $"http://openweathermap.org/img/w/{apiTask.Result.weather.First().icon}.png";

            Weather mockWeather = new Weather();
            mockWeather.main = "clouds";
            mockWeather.description = "broken clouds";
            mockWeather.icon = "04d";
            List<Weather> mockList = new List<Weather>();
            mockList.Add(mockWeather);

            Main mockMain = new Main();
            mockMain.temp = 83.25F;
            mockMain.feels_like = 78.85F;
            mockMain.pressure = 1022;
            mockMain.humidity = 46;

            Cloud mockCloud = new Cloud();
            mockCloud.all = 100;

            Wind mockWind = new Wind();
            mockWind.deg = 10;
            mockWind.speed = 11.5F;

            //MOCK DATA LOGIC BELOW. THIS IS FOR STYLING PURPOSES ONLY
            ApiResultViewModel result = new ApiResultViewModel();
            result.weather = mockList;
            result.main = mockMain;
            result.wind = mockWind;
            result.clouds = mockCloud;
            result.name = "ann arbor";


            if (result.wind.deg >= 348.75 || result.wind.deg <= 11.25)
            {
                result.windDirection = "N";
            }
            else if (result.wind.deg > 11.25 || result.wind.deg <= 33.75)
            {
                result.windDirection = "NNE";
            }
            else if (result.wind.deg > 33.75 || result.wind.deg <= 56.25)
            {
                result.windDirection = "NE";
            }
            else if (result.wind.deg > 56.25 || result.wind.deg <= 78.75)
            {
                result.windDirection = "ENE";
            }
            else if (result.wind.deg > 78.75 || result.wind.deg <= 101.25)
            {
                result.windDirection = "E";
            }
            else if (result.wind.deg > 101.25 || result.wind.deg <= 123.75)
            {
                result.windDirection = "ESE";
            }
            else if (result.wind.deg > 123.75 || result.wind.deg <= 146.25)
            {
                result.windDirection = "SE";
            }
            else if (result.wind.deg > 146.25 || result.wind.deg <= 168.75)
            {
                result.windDirection = "SSE";
            }
            else if (result.wind.deg > 168.75 || result.wind.deg <= 191.25)
            {
                result.windDirection = "S";
            }
            else if (result.wind.deg > 191.25 || result.wind.deg <= 213.75)
            {
                result.windDirection = "SSW";
            }
            else if (result.wind.deg > 213.75 || result.wind.deg <= 236.25)
            {
                result.windDirection = "SW";
            }
            else if (result.wind.deg > 236.25 || result.wind.deg <= 258.75)
            {
                result.windDirection = "WSW";
            }
            else if (result.wind.deg > 258.75 || result.wind.deg <= 281.25)
            {
                result.windDirection = "W";
            }
            else if (result.wind.deg > 281.25 || result.wind.deg <= 303.75)
            {
                result.windDirection = "WNW";
            }
            else if (result.wind.deg > 303.75 || result.wind.deg <= 326.25)
            {
                result.windDirection = "NW";
            }
            else
            {
                result.windDirection = "NNW";
            }


            result.iconUrl = $"http://openweathermap.org/img/w/{result.weather.First().icon}.png";
            return View(result);
        }
    }
}
