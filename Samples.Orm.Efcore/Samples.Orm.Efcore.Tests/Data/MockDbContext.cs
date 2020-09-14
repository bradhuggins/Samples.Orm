using Microsoft.EntityFrameworkCore;
using Samples.Orm.Efcore.Models;
using System;

namespace Samples.Orm.Efcore.Tests.Data
{
    public class MockDbContext : AppDbContext
    {
        public MockDbContext(DbContextOptions<MockDbContext> options) : base(options)
        {
            Seed();
        }
        private void Seed()
        {
            this.People.Add(new Person()
            {
                PersonId = 1,
                FirstName = "John",
                LastName = "Doe"
            }
            );

            this.SaveChanges();
        }
    }
}
