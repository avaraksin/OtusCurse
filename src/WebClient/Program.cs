using System;
using System.Threading.Tasks;

namespace WebClient
{
    static class Program
    {
        static Task Main(string[] args)
        {
            Console.ReadKey();
            return Task.CompletedTask;
        }

        private static CustomerCreateRequest RandomCustomer()
        {
            throw new NotImplementedException();
        }
    }
}