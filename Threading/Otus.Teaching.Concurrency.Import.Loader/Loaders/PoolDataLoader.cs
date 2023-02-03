using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    /// <summary>
    /// Обработка массива записей, используя очередь потоков
    /// </summary>
    public class PoolDataLoader : ThreadDataLoader, IDataLoader
    {
        public PoolDataLoader(int threadCount) : base(threadCount)
            { }
        public PoolDataLoader() : base() { }

        public override void LoadData(List<Customer> customerList)
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
                    }
                   );
            }

            // Ждем завершения всех потоков
            WaitHandle.WaitAll(areList.ToArray());

            Console.WriteLine($"Число потоков в очереди: {totalthreadCount}");
            Console.WriteLine("Loading data by ThreadPool...");
        }

        /// <summary>
        /// Переопределяем метод, т.к. передаем ему в качестве параметра класс ThreadObject,
        /// один из полей которого - объект синхронизации are
        /// </summary>
        /// <param name="obj"></param>
        protected override void ThreadLoadData(object obj)
        {
            ThreadObject threadObject = obj as ThreadObject;
            List<Customer> customerList = threadObject.customerList;
            AutoResetEvent autoResetEvent = threadObject.are;

            var x = new CustomerRepository();
            foreach (var item in customerList)
            {
                x.AddCustomer(item);
            }
            // Выставлем объект в несигнальное состояние. Поток завершает работу.
            autoResetEvent.Set();
        }
    }
}
