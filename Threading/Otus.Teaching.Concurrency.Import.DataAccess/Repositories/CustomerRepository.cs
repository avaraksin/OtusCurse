using System;
using System.Linq;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class CustomerRepository
        : ICustomerRepository
    { 
        public void AddCustomer(Customer customer)
        {
            var context = SqliteContext.GetInstance();
            context.customers.Add(customer);
            context.SaveChanges();
        }
    }
}