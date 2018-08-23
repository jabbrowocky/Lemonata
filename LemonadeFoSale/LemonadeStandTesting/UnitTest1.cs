using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeFoSale;

namespace LemonadeStandTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateProfit_PositiveIntegers_ForLoss()
        {
            Game testGame = new Game();
            //arrange
            testGame.todaysProfit = 2.50;
            testGame.todaysExpenses = 3.50;

            //act
            double result = testGame.CalculateProfit();
            //assert
            Assert.AreEqual(result, -1.00);
        }
        [TestMethod]
        public void CalculateProfit_PositiveIntegers_ForProfit()
        {
            Game testGame = new Game();
            //arrange
            testGame.todaysProfit = 5.00;
            testGame.todaysExpenses = 1.00;

            //act
            double isProfit = testGame.CalculateProfit();
            //assert
            Assert.AreEqual(isProfit, 4.00);
        }
        [TestMethod]
        public void CreateCustomers_FoggyWeather_MinimumCustomerPopulation()
        {
            //arrange
            Game testGame = new Game();
            testGame.weather.TodaysWeatherType = "Foggy";
            //act
            int customerBase = testGame.CreateCustomers();
            //assert  
            Assert.AreEqual(customerBase, 25);
        }
        [TestMethod]
        public void CreateCustomers_TemperatureLessThan65_MediumCustomerPopulation()
        {
            //arrange
            Game testGame = new Game();
            testGame.weather.TodaysTemp = 64;
            //act
            int customerBase = testGame.CreateCustomers();
            //assert
            Assert.AreEqual(customerBase, 30);
        }
        [TestMethod]
        public void CreateCustomers_TemperatureSixtyFiveOrGreaterWithSunnyWeather_MaxCustomerPopulation()
        {
            //arrange
            Game testGame = new Game();
            testGame.weather.TodaysTemp = 70;
            testGame.weather.TodaysWeatherType = "Sunny";
            //act
            int customerBase = testGame.CreateCustomers();
            //assert
            Assert.AreEqual(customerBase, 50);
        }
       
    }
}