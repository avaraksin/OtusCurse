using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class Products
    {
        public int id { get; set; }
        public string productName { get; set; } = string.Empty;

        public Products(int id, string productName)
        {
            this.id = id;
            this.productName = productName;
        }
    }
}
