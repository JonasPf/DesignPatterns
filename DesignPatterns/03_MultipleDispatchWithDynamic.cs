using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDispatchWithDynamic
{
    interface IObjectInSpace
    {
    }

    class SpaceShip
    {
        public string Name;

        public string DescribeInteraction(IObjectInSpace other)
        {
            // The following does work because the dynamic type gets resolved during runtime
            return this.DescribeInteraction((dynamic)other);
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

    class UnknownObject : IObjectInSpace
    {
    }


    class Starter
    {
        public static void Start()
        {
            Console.WriteLine("\nMultipleDispatchWithDynamic\n");

            SpaceShip ship = new SpaceShip() { Name = "enterprise" } ;
            IObjectInSpace a = new Planet() { Gravity = 1 };
            IObjectInSpace b = new Planet() { Gravity = 5 };
            IObjectInSpace c = new Asteroid() { Metal = 3 };
            IObjectInSpace d = new Asteroid() { Metal = 2 };

            Console.WriteLine(ship.DescribeInteraction(a));
            Console.WriteLine(ship.DescribeInteraction(b));
            Console.WriteLine(ship.DescribeInteraction(c));
            Console.WriteLine(ship.DescribeInteraction(d));

            // Downside: This would result in a StackOverflow because there is no method for UnknownObject
            // Console.WriteLine(ship.DescribeInteraction(new UnknownObject()));

        }
    }
}
