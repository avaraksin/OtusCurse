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
                        
            foreach (var item in customerList)
            {
                var x = new CustomerRepository();
                x.AddCustomer(item);
            }
            
            Console.WriteLine("Loaded data...");
        }
    }
}