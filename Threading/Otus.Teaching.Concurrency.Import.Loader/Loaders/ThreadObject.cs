using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Collections.Generic;
using System.Threading;

namespace Otus.Teaching.Concurrency.Import.Loader.Loaders
{
    /// <summary>
    /// Класс для передачи параметра в метод потока
    /// в классе PoolDataLoader
    /// </summary>
    public class ThreadObject
    {
        /// <summary>
        /// Массив записей
        /// </summary>
        public List<Customer> customerList { get; set; }
        
        /// <summary>
        /// Объект синхронизации
        /// </summary>
        public AutoResetEvent are { get; set; }
    }
}
