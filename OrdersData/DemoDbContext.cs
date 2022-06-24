using Microsoft.EntityFrameworkCore;
using OrdersData.Entities;

namespace OrdersData
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DemoDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-QM194TV4\SQLEXPRESS;Database=OrdersEfDb;Trusted_Connection=True;");


        }
    }
}