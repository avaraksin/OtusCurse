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
    /// ����� ��������� ������� ������� ��������� ����� �������
    /// </summary>
    public class ThreadDataLoader : IDataLoader
    {
        /// <summary>
        /// ����� ������� �������������� ����� �������
        /// </summary>
        public int threadCount { get; set; } = 2500;

        protected readonly ICustomerRepository _customerRepository;

        public ThreadDataLoader(IServiceScopeFactory serviceProvider)
        {
            //_customerRepository = customerRepository;
            _customerRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ICustomerRepository>();
        }

       
        /// <summary>
        /// �������� ����� �������� ������
        /// </summary>
        /// <param name="customerList">
        /// ������ �������
        /// </param>
        public virtual void LoadData(List<ThreadCustomer> customerList)
        {
            Console.WriteLine("Loading data by Threads...");

            // ����� ������� � �������
            int recCount = customerList.Count;
            
            // ������� �������
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
            Console.WriteLine($"������� �������: {totalthreadCount}");

            Task.WaitAll(tasks.ToArray());
           
            Console.WriteLine("Loaded data by Threads...");
        }

        /// <summary>
        /// ����� ������
        /// virlual - ���������������� � ProcedureDataLoader
        /// </summary>
        /// <param name="obj">
        /// ������ �������
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
            
            // ��������� ������ � ������������ ���������. ����� ��������� ������.
            if (autoResetEvent != null) autoResetEvent.Set();
        }
    }
}