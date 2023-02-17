﻿using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.DataAccess.Repositories;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    /// <summary>
    /// Обработка массива записей в 1 методе
    /// </summary>
    public class ProcedureDataLoader : ThreadDataLoader, IDataLoader
    {
        public ProcedureDataLoader(IServiceScopeFactory serviceProvider) : base(serviceProvider)
        { }


        public override void LoadData(List<ThreadCustomer> customerList)
        {
            Console.WriteLine("Loading data by Procedure...");
            ThreadLoadData(customerList);
            Console.WriteLine("Loaded data by Procedure...");
        }

        /// <summary>
        ///  Переопредяем метод, т.к. тут не нужны объекты синхронизации
        /// </summary>
        /// <param name="obj"></param>
        public override void ThreadLoadData(object obj)
        {
            List<ThreadCustomer> customerList = obj as List<ThreadCustomer>;

            foreach (var item in customerList)
            {
                _customerRepository.AddCustomer(item);
            }

        }
    }
}
