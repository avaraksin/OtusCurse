using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
        protected int threadCount { get; } = 21000;

        public ThreadDataLoader(int threadCount)
        {
            this.threadCount = threadCount;
        }

        public ThreadDataLoader()
        {}

        /// <summary>
        /// �������� ����� �������� ������
        /// </summary>
        /// <param name="customerList">
        /// ������ �������
        /// </param>
        public virtual void LoadData(List<Customer> customerList)
        {
            Console.WriteLine("Loading data by Threads...");

            // ����� ������� � �������
            int recCount = customerList.Count;
            
            // ������� �������
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
                // �������������� ������ � �������� �����������
                thread.Join();
            }
            Console.WriteLine($"������� �������: {totalthreadCount}");
            Console.WriteLine("Loaded data by Threads...");
        }

        /// <summary>
        /// ����� ������
        /// virlual - ���������������� � PoolDataLoader
        /// </summary>
        /// <param name="list">
        /// ������ �������
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