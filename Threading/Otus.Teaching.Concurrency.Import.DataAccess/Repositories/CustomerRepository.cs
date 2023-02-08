using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Handler.Entities;
using Otus.Teaching.Concurrency.Import.Handler.Repositories;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //private readonly SqliteContext _context;
        private readonly MSSQLContext _context;

        public CustomerRepository()
        {
            _context = new();
        }
        public void AddCustomer(ThreadCustomer customer)
        {
            _context.threadcustomers.Add(customer);
            _context.SaveChanges();
        }

        public void Clear()
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
        public int Count()
        {
            return _context.threadcustomers.Count();
        }

        public void CreateDB()
        {
            if (_context.GetType() == typeof(SqliteContext))
            {
                _context.Database.EnsureCreated();
            }
        }

        public string GetDbName()
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