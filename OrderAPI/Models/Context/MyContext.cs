using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Models.Entities;
namespace OrderAPI.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
           
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
        }
        public void SeedProducts()
        {
            string[] categories = new string[] { "Electronics", "Books", "Clothing", "Beauty", "Toys" };

            for (int i = 0; i < categories.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Product p = new Product();
                    p.UnitPrice = Convert.ToDecimal(new Commerce("tr").Price());
                    p.Unit = 150;
                    p.Category = categories[i];
                    p.Description = new Lorem("tr").Sentence(10);
                    Products.Add(p);
                }
            }
        }

    }
}
