using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeFoSale
{
    public class Inventory
    {
        //member variables
        public List<Lemon> Lemons;
        public List<Sugar> cupsOfSugar;
        public List<Cups> numberOfCups;
        public List<IceCube> numberOfCubes;

        //constructor
        public Inventory(List<Lemon>Lemons, List<Sugar>cupsOfSugar, List<Cups> numberOfCups, List<IceCube>numberOfCubes)
        {
            this.Lemons = Lemons;
            this.cupsOfSugar = cupsOfSugar;
            this.numberOfCups = numberOfCups;
            this.numberOfCubes = numberOfCubes;
        }

        //member methods
        
    }
}
