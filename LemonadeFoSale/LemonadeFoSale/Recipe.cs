using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Recipe
    {

        
        public int numberOfCupsCreated = 0;
        public int lemonsPerPitcher;
        public int sugarPerPitcher;
        public int cubesPerPitcher;

        public Recipe()
        {
            
        }


        public void AddLemons(Player player)
        {
            
            for (int i = 0; i <= lemonsPerPitcher; i ++)
            {
                
                player.playerStock.Lemons.RemoveAt(0);
            }
        }
        public void AddSugar(Player player)
        {

        }

    }
}
