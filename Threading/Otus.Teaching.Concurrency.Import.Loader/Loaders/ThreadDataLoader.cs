using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Loader.Loaders;
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

            List<AutoResetEvent> areList = new List<AutoResetEvent>();

            for (int i = 1; i <= recCount; i += threadCount)
            {
                AutoResetEvent are = new AutoResetEvent(false);
                areList.Add(are);

                totalthreadCount++;
                var p = new ThreadObject()
                        { 
                            customerList = customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList(),
                            are = are
                        };
                var thread = new Thread(x => ThreadLoadData(p));
                thread.Start();
                // Синхронизируем потоки с основным приложением
                //thread.Join();
            }
            Console.WriteLine($"Создано потоков: {totalthreadCount}");

            WaitHandle.WaitAll( areList.ToArray() );
            Console.WriteLine("Loaded data by Threads...");
        }

        /// <summary>
        /// Метод потока
        /// virlual - переопределяется в ProcedureDataLoader
        /// </summary>
        /// <param name="list">
        /// Массив записей
        /// </param>
        protected virtual void ThreadLoadData(object obj)
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