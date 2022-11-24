using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    /// <summary>
    /// Образ таблицы пользователеей (Clients)
    /// </summary>
    public class Users : UserBase
    {
        public string? firstName { get; set; }

        public void PrintMe()
        {
            Console.WriteLine("id\tИмя");
            Console.WriteLine($"{Id}\t{firstName}");
        }
    }
}
