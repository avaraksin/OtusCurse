using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public class FakeDataLoader : IDataLoader
    {
        public void LoadData(List<Customer> customerList)
        {
            Console.WriteLine("Loading data...");

            var context = new Otus.Teaching.Concurrency.Import.DataAccess.Repositories.AppContext();
            
            foreach (var item in customerList)
            {
                var x = new CustomerRepository();
                x.context = context;
                x.AddCustomer(item);
            }
            
            Console.WriteLine("Loaded data...");
        }
    }
}