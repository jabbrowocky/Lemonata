using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Recipe
    {

        

        public int numberOfPitchers = 0;
        public int numberOfCupsCreated = 0;
        public int lemonsPerPitcher;
        public int sugarPerPitcher;
        public int cubesPerPitcher;

        public Recipe()
        {
            
        }


        public void AddLemons(Player player)
        {
            
            for (int i = 0; i < lemonsPerPitcher; i ++)
            {
                
                player.playerStock.Lemons.RemoveAt(0);
            }
        }
        public void AddSugar(Player player)
        {
            
            for (int i = 0; i < sugarPerPitcher; i ++)
            {
                
                player.playerStock.cupsOfSugar.RemoveAt(0);
            }
        }
        public void AddIceCubes(Player player)
        {
            
            for (int i = 0; i < cubesPerPitcher; i++)
            {
                
                player.playerStock.numberOfCubes.RemoveAt(0);
            }
        }
        public int CreatePitcher()
        {
            lemonsPerPitcher = 0;
            cubesPerPitcher = 0;
            sugarPerPitcher = 0;
            numberOfPitchers++;
            return numberOfPitchers;
            
        }
        public void AddCups(Player player)
        {
            numberOfPitchers--;            
            if (player.playerStock.numberOfCups.Count < 20)
            {                
                numberOfCupsCreated = player.playerStock.numberOfCups.Count;
                player.playerStock.numberOfCups.Clear();
            }
            else
            {                
                player.playerStock.numberOfCups.RemoveRange(0, 19);
                numberOfCupsCreated = 20;
            }
        }
    }
}
