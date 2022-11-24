using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class Users : UserBase
    {
        public string? firstName { get; set; }

        public void PrintMe()
        {
            Console.WriteLine("id\t\tИмя");
            Console.WriteLine($"{Id}\t\t{firstName}");
        }
    }
}
