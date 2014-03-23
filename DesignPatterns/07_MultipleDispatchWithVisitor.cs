using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDispatchWithVisitor
{
    interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    interface IVisitor
    {
        void Visit(Asteroid visitable);

        void Visit(Planet visitable);
    }

    class SpaceShip : IVisitor
    {
        public string Name;

        public void Visit(Asteroid asteroid)
        {
            Console.WriteLine("the " + this.Name + " mines " + asteroid.Metal + " tons of metal from an asteroid");
        }

        public void Visit(Planet planet)
        {
            // We know we have a SpaceShip and we know this is a Planet
            if (planet.Gravity > 3)
            {
                Console.WriteLine("due to high gravity, the " + this.Name + " crashes into a planet");
            }
            else
            {
                Console.WriteLine("the " + this.Name + " lands safely on this wonderful planet");
            }
        }
    }

    class Asteroid : IVisitable
    {
        public int Metal;

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Planet : IVisitable
    {
        public int Gravity;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Starter
    {
        public static void Start()
        {
            Console.WriteLine("\nMultipleDispatchWithVisitor\n");

            SpaceShip ship = new SpaceShip() { Name = "enterprise" };
            IVisitable a = new Planet() { Gravity = 1 };
            IVisitable b = new Planet() { Gravity = 5 };
            IVisitable c = new Asteroid() { Metal = 3 };
            IVisitable d = new Asteroid() { Metal = 2 };

            a.Accept(ship);
            b.Accept(ship);
            c.Accept(ship);
            d.Accept(ship);

            // Functionality extracted from visitable to visitor. It would be easy to
            // add new visitors.

            // Downside:
            // - Boilerplate code in visitable
            // - Tight coupling between visitor and visitable
            // - With every new visitable all visitors need to be amended
        }
    }
}

