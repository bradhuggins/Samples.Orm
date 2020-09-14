using Microsoft.EntityFrameworkCore;
using Samples.Orm.Efcore.Models;
using System;

namespace Samples.Orm.Efcore.Tests.Data
{
    public class NullDbContext : AppDbContext
    {
        public NullDbContext(DbContextOptions<NullDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
