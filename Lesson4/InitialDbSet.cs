using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class InitialDbSet
    {
        private readonly string _connetionString;

        public InitialDbSet(string connetionString)
        {
            _connetionString = connetionString;
        }

        public Task CreateTables()
        {
            using (var conn = new SqlConnection(_connetionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                command.CommandText = @"IF OBJECT_ID('Clients') IS NULL
                      BEGIN
                          CREATE TABLE Clients (id INT NOT NULL, firstName VARCHAR(1000)); 
                          ALTER TABLE Clients ADD CONSTRAINT PK_Clients PRIMARY KEY (id); 
                      END;";
                command.ExecuteNonQuery();

                command.CommandText = @"IF OBJECT_ID('Orders') IS NULL
                      BEGIN
                          CREATE TABLE Orders (idOrder INT NOT NULL, id INT NOT NULL, orderDateTime DATE, clientId INT, productId INT); 
                          ALTER TABLE Orders ADD CONSTRAINT PK_Orders PRIMARY KEY (idOrder, id); 
                      END;";
                command.ExecuteNonQuery();

                command.CommandText = @"IF OBJECT_ID('Products') IS NULL
                      BEGIN
                          CREATE TABLE Products (id INT NOT NULL, productName VARCHAR(1000), clienntId INT, productId INT); 
                          ALTER TABLE Products ADD CONSTRAINT PK_Products PRIMARY KEY (id); 
                      END;";
                command.ExecuteNonQuery();
            }
            return Task.CompletedTask;
        }

        public Task InitialFillTables()
        {
            using (AppDBContext context = new AppDBContext(_connetionString))
            {
                if (context.clients.Count() > 0)
                {
                    var clients = context.clients.ToList();
                    foreach (var client in clients)
                    {
                        context.clients.Remove(client);
                    }
                }
                if (context.products.Count() > 0)
                {
                    var products = context.products.ToList();
                    foreach (var product in products)
                    {
                        context.products.Remove(product);
                    }
                }
                if (context.orders.Count() > 0)
                {
                    var orders = context.orders.ToList();
                    foreach (var order in orders)
                    {
                        context.orders.Remove(order);
                    }
                }
                context.SaveChanges();

                var i = 1;
                context.clients.Add(new Clients(i++, "Ivanov"));
                context.clients.Add(new Clients(i++, "Petrov"));
                context.clients.Add(new Clients(i++, "Belov"));
                context.clients.Add(new Clients(i++, "Smirnov"));
                context.clients.Add(new Clients(i++, "Temnov"));

                i = 1;
                context.products.Add(new Products(i++, "Шоколад"));
                context.products.Add(new Products(i++, "Конфеты"));
                context.products.Add(new Products(i++, "Печенье"));
                context.products.Add(new Products(i++, "Халва"));
                context.products.Add(new Products(i++, "Сок"));

                context.orders.Add(new Orders()
                {
                    idOrder = 1,
                    id = 1,
                    clientId = 1,
                    productId = 2,
                    orderDateTime = DateTime.Now
                });

                context.orders.Add(new Orders()
                {
                    idOrder = 1,
                    id = 2,
                    clientId = 1,
                    productId = 3,
                    orderDateTime = DateTime.Now
                });

                context.orders.Add(new Orders()
                {
                    idOrder = 1,
                    id = 3,
                    clientId = 1,
                    productId = 5,
                    orderDateTime = DateTime.Now
                });

                context.orders.Add(new Orders()
                {
                    idOrder = 2,
                    id = 1,
                    clientId = 3,
                    productId = 1,
                    orderDateTime = DateTime.Now
                });

                context.orders.Add(new Orders()
                {
                    idOrder = 2,
                    id = 2,
                    clientId = 3,
                    productId = 5,
                    orderDateTime = DateTime.Now
                });

                context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
