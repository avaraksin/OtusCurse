using System;
using System.Collections.Generic;

namespace Otus.Generics.Demo
{
    interface ICoVar<out T> { }

    class CoVar<T> : ICoVar<T> { }


    class Vehicle
    {
        public virtual void Go()
        {
            Console.WriteLine("CAR");
        }
    }

    class Automobile : Vehicle
    {
        public override void Go()
        {
            Console.WriteLine("I'm foo");
        }
    }

    class SuperAuto : Automobile { }

    public class CoContrVarShower : IBaseDemoShower
    {


        private void DemonstrateContrVar(IContrVar<Vehicle> vs)
        {
            Console.WriteLine($"{vs}");
        }


        interface IDemo<out T>
        {
            void Print();

        }

        class ClassDemo<T> : IDemo<T>
        {
            public void Print()
            {
                Console.WriteLine($"I work with {typeof(T)}");
            }
        }

        public void Show()
        {
            Automobile a = new Automobile();
            Vehicle b = new Vehicle();

            // Так можно
            b = a;



            IDemo<Automobile> demoA = new ClassDemo<Automobile>();
            IDemo<Vehicle> demoB = new ClassDemo<Vehicle>();

            // а так - нельзя
            demoB = demoA;



            ICoVar<SuperAuto> auto = new CoVar<SuperAuto>();
            ICoVar<Vehicle> vec = new CoVar<Vehicle>();

            //// Теперь можно приводить Automobile к Vehicle
            vec = auto;

            IContrVar<Automobile> autocontr = new ContrVar<Vehicle>();

            autocontr.Build(new Automobile());

        }
    }







    interface IContrVar<in T>
    {
        void Build(T v);
    }

    class ContrVar<T> : IContrVar<T>
        where T : Vehicle
    {
        public void Build(T v)
        {
            Console.WriteLine($"I'm typeof {typeof(T)}");
            v.Go();
        }
    }



}