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
                // �������������� ������ � �������� �����������
                //thread.Join();
            }
            Console.WriteLine($"������� �������: {totalthreadCount}");

            WaitHandle.WaitAll( areList.ToArray() );
            Console.WriteLine("Loaded data by Threads...");
        }

        /// <summary>
        /// ����� ������
        /// virlual - ���������������� � ProcedureDataLoader
        /// </summary>
        /// <param name="list">
        /// ������ �������
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
            // ��������� ������ � ������������ ���������. ����� ��������� ������.
            autoResetEvent.Set();
        }
    }
}