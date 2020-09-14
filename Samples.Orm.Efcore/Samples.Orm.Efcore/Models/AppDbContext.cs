using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Samples.Orm.Efcore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Properties
        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Perform any custom mapping here

            EntityTypeBuilder<Person> person = modelBuilder.Entity<Person>();
            //// Map to a custom table name
            // t.ToTable("CUSTOM_TABLE_NAME");

            //// Definre primary key(s)
            person.HasKey(x => x.PersonId);

            //// Customize Propertiy Mappings
            person.Property(p => p.FirstName)
            // .HasColumnName("CUSTOM_COLUMN_NAME") // map property to custom database column name
            // .HasMaxLength(255)
            .HasColumnType("varchar(255)")
            ;

            person.Property(p => p.LastName)
            .HasColumnType("varchar(255)")
            ;

            //// Define Indexes
            person.HasIndex(p => p.LastName);


            // Map Address 
            EntityTypeBuilder<Address> address = modelBuilder.Entity<Address>();
            address.HasKey(x => x.AddressId);

            // Map Telephone 
            EntityTypeBuilder<TelephoneNumber> telephone = modelBuilder.Entity<TelephoneNumber>();
            telephone.HasKey(x => x.TelephoneNumberId);
  
            
            //// Define Relationships and Navigation

        }
        
        public void DropAndCreateDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
