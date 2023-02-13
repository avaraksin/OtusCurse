using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //private readonly SqliteContext _context;
        private readonly MSSQLContext _context;
        public CustomerRepository(IServiceScopeFactory serviceProvider/*MSSQLContext mSSQLContext*/)
        {
            _context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<MSSQLContext>();
            //_context = mSSQLContext;
        }

    

        public void AddCustomer(ThreadCustomer customer)
        {
            //using (var _context = new SqliteContext())
            {
                _context.threadcustomers.Add(customer);
                _context.SaveChanges();
            }
        }

        public void Clear()
        {
            //using (var _context = new SqliteContext())
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
            //using (var _context = new SqliteContext())
            {
                return _context.threadcustomers.Count();
            }
        }

        public void CreateDB()
        {
            //using (var _context = new SqliteContext())
            {
                if (_context.GetType() == typeof(SqliteContext))
                {
                    _context.Database.EnsureCreated();
                }
            }
        }

        public string GetDbName()
        {
            //using (var _context = new SqliteContext())
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