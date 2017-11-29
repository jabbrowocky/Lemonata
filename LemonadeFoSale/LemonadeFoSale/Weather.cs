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
        public string TomorrowsWeatherTypeForcast;
        public int TomorrowsTemperatureForcast;
        

        //constructor
        public Weather()
        {
            GetTodaysWeather();
            GetTemperature();
            GetTomorrowsForcastWeatherType(TodaysWeatherType);
            GetTomorrowsTemperatureForcast(TodaysTemp);
            DisplayTomorrowsForcast();           
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
        public string GetTomorrowsForcastWeatherType(string TodaysWeatherType)
        {
            List<string> ForcastTypes = new List<string>() { "Sunny", "Rainy", "Overcast", "Foggy" };
            ForcastTypes.Add(TodaysWeatherType);
            ForcastTypes.Add(TodaysWeatherType);
            TomorrowsWeatherTypeForcast = ForcastTypes[Weatherselector.Next(5)];
            return TomorrowsWeatherTypeForcast;
        }

        public int GetTomorrowsTemperatureForcast(int TodaysTemp)
        {
            int tomorrowMaxRange = TodaysTemp + 8;
            int tomorrowMinRange = TodaysTemp - 7;
            TomorrowsTemperatureForcast = TemperatureRange.Next(tomorrowMinRange, tomorrowMaxRange);
            return TomorrowsTemperatureForcast;       
        }
        public void DisplayTomorrowsForcast()
        {
            Console.WriteLine("Tomorrow's weather forcast: {0} and {1}°", TomorrowsWeatherTypeForcast, TomorrowsTemperatureForcast);
        }
    }
    

}
