using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Game
    {
        //member variables
        public Weather TodaysWeather;
        int dayNumber = 1;
        public int NumberOfDays;
        Player playerOne;
        



        //constructor
        public Game()
        {
            playerOne = new Player(25.00, new Inventory(new List<Lemon>(), new List<Sugar>(), new List<Cup>()));
            UI.DisplayTitleLoop(this);                   
            
        }

        //member methods

        public void RunGame(int Days, string name)
        {
            Console.Clear();
            Console.WriteLine(" Let's simulate a lemonade stand {0}!\n", name);
            TodaysWeather = new Weather();
            DisplayPlayerInventory(playerOne);
            OptionsNavigation(DisplayOptions("To access store, press 's'.", new List<string> { "s" }));




        }
        
        public void RunStore(Store store)
        {
            Console.Clear();            
            Console.Write("\n");
            store.DisplayStore(playerOne);
            OptionsNavigation(DisplayOptions("To return to store, press 's' and to return to main screen press 'm'.", new List<string> { "m","s" }));
        }
        
        
        public string GetPlayerName()
        {
            Console.WriteLine("\n Please enter player name: \n");
            playerOne.playerName = Console.ReadLine();
            return playerOne.playerName;
            
        }
        public int SetNumberOfDays()
        {

            int numberOfDays;                      
            numberOfDays = int.Parse(UI.ValidateInput("\n Please set the number of days (7, 14, or 21)" , new List<string>() {"7","14","21" }));
            NumberOfDays = numberOfDays;
            
            return NumberOfDays;

           
        }

        public void DisplayPlayerInventory(Player player)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n{0}'s Current Stock\n*****************************\n", player.playerName);
            Console.ResetColor();
            Console.WriteLine("Lemons: " + player.playerStock.Lemons.Count);
            Console.WriteLine("Cups of Sugar: " + player.playerStock.cupsOfSugar.Count);
            Console.WriteLine("Paper Cups: " + player.playerStock.numberOfCups.Count);
            Console.WriteLine("\nAvailable Funds: {0:C2}" , Math.Round(player.availableFunds,2));
            

        }
        public void MainScreenDisplay()
        {
            Console.Clear();
            DisplayDayInformation();
            DisplayPlayerInventory(playerOne);
            OptionsNavigation(DisplayOptions("To access store, press 's'.", new List<string> { "s" }));

        }
        public void DisplayDayInformation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Day to Day information:\n****************************");
            Console.ResetColor();
            Console.WriteLine("Day number: " + dayNumber);
            Console.WriteLine("Today's weather : {0}", TodaysWeather.TodaysWeatherType);
            Console.WriteLine("Today's temperature: {0}°", TodaysWeather.TodaysTemp);
        }
        
        public string DisplayOptions(string instructions, List<string>validInputs)
        {
            string userInput = UI.ValidateInput(instructions, validInputs);
            
            return userInput;
        }
        public void OptionsNavigation(string userInput)
        {
            switch (userInput)
            {
                case "m":
                    Console.Clear();
                    MainScreenDisplay();
                    break;
                case "s":
                    Console.Clear();
                    RunStore(new Store());
                    break;                
                default:
                    break;

            }
        }
    }
}
