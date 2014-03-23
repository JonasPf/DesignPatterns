using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDispatchWithReflection
{




    interface IObjectInSpace
    {
    }

    class SpaceShip
    {
        public string Name;

        public string DescribeInteraction<T>(T other) where T : IObjectInSpace
        {
            // This could be much more complex if we want to take into account multiple parameters and/or return type
            var method = from m in GetType().GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)
                         where m.Name == "DescribeInteraction"
                               && m.GetParameters().Length == 1
                               && m.GetParameters()[0].ParameterType == other.GetType()
                         select m;

            return (string) method.Single().Invoke(this, new object[] { other });
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
            Console.WriteLine("\nMultipleDispatchWithReflection\n");

            SpaceShip ship = new SpaceShip() { Name = "enterprise" } ;
            IObjectInSpace a = new Planet() { Gravity = 1 };
            IObjectInSpace b = new Planet() { Gravity = 5 };
            IObjectInSpace c = new Asteroid() { Metal = 3 };
            IObjectInSpace d = new Asteroid() { Metal = 2 };

            Console.WriteLine(ship.DescribeInteraction(a));
            Console.WriteLine(ship.DescribeInteraction(b));
            Console.WriteLine(ship.DescribeInteraction(c));
            Console.WriteLine(ship.DescribeInteraction(d));

            // Downside: Reflection is very slow + easy to get edge cases wrong
        }
    }
}
