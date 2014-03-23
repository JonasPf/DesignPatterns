using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDispatchWithDoubleDispatch
{
    interface IObjectInSpace
    {
        string DescribeInteractionWithSpaceShip(SpaceShip ship);
    }

    class SpaceShip
    {
        public string Name;

        public string DescribeInteraction(IObjectInSpace other)
        {
            // At this stage we don't know what other is but we know that this is a SpaceShip
            return other.DescribeInteractionWithSpaceShip(this);
        }
    }

    class Asteroid : IObjectInSpace
    {
        public int Metal;

        public string DescribeInteractionWithSpaceShip(SpaceShip ship)
        {
            // We know we have a SpaceShip and we know this is an Asteroid
            return "the " + ship.Name + " mines " + Metal + " tons of metal from an asteroid";
        }
    }

    class Planet : IObjectInSpace
    {
        public int Gravity;

        public string DescribeInteractionWithSpaceShip(SpaceShip ship)
        {
            // We know we have a SpaceShip and we know this is a Planet
            if (Gravity > 3)
            {
                return "due to high gravity, the " + ship.Name + " crashes into a planet";
            }
            else
            {
                return "the " + ship.Name + " lands safely on this wonderful planet";
            }
        }
    }

    class Starter
    {
        public static void Start()
        {
            Console.WriteLine("\nMultipleDispatchWithDoubleDispatch\n");

            SpaceShip ship = new SpaceShip() { Name = "enterprise" };
            IObjectInSpace a = new Planet() { Gravity = 1 };
            IObjectInSpace b = new Planet() { Gravity = 5 };
            IObjectInSpace c = new Asteroid() { Metal = 3 };
            IObjectInSpace d = new Asteroid() { Metal = 2 };

            Console.WriteLine(ship.DescribeInteraction(a));
            Console.WriteLine(ship.DescribeInteraction(b));
            Console.WriteLine(ship.DescribeInteraction(c));
            Console.WriteLine(ship.DescribeInteraction(d));

            // Downside: IObjectInSpace and the SpaceShip are tightly coupled. Both need to know about each other.
            // If we want to introduce a different SpaceShip (e.g. a bigger one that can handle high gravity
            // better, we would need to add methods to all IObjectInSpace classes. This violates the open/close
            // principle and it gets worse the more IObjectInSpace we have.
        }
    }
}

