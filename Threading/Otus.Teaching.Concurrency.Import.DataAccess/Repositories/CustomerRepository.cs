using System;
using System.Linq;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class CustomerRepository
        : ICustomerRepository
    {
        public AppContext context { get; set; }
        public void AddCustomer(Customer customer)
        {            
            context.customers.Add(customer);
            context.SaveChanges();

            Console.WriteLine($"Count: {context.customers.Count()}");
        }
    }
}