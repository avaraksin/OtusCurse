using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public class FakeDataLoader : IDataLoader
    {
        public void LoadData(List<Customer> customerList)
        {
            Console.WriteLine("Loading data...");

            int recCount = customerList.Count;

            List<Customer> minList = customerList.Where(x => x.Id < recCount / 2).ToList();
            var thread1 = new Thread(() =>
                {
                    TreadLoadData(minList);
                });
            

            var maxList = customerList.Where(x => x.Id >= (int)(recCount / 2)).ToList();
            var thread2 = new Thread(() => { TreadLoadData(maxList); });
            
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            
            Console.WriteLine("Loaded data...");
        }

        private void TreadLoadData(List<Customer> customerList)
        {
            var x = new CustomerRepository();
            foreach (var item in customerList)
            {
                x.AddCustomer(item);
            }
        }
    }
}