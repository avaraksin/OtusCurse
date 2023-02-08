using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext() : base() {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=91.219.6.251\\SQLEXPRESS; Initial Catalog=Otus; TrustServerCertificate=True; User Id=otuslogin; Password=1234");
        }

        public DbSet<ThreadCustomer> threadcustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThreadCustomer>().HasKey(x => x.Id);
        }
    }
}
