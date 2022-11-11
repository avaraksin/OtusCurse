using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public class AppDBContext : DbContext
    {
        private string _dbConnectionString;
        
        public DbSet<Clients> clients { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Products> products { get; set; }

        public AppDBContext(string connectionstring)
        {
            _dbConnectionString = connectionstring;
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(_dbConnectionString);
        }

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
