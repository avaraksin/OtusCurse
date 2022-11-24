using System;
using System.Threading.Tasks;

namespace WebClient
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            int id;
            while (true)
            {
                Console.WriteLine("1. Вывод данных о клиенте");
                Console.Write("Укажите id клиента: ");
                string answer;
                do
                {
                    answer = Console.ReadLine();
                }
                while (int.TryParse(answer, out id) == false);
                
                var response = new UserCreateRequest();
                await response.GetUser(id);
                Console.WriteLine();

                Console.WriteLine("2. Сохранение случайно сгенерированного клиента");
                var user = new Users()
                {
                    Id = new Random().Next(1, 20),
                    firstName = $"Клиент {new Random().Next(1, 20)}"
                };
                Console.WriteLine("Случайный клиент:");
                user.PrintMe();

                await response.AddUser(user);
                Console.WriteLine();

                Console.Write("Продолжить? ");
                answer = Console.ReadLine();

                if (answer.ToLower()!= "y")
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}