using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    /// <summary>
    /// Контекст работы с БД
    /// </summary>
    public class SqliteContext : CommonDb, IContext
    {
        /// <summary>
        /// Создаем базу SQLite в памяти
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            SqliteConnection _connection = new("Data Source=InMemorySample;Mode=Memory;Cache=Shared");
            _connection.Open();
            options.UseSqlite(_connection);
 
            base.OnConfiguring(options);
        }

        public SqliteContext(DbContextOptions options) : base(options) { }

    }
}
