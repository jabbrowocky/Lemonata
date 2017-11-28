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
            playerOne = new Player(35.00, new Inventory(new List<Lemon>(), new List<Sugar>(), new List<Cup>()));
            UI.DisplayTitleLoop(this);                   
            
        }

        //member methods

        public void RunGame(int Days, string name)
        {
            Console.Clear();
            Console.WriteLine(" Let's simulate a lemonade stand {0}!\n", name);
            TodaysWeather = new Weather();
            DisplayPlayerInventory(playerOne);
            OptionsNavigation(DisplayOptions());
            
            
            
            
        }
        
        public void RunStore(Store store)
        {
            Console.Clear();
            store.DisplayStore(playerOne);
            OptionsNavigation(DisplayOptions());

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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n{0}'s Current Stock\n*****************************\n", player.playerName);
            Console.ResetColor();
            Console.WriteLine("Lemons: " + player.playerStock.Lemons.Count);
            Console.WriteLine("Cups of Sugar: " + player.playerStock.cupsOfSugar.Count);
            Console.WriteLine("Paper Cups: " + player.playerStock.numberOfCups.Count);
            Console.WriteLine("\nAvailable Funds: {0:C2}" , player.availableFunds);
            OptionsNavigation(DisplayOptions());

        }
        public void MainScreenDisplay()
        {
            Console.Clear();
            Console.WriteLine("Day: " + dayNumber);
            Console.WriteLine(TodaysWeather.TodaysWeatherType);
            Console.WriteLine(TodaysWeather.TodaysTemp);
            DisplayPlayerInventory(playerOne);
            OptionsNavigation(DisplayOptions());

        }
        
        public string DisplayOptions()
        {
            string userInput = UI.ValidateInput("Press 'm' to return to the Main Screen. 's' to Access the Store Menu. 'p' to view player inventory", new List<string>() { "m","s","p"});
            
            return userInput;
        }
        public void OptionsNavigation(string userInput)
        {
            switch (userInput)
            {
                case "m":
                    MainScreenDisplay();
                    break;
                case "s":
                    RunStore(new Store());
                    break;
                case "p":
                    DisplayPlayerInventory(playerOne);
                    break;
                default:
                    break;

            }
        }
    }
}
