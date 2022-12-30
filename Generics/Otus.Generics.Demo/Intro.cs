using System;
using System.Collections.Generic;

namespace Otus.Generics.Demo
{
    public class Intro<T>
    {
        private T val;

        public Intro(T v)
        => val = v;

        public void PrintMe()
        => Console.WriteLine($"I'm '{val}' and my type is '{typeof(T)}'");

        public void PrintMeType<K>(K v)
        => Console.WriteLine($"2. I'm '{v}' and my type is '{v.GetType()}'");
    }

    public class IntroShower : IBaseDemoShower
    {
        public void Show()
        {
         

            // При создании объекта - указываем тип в '<>'
            var intIntro = new Intro<int>(2);

            intIntro.PrintMe();

            var stringIntro = new Intro<string>("hello");
            stringIntro.PrintMe();

            Console.WriteLine();

            stringIntro.PrintMeType(2.0);

            // Можем явно указывать тип
            stringIntro.PrintMeType<bool>(false);

            // Если тип выводится - может тип <bool> не указывать
            stringIntro.PrintMeType(false);


            Console.WriteLine();


            // Перечисления тоже разделяются по типам
            stringIntro.PrintMeType(E1.A);
            stringIntro.PrintMeType(E2.A);
        }
    }
    enum E1
    {
        A = 1
    }


    enum E2
    {
        A = 2,
    }
}