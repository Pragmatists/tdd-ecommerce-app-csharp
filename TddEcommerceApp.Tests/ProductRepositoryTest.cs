using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TddEcommerceApp.Domain;
using TddEcommerceApp.Infrastructure;
using Xunit;

namespace TddEcommerceApp.Tests
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
