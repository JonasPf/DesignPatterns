using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDispatchWithSwitchCase
{
    interface IObjectInSpace
    {
    }

    class SpaceShip
    {
        public string Name;

        public string DescribeInteraction(IObjectInSpace other)
        {
            // Use if/else and instanceof to avoid hardcoded class names
            switch (other.GetType().ToString())
            {
                case "Planet":
                    return DescribeInteraction((Planet)other);
                case "Asteroid":
                    return DescribeInteraction((Asteroid)other);
                default:
                    return "the " + Name + " interacts with something. the outcome is unkown.";

            }
        }

        public string DescribeInteraction(Planet other)
        {
            if (other.Gravity > 3)
            {
                return "due to high gravity, the " + Name + " crashes into a planet";
            }
            else
            {
                return "the " + Name + " lands safely on this wonderful planet";
            }
        }

        public string DescribeInteraction(Asteroid other)
        {
            return "the " + Name + " mines " + other.Metal + " tons of metal from an asteroid";
        }
    }

    class Asteroid : IObjectInSpace
    {
        public int Metal;
    }

    class Planet : IObjectInSpace
    {
        public int Gravity;
    }

    class Starter
    {
        public static void Start()
        {
            Console.WriteLine("\nMultipleDispatchWithSwitchCase\n");

            SpaceShip ship = new SpaceShip() { Name = "enterprise" } ;
            IObjectInSpace a = new Planet() { Gravity = 1 };
            IObjectInSpace b = new Planet() { Gravity = 5 };
            IObjectInSpace c = new Asteroid() { Metal = 3 };
            IObjectInSpace d = new Asteroid() { Metal = 2 };

            Console.WriteLine(ship.DescribeInteraction(a));
            Console.WriteLine(ship.DescribeInteraction(b));
            Console.WriteLine(ship.DescribeInteraction(c));
            Console.WriteLine(ship.DescribeInteraction(d));

            // Downside: Whenever a new IObjectInSpace gets introduced a new case statement must be added to the SpaceShip
            // class. This violates the open/close principle and it gets worse if we have differnt types of SpaceShips
        }
    }
}
