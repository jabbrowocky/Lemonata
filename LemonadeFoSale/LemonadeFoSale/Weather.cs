using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Weather
    {
        //member variables
        List<string> WeatherTypes = new List<string>() { "Sunny", "Rainy", "Overcast", "Foggy" };
        public Random TemperatureRange = new Random();
        public Random Weatherselector = new Random();
        public string TodaysWeatherType;
        public int TodaysTemp;

        //constructor
        public Weather()
        {
            GetTodaysWeather();
            GetTemperature();

        }

        //member methods
        public string GetTodaysWeather()
        {
            TodaysWeatherType = WeatherTypes[Weatherselector.Next(4)];
            Console.WriteLine("Today's weather is {0}", TodaysWeatherType);
            return TodaysWeatherType;
        }

        public int GetTemperature()
        {
            TodaysTemp = TemperatureRange.Next(50, 90);
            Console.WriteLine("Today's temperature is {0}°", TodaysTemp);
            return TodaysTemp;
                  
        }

    }
    

}
