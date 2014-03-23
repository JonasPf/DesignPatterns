using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDispatchInheritance
{
    class GenericSpaceShip
    {
        public void Visit(GenericPlanet planet)
        {
            Console.WriteLine("Generic");
        }
    }

    class SpaceShip : GenericSpaceShip
    {
        public void Visit(Planet planet)
        {
            Console.WriteLine("Specific");
        }
    }

    class GenericPlanet { }

    class Planet : GenericPlanet { }

    class Starter
    {
        public static void Start()
        {
            Console.WriteLine("\nSingleDispatchWithInheritance\n");

            SpaceShip ship = new SpaceShip();
            Planet planet = new Planet();

            ((GenericSpaceShip) ship).Visit(planet); // => Generic
            ship.Visit(planet); // => Specific
        }
    }
}

