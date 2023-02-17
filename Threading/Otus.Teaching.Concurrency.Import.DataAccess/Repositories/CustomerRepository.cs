using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IServiceScopeFactory serviceProvider;

        public CustomerRepository(IServiceScopeFactory _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }

        CommonDb currentDbContext =>
             serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IContext>() as CommonDb;
               
        public void AddCustomer(ThreadCustomer customer)
        {
            using (var _context = currentDbContext)
            {
                _context.threadcustomers.Add(customer);
                _context.SaveChanges();
            }
        }

        public void Clear()
        {
            using (var _context = currentDbContext)
            {
                if (_context.threadcustomers.Count() != 0)
                {
                    var list = _context.threadcustomers.ToList();
                    foreach (var customer in list)
                    {
                        _context.threadcustomers.Remove(customer);
                    }
                    _context.SaveChanges();
                }
            }
        }
        public int Count()
        {
            using (var _context = currentDbContext)
            {
                return _context.threadcustomers.Count();
            }
        }

        public void CreateDB()
        {
            using (var _context = currentDbContext)
            {
                if (_context.GetType() == typeof(SqliteContext))
                {
                    _context.Database.EnsureCreated();
                }
            }
        }

        public string GetDbName()
        {
            using (var _context = currentDbContext)
            {
                var dbname = _context.GetType().Name;

                if (dbname.ToLower().Contains("lite"))
                {
                    return "SQLite";
                }
                if (dbname.ToLower().Contains("ms"))
                {
                    return "MS SQL";
                }
                return "Unknown Database";
            }
        }

    }
}