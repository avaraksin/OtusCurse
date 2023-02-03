using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    public class PoolDataLoader : TreadDataLoader, IDataLoader
    {
        public PoolDataLoader(int threadCount) : base(threadCount)
            { }
        public PoolDataLoader() : base() { }

        public override void LoadData(List<Customer> customerList)
        {
            int recCount = customerList.Count;

            Console.WriteLine("Loading data by ThreadPool...");

            for (int i = 1; i < recCount; i += threadCount)
            {
                //List<Customer> customers = customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList();
                ThreadPool.QueueUserWorkItem(ThreadLoadData,
                    customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList()
                    );
            }

            Console.WriteLine("Loading data by ThreadPool...");
        }
    }
}
