using System;
using System.Linq;

namespace Otus.Generics.Demo
{
    /// <summary>
    /// Базовый класс с коллекцией
    /// </summary>
    /// <typeparam name="T">Тип элемента</typeparam>
    public class MyCollection<T>
    {
        public T[] Values { get; set; }
    }

    public class ColOfNumbers
    : MyCollection<double>
    {
        public double GeomAvg()
        {
            var res = 1.0;
            var numOfValues = Values.Length;
            foreach (var v in Values)
            {
                res *= Math.Pow(v, 1.0 / numOfValues);
            }
            return res;
        }
    }

    public class InheritanceShower : IBaseDemoShower
    {
        interface IData<T>
        {
            public T[] Collection { get; set; }
        }

        interface IFoo<K>
        {
            void Print(K val);
        }


        class Bar1 : IData<int>, IFoo<string>
        {
            public int[] Collection { get; set; }


            public void Print(string val)
            {
                throw new NotImplementedException();
            }
        }


        class Bar2<T, K> : IData<K>, IFoo<K>
        {
            public K[] Collection { get; set; }

            public void Print(K val)
            {
                throw new NotImplementedException();
            }
        }




        public void Show()
        {
            var b1 = new Bar1();
            
            var b2 = new Bar2<bool, DateTime>();



            var con = new ColOfNumbers();
            con.Values = new double[] { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Avg={con.GeomAvg()}");
        }
    }
}