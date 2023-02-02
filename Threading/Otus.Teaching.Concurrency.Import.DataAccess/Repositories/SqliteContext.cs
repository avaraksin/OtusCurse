using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class SqliteContext : DbContext
    {
        public static SqliteContext instance { get; private set; }
        public SqliteContext()
        {
            if (instance != null) return;

            instance = this;
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

        public static SqliteContext GetInstance()
        {
            if (instance == null)
            {
                instance = new SqliteContext();
            }
            return instance;
        }
 
    }
}
