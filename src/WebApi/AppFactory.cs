namespace WebApi
{
    public class AppFactory : DbContext
    {
        public AppFactory(DbContextOptions<AppFactory> options) : base(options)
        { }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Clients");
            modelBuilder.Entity<User>().HasKey(e => e.id);
        }
    }
}
