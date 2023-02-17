using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class CommonDb : DbContext
    {
        public CommonDb(DbContextOptions options) : base(options) { }

        public DbSet<ThreadCustomer> threadcustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThreadCustomer>().HasKey(x => x.Id);
        }
    }
}
