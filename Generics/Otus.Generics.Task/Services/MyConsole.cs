using System;

namespace Otus.Generics.Task.Services
{
    public static class MyConsole
    {
        public static void WriteLine(string s)
        {
            Console.WriteLine();
            Console.WriteLine("======================================");
            Console.WriteLine(s);
            Console.WriteLine("======================================");
            Console.WriteLine();
        }
    }
}