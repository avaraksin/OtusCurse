using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            SqliteConnection _connection = new("Filename=:memory:");
            _connection.Open();
            options.UseSqlite(_connection);
 
            base.OnConfiguring(options);
        }

        public DbSet<Customer> customers { get; set; }
 
    }
}
