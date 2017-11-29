using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Recipe
    {

        List<Object> userRecipe = new List<Object>();

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
            Lemon recipeLemon = new Lemon();
            for (int i = 0; i <= lemonsPerPitcher; i ++)
            {
                userRecipe.Add(recipeLemon);
                player.playerStock.Lemons.RemoveAt(0);
            }
        }
        public void AddSugar(Player player)
        {
            Sugar recipeSugar = new Sugar();
            for (int i = 0; i <=sugarPerPitcher; i ++)
            {
                userRecipe.Add(recipeSugar);
                player.playerStock.cupsOfSugar.RemoveAt(0);
            }
        }
        public void AddIceCubes(Player player)
        {
            IceCube recipeIceCube = new IceCube();
            for (int i = 0; i <=cubesPerPitcher; i++)
            {
                userRecipe.Add(recipeIceCube);
                player.playerStock.numberOfCubes.RemoveAt(0);
            }
        }
        public int CreatePitcher(Player player)
        {
            userRecipe.Clear();
            numberOfPitchers++;
            return numberOfPitchers;
            
        }
        public void AddCups(Player player)
        {
            numberOfPitchers--;
            player.playerStock.numberOfCups.RemoveRange(0,19);
            numberOfCupsCreated = 20;
        }
    }
}
