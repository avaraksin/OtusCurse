using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
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
        public int threadCount { get; set; } = 21000;

        private readonly ICustomerRepository _customerRepository;

        public ThreadDataLoader(/*ICustomerRepository customerRepository*/ IServiceScopeFactory serviceProvider)
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
        public virtual async void LoadData(List<ThreadCustomer> customerList)
        {
            Console.WriteLine("Loading data by Threads...");

            // ����� ������� � �������
            int recCount = customerList.Count;
            
            // ������� �������
            int totalthreadCount = 0;

            //List<AutoResetEvent> areList = new List<AutoResetEvent>();
            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= recCount; i += threadCount)
            {
                //AutoResetEvent are = new AutoResetEvent(false);
                //areList.Add(are);

                totalthreadCount++;
                var p = new ThreadObject()
                        { 
                            customerList = customerList.Where(x => x.Id >= i && x.Id < i + threadCount).ToList()
                            //are = are
                        };
                var t = Task.Factory.StartNew(() => ThreadLoadData(p));
                
            }
            Console.WriteLine($"������� �������: {totalthreadCount}");

            //WaitHandle.WaitAll(areList.ToArray());
            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine("Loaded data by Threads...");
        }

        /// <summary>
        /// ����� ������
        /// virlual - ���������������� � ProcedureDataLoader
        /// </summary>
        /// <param name="list">
        /// ������ �������
        /// </param>
        public virtual void ThreadLoadData(object obj)
        {
            ThreadObject threadObject = obj as ThreadObject;
            List<ThreadCustomer> customerList = threadObject.customerList;
            //AutoResetEvent autoResetEvent = threadObject.are;

            //ICustomerRepository _customerRepository = new CustomerRepository();

            foreach (var item in customerList)
            {
                _customerRepository.AddCustomer(item);
            }
            // ��������� ������ � ������������ ���������. ����� ��������� ������.
            //autoResetEvent.Set();
        }
    }
}