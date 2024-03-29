using System;
using System.Collections.Generic;
using Bogus;
using Bogus.DataSets;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataGenerator.Generators
{
    public static class RandomCustomerGenerator
    {
        public static List<ThreadCustomer> Generate(int dataCount)
        {
            var customers = new List<ThreadCustomer>();
            var customersFaker = CreateFaker();

            foreach (var customer in customersFaker.GenerateForever())
            {
                customers.Add(customer);

                if (dataCount == customer.Id)
                    return customers;
            }

            return customers;
        }

        private static Faker<ThreadCustomer> CreateFaker()
        {
            var id = 1;
            var customersFaker = new Faker<ThreadCustomer>()
                .CustomInstantiator(f => new ThreadCustomer()
                {
                    Id = id++
                })
                .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FullName))
                .RuleFor(u => u.Phone, (f, u) => f.Phone.PhoneNumber("1-###-###-####"));

            return customersFaker;
        }
    }
}