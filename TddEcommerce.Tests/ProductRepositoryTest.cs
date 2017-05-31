using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TddEcommerce.Domain;
using TddEcommerce.Infrastructure;
using Xunit;

namespace TddEcommerce.Tests
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void StoresAndLoadsProduct()
        {
            Product product = new Product(1L, "cup", new Money(1, 25));
            var options = new DbContextOptionsBuilder<CommerceContext>().UseInMemoryDatabase().Options;
            IProductRepository productRepository = new EfProductRepository(new CommerceContext(options));

            productRepository.Save(product);

            Product loaded = productRepository.findOne(1L);
            loaded.ShouldBeEquivalentTo(product);
        }
    }
}
