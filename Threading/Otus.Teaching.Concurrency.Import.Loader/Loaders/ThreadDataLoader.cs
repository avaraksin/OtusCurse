using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Core.Loaders
{
    /// <summary>
    /// Класс обработки массива записей созданием новых потоков
    /// </summary>
    public class ThreadDataLoader : IDataLoader
    {
        /// <summary>
        /// Число записей обрабатываемых одним потоком
        /// </summary>
        protected int threadCount { get; } = 21000;

        public ThreadDataLoader(int threadCount)
        {
            this.threadCount = threadCount;
        }

        public ThreadDataLoader()
        {}

        /// <summary>
        /// Основной метод загрузки данных
        /// </summary>
        /// <param name="customerList">
        /// массив записей
        /// </param>
        public virtual void LoadData(List<Customer> customerList)
        {
            Console.WriteLine("Loading data by Threads...");

            // Число записей в массиве
            int recCount = customerList.Count;
            
            // Счетчик потоков
            int totalthreadCount = 0;

            for (int i = 1; i <= recCount; i += threadCount)
            {
                totalthreadCount++;
                var thread = new Thread(() =>
                {
                    ThreadLoadData(
                        customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList()
                        );
                });
                thread.Start();
                // Синхронизируем потоки с основным приложением
                thread.Join();
            }
            Console.WriteLine($"Создано потоков: {totalthreadCount}");
            Console.WriteLine("Loaded data by Threads...");
        }

        /// <summary>
        /// Метод потока
        /// virlual - переопределяется в PoolDataLoader
        /// </summary>
        /// <param name="list">
        /// Массив записей
        /// </param>
        protected virtual void ThreadLoadData(object list)
        {
            List<Customer> customerList = (List<Customer>)list;

            var x = new CustomerRepository();
            foreach (var item in customerList)
            {
                x.AddCustomer(item);
            }
        }
    }
}