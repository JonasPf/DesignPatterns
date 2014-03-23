using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDispatchNotWorking
{
    interface IObjectInSpace
    {
    }

    class SpaceShip
    {
        public string Name;

        public string DescribeInteraction(IObjectInSpace other)
        {
            return "the " + Name + " interacts with something. the outcome is unkown.";
        }

        public string DescribeInteraction(Planet other)
        {
            return "this will never get called because C# doesn't support multiple dispatch";
        }

        public string DescribeInteraction(Asteroid other)
        {
            return "this will never get called because C# doesn't support multiple dispatch";
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
        // Multiple dispatch or multimethods is the feature of some object-oriented programming languages in which a function or method can be dynamically dispatched based on the run time (dynamic) type of more than one of its arguments." http://en.wikipedia.org/wiki/Multiple_dispatch
        public static void Start()
        {
            Console.WriteLine("\nMultipleDispatchNotWorking\n");

            SpaceShip ship = new SpaceShip() { Name = "enterprise" };
            IObjectInSpace a = new Planet() { Gravity = 1 };
            IObjectInSpace b = new Planet() { Gravity = 5 };
            IObjectInSpace c = new Asteroid() { Metal = 3 };
            IObjectInSpace d = new Asteroid() { Metal = 2 };

            // The following doesn't work because C# doesn't do automatic dynamic dispathing
            Console.WriteLine(ship.DescribeInteraction(a));
            Console.WriteLine(ship.DescribeInteraction(b));
            Console.WriteLine(ship.DescribeInteraction(c));
            Console.WriteLine(ship.DescribeInteraction(d));

        }
    }
}
