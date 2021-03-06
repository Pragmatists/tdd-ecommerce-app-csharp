using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TddEcommerce.Domain
{
    public class CommerceContext : DbContext
    {
        public CommerceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Money>();
            modelBuilder.Entity<Product>().Property(x => x.Cents);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}