using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class Orders
    {
        public int idOrder { get; set; }
        public int id { get; set; }
        public DateTime dateTime { get; set; }

        public  int clientId { get; set; }
        public Clients clients { get; set; }

        public int productId { get; set; }
        public Products product { get; set; }
    }
}
