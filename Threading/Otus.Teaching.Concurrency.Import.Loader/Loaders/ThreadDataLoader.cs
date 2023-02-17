using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;
using Otus.Teaching.Concurrency.Import.Loader.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        public int threadCount { get; set; } = 2500;

        protected readonly ICustomerRepository _customerRepository;

        public ThreadDataLoader(IServiceScopeFactory serviceProvider)
        {
            //_customerRepository = customerRepository;
            _customerRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICustomerRepository>();
        }

       
        /// <summary>
        /// Основной метод загрузки данных
        /// </summary>
        /// <param name="customerList">
        /// массив записей
        /// </param>
        public virtual void LoadData(List<ThreadCustomer> customerList)
        {
            Console.WriteLine("Loading data by Threads...");

            // Число записей в массиве
            int recCount = customerList.Count;
            
            // Счетчик потоков
            int totalthreadCount = 0;

            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= recCount; i += threadCount)
            {
                totalthreadCount++;
                var p = new ThreadObject()
                        { 
                            customerList = customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList()
                        };
                var t = Task.Factory.StartNew(() => ThreadLoadData(p));
                tasks.Add(t);
                
            }
            Console.WriteLine($"Создано потоков: {totalthreadCount}");

            Task.WaitAll(tasks.ToArray());
           
            Console.WriteLine("Loaded data by Threads...");
        }

        /// <summary>
        /// Метод потока
        /// virlual - переопределяется в ProcedureDataLoader
        /// </summary>
        /// <param name="obj">
        /// Массив записей
        /// </param>
        public virtual void ThreadLoadData(object obj)
        {
            ThreadObject threadObject = obj as ThreadObject;
            List<ThreadCustomer> customerList = threadObject.customerList;
            AutoResetEvent autoResetEvent = threadObject.are;

            foreach (var item in customerList)
            {
                _customerRepository.AddCustomer(item);
            }
            
            // Выставлем объект в несигнальное состояние. Поток завершает работу.
            if (autoResetEvent != null) autoResetEvent.Set();
        }
    }
}