using Otus.Teaching.Concurrency.Import.Core.Loaders;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    /// <summary>
    /// Обработка массива записей в 1 методе
    /// </summary>
    public  class ProcedureDataLoader : ThreadDataLoader, IDataLoader
    {
        public ProcedureDataLoader(int threadCount) : base(threadCount)
        { }

        public ProcedureDataLoader() : base() { }

        public override void LoadData(List<Customer> customerList)
        {
            Console.WriteLine("Loading data by Procedure...");
            ThreadLoadData(customerList);
            Console.WriteLine("Loaded data by Procedure...");
        }
    }
}
