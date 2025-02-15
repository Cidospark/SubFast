using Microsoft.EntityFrameworkCore;
using SubFast.Models;

namespace SubFast.Api.Data
{
    public class SubFastDbContext : DbContext
    {
        public SubFastDbContext(DbContextOptions<SubFastDbContext> options):base(options)
        {}

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                PhotoPath = "images/john.png"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBrith = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                PhotoPath = "images/sam.jpg"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBrith = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                PhotoPath = "images/mary.png"
            });
        }
    }
}
