using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    /// <summary>
    /// Обработка массива записей, используя очередь потоков
    /// </summary>
    public class PoolDataLoader : ThreadDataLoader, IDataLoader
    {
        public PoolDataLoader(IServiceScopeFactory serviceProvider) : base(serviceProvider)
        {}

        public override void LoadData(List<ThreadCustomer> customerList)
        {
            int recCount = customerList.Count;

            Console.WriteLine("Loading data by ThreadPool...");

            List<AutoResetEvent> areList = new List<AutoResetEvent>();
            int totalthreadCount = 0;

            for (int i = 1; i <= recCount; i += threadCount)
            {
                totalthreadCount++;

                AutoResetEvent are = new AutoResetEvent(false);
                areList.Add(are);

                ThreadPool.QueueUserWorkItem(
                    ThreadLoadData,
                    new ThreadObject
                    {
                        customerList = customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList(),
                        are = are
                    });
            }

            // Ждем завершения всех потоков
            WaitHandle.WaitAll(areList.ToArray());

            Console.WriteLine($"Число потоков в очереди: {totalthreadCount}");
            Console.WriteLine("Loading data by ThreadPool...");
        }

        // Используем ThreadDataLoader из базового класса
    }
}
