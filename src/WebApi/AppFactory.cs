namespace WebApi
{
    /// <summary>
    /// Контекст для работы с БД
    /// </summary>
    public class AppFactory : DbContext
    {
        public AppFactory(DbContextOptions<AppFactory> options) : base(options)
        { }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Указываем, что класс User нужно смэппить на таблицу Clients
            modelBuilder.Entity<User>().ToTable("Clients");

            // Указываем ключ таблицы
            modelBuilder.Entity<User>().HasKey(e => e.id);
        }
    }
}
