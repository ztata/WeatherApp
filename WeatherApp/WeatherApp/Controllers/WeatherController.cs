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


        //ADD ZIP SEARCH OPTION LATER ON 
        //take out some of these tasks and add them to a static api call class or something 
        public IActionResult SearchResult(string searchTerm)
        {
            //initialize object to pass to the view 
            ApiResultViewModel result = new ApiResultViewModel();

            //get api key from appsetting.json and get URI
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var apiKey = configuration.GetValue<string>("ApiKeys:OpenweatherApiKey");
            string geocodingApiUri = $"http://api.openweathermap.org/geo/1.0/direct?q={searchTerm}&limit=1&appid={apiKey}";


            //call geocoding api to get lat and long
            var geocodingApiTask = geocodingApiUri.GetJsonAsync<GeocodingApiResultModel>();
            geocodingApiTask.Wait();

            float lat = geocodingApiTask.Result.cities.First().lat;
            float lon = geocodingApiTask.Result.cities.First().lon;
            result.countryCode = geocodingApiTask.Result.cities.First().country;

            //call current weather api to get current weather conditions and save to current weather view model 
            string currentWeatherApiUri = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=imperial";
            var currentWeatherApiTask = currentWeatherApiUri.GetJsonAsync<ApiResultViewModel>();
            currentWeatherApiTask.Wait();

            result.coord = currentWeatherApiTask.Result.coord;
            result.weather = currentWeatherApiTask.Result.weather;
            result.main = currentWeatherApiTask.Result.main;
            result.visibility = currentWeatherApiTask.Result.visibility;
            result.wind = currentWeatherApiTask.Result.wind;
            result.clouds = currentWeatherApiTask.Result.clouds;
            result.dt = currentWeatherApiTask.Result.dt;
            result.sys = currentWeatherApiTask.Result.sys;
            result.timezone = currentWeatherApiTask.Result.timezone;
            result.name = currentWeatherApiTask.Result.name;
            result.cod = currentWeatherApiTask.Result.cod;
            result.iconUrl = $"http://openweathermap.org/img/w/{currentWeatherApiTask.Result.weather.First().icon}.png";

            //call forecast api to get forecast data and save to current weather view model 
            string forecastApiUri = $"https://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={apiKey}&units=imperial";
            var forecastApiTask = forecastApiUri.GetJsonAsync<ForecastApiResultModel>();
            forecastApiTask.Wait();

            result.forecast = forecastApiTask.Result;

            //return the view passing in the view model 
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


            //Mock Data Logic Below for apiresultviewmodel

            //Weather mockWeather = new Weather();
            //mockWeather.main = "clouds";
            //mockWeather.description = "broken clouds";
            //mockWeather.icon = "04d";
            //List<Weather> mockList = new List<Weather>();
            //mockList.Add(mockWeather);

            //Main mockMain = new Main();
            //mockMain.temp = 83.25F;
            //mockMain.feels_like = 78.85F;
            //mockMain.pressure = 1022;
            //mockMain.humidity = 46;

            //Cloud mockCloud = new Cloud();
            //mockCloud.all = 100;

            //Wind mockWind = new Wind();
            //mockWind.deg = 10;
            //mockWind.speed = 11.5F;


            //ApiResultViewModel result = new ApiResultViewModel();
            //result.weather = mockList;
            //result.main = mockMain;
            //result.wind = mockWind;
            //result.clouds = mockCloud;
            //result.name = "ann arbor";            
        }
    }
}
