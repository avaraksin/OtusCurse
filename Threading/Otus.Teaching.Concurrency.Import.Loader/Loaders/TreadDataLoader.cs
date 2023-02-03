using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    public class TreadDataLoader : IDataLoader
    {
        protected int threadCount { get; private set; } = 21000;

        public TreadDataLoader(int threadCount)
        {
            this.threadCount = threadCount;
        }

        public TreadDataLoader()
        {}

        public virtual void LoadData(List<Customer> customerList)
        {
            
            Console.WriteLine("Loading data by Threads...");

            int recCount = customerList.Count;

            for (int i = 1; i <= recCount; i += threadCount)
            {
                var thread = new Thread(() =>
                {
                    ThreadLoadData(
                        customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList()
                        );
                });
                thread.Start();
                thread.Join();
            }
            
            Console.WriteLine("Loaded data by Threads...");
        }

        protected void ThreadLoadData(object list)
        {
            List<Customer> customerList = (List<Customer>)list;
            Console.WriteLine(customerList.Count);

            var x = new CustomerRepository();
            foreach (var item in customerList)
            {
                x.AddCustomer(item);
            }
        }
    }
}