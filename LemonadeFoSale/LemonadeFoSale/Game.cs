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
        Weather weatherType;
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
            Console.WriteLine(" Let's simulate a lemonade stand!");
            
        }
        
        
        public string GetPlayerName()
        {
            Console.WriteLine(" Please enter player name: ");
            playerOne.playerName = Console.ReadLine();
            return playerOne.playerName;
            
        }
        public int SetNumberOfDays()
        {

            int numberOfDays;
            Console.WriteLine(" Please set the number of days (7, 14, or 21)");
            numberOfDays = int.Parse(Console.ReadKey().KeyChar.ToString());
            NumberOfDays = numberOfDays;
            return NumberOfDays;
           
        }
        
    }
}
