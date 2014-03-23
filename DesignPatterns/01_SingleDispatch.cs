using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SingleDispatch
{
    interface IEntityInSpace
    {
        string Describe();
    }

    class SpaceShip : IEntityInSpace {
        public string Describe()
        {
            return "a majestic space ship";
        }
    }

    class Asteroid : IEntityInSpace
    {
        public string Describe()
        {
            return "a small asteroid";
        }
    }


    class Starter
    {
        // "[..] dynamic dispatch is the process of selecting which implementation of a polymorphic operation (method or function) to call at runtime [..]" http://en.wikipedia.org/wiki/Dynamic_dispatch
        static public void Start()
        {
            Console.WriteLine("\nSingleDispatch\n");

            // Single Dispatch
            IEntityInSpace a = new SpaceShip();
            IEntityInSpace b = new Asteroid();

            // C# calls the correct method based on the type of the object before the dot even though the concrete type is unknown during compile time
            Console.WriteLine(a.Describe());
            Console.WriteLine(b.Describe()); 
        }
    }
}
