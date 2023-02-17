using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public interface IContext : IDisposable
    {
        public DbSet<ThreadCustomer> threadcustomers { get; set; }
        public int SaveChanges();
    }
}
