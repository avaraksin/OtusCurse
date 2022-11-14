using Microsoft.EntityFrameworkCore;

namespace Lesson4
{
    /// <summary>
    /// Контекст БД для работы через EF
    /// </summary>
    public class AppDBContext : DbContext
    {
        /// <summary>
        /// Строка соединения с БД
        /// </summary>
        private readonly string _dbConnectionString;
        
        /// <summary>
        /// Образ таблиц БД
        /// </summary>
        public DbSet<Clients> clients { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Products> products { get; set; }


        public AppDBContext(string connectionstring)
        {
            _dbConnectionString = connectionstring;
        }

        
        /// <summary>
        /// Регистрируем контекст MS SQL Server
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnectionString);
        }



        /// <summary>
        /// Задаем первичные и вторичные ключи
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>().HasKey(x => x.id);
            modelBuilder.Entity<Orders>().HasKey(x => new { x.idOrder, x.id });
            modelBuilder.Entity<Products>().HasKey(x => x.id);

            modelBuilder.Entity<Orders>().HasOne(x => x.clients).WithMany().HasForeignKey(x => x.clientId).HasPrincipalKey(x => x.id);
            modelBuilder.Entity<Orders>().HasOne(x => x.product).WithMany().HasForeignKey(x => x.productId).HasPrincipalKey(x => x.id);
        }
    }
}
