using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.Handler.Repositories
{
    public interface ICustomerRepository
    {
        public void AddCustomer(ThreadCustomer customer);
        public void Clear();
        public int Count();
        public void CreateDB();
        public string GetDbName();
    }
}