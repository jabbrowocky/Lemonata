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
        public List<Cups> CupsToSell = new List<Cups>();
        public int lemonsPerPitcher;
        public int sugarPerPitcher;
        public int cubesPerPitcher;
        public Cups sellCup = new Cups();
        public List<int> previousRecipeIngredients = new List<int>();
        public int cupsSold;

        public Recipe()
        {
            
        }

        public void GetPreviousRecipe()
        {
            previousRecipeIngredients.Clear();
            previousRecipeIngredients.Add(lemonsPerPitcher);
            previousRecipeIngredients.Add(sugarPerPitcher);
            previousRecipeIngredients.Add(cubesPerPitcher);
        }
        public void DisplayPreviousRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" \n Previous Recipe\n******************\n ");
            Console.ResetColor();
            Console.WriteLine(" Lemons: " + previousRecipeIngredients[0]);
            Console.WriteLine(" Cups of Sugar: " + previousRecipeIngredients[1]);
            Console.WriteLine(" Ice Cubes: " + previousRecipeIngredients[2] + "\n");
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
        public void CreatePitcher()
        {
            
            if (lemonsPerPitcher > 0 && cubesPerPitcher > 0 && sugarPerPitcher > 0)
            {
                GetPreviousRecipe();
                lemonsPerPitcher = 0;
                cubesPerPitcher = 0;
                sugarPerPitcher = 0;
                numberOfPitchers++;
            }
            else
            {
                Console.WriteLine("Can't create a pitcher with no ingredients. Press any key to continue.");
                Console.ReadLine();
            }
            
        }
        public void PopulateSellableCups(int numberOfCupsCreated, double sellPrice)
        {
            
            sellCup.standPrice = sellPrice;
            for (int i = 1; i <= numberOfCupsCreated; i ++)
            {
                CupsToSell.Add(sellCup);
            }
        }
     
        public void AddCups(Player player, double sellPrice)
        {
            
            numberOfPitchers--;            
            if (player.playerStock.numberOfCups.Count < 20)
            {                
                numberOfCupsCreated = player.playerStock.numberOfCups.Count;
                player.playerStock.numberOfCups.Clear();
                PopulateSellableCups(numberOfCupsCreated, sellPrice);
            }            
            else
            {                
                player.playerStock.numberOfCups.RemoveRange(0, 20);
                numberOfCupsCreated = 20;
                PopulateSellableCups(numberOfCupsCreated, sellPrice);
            }
        }
    }
}
