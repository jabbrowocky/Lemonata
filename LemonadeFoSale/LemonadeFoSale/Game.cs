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
        int dayNumber;
        public int NumberOfDays;
        Player playerOne;
        



        //constructor
        public Game()
        {
            playerOne = new Player();
            UI.DisplayTitleLoop(this);                   
            
        }

        //member methods

        public void RunGame(int Days, string name)
        {
            Console.Clear();
            Console.WriteLine(" Let's simulate a lemonade stand {0}!\n", name);
            TodaysWeather = new Weather();
            Console.ReadLine();
            
            
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
        
    }
}
