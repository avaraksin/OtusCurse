using System;

namespace Otus.Generics.Demo
{


    class EmptyConstructor
    {
        public EmptyConstructor(int a)
        {

        }

        public EmptyConstructor()
        {

        }

        public override string ToString()
        {
            return "I'm Empty";

        }
    }

    /// <summary>
    /// Класс без конструктора без параметров 
    /// </summary>
    class FullConstructor
    {
        private int _a;

        public FullConstructor()
        {
            _a = -1;
        }

        public FullConstructor(int a)
        {

        }

        public override string ToString()
        {
            return $"{{ _a: {_a}}}";
        }
    }

    /// <summary>
    /// Ограничение с конструктором
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NewConstraint<T> where T : new()
    {
        public NewConstraint()
        {
            var v = new T();
            Console.WriteLine($"Hello {v}");
        }

        public void Do<K>() where K : new()
        {
            var v = new K();
            Console.WriteLine($"DO {v}");
        }
    }


    // Два обобщенных типа TKey и TValue
    class ConstraintKeyValue<TKey, TValue>
      where TKey : struct
      where TValue : class
    {
        public ConstraintKeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public override string ToString()
        => $"Key={Key}, Value={Value}";
    }


    // Т - только value type (int, bool, DateTime, структура)
    public class StructConstraint<T> where T : struct
    {
        public bool AreEqual(T a, T b)
        {
            return a.Equals(b);
        }
    }



    interface IVehicle
    {
        void Start();
        void Go();
    }
    class Auto : IVehicle
    {
        public void Go()
        => Console.WriteLine("Vrum!");

        public void Start()
        => Console.WriteLine("Vruuuuuuuum!");
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TV"></typeparam>
    class Rider<TV> where TV : IVehicle
    {
        public void RideAVehicle(TV vehicle)
        {
            vehicle.Start();
            vehicle.Go();
        }
    }


    public class ConstraintsShower : IBaseDemoShower
    {
        public void Show()
        {

            // Можно
            var asInt = new StructConstraint<int>();

            // Ошибка компиляции
            var asString = new StructConstraint<int>();


            var auto = new Auto();
            var rider = new Rider<Auto>();
            rider.RideAVehicle(auto);

            var nc = new NewConstraint<FullConstructor>();


            var kv1 = new ConstraintKeyValue<int, string>(1, "KV1");
            var kv2 = new ConstraintKeyValue<DateTime, string>(DateTime.Now, "KV2");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"kv1={kv1} kv2={kv2}");
            Console.WriteLine();


        }
    }


}