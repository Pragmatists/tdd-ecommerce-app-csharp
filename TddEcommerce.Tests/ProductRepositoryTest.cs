﻿using FluentAssertions;
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
            Product product = new Product("cup", new Money(1, 25));
            IProductRepository productRepository = new EfProductRepository(CreateCommerceContext());

            var id = productRepository.Save(product);

            Product loaded = productRepository.FindOne(id);
            using (var cc = CreateCommerceContext())
            {
                cc.Products.Find(id).Price.Should().Be(125);
            }
            loaded.Price.ToCents().Should().Be(125);
            loaded.ShouldBeEquivalentTo(product);
        }

        private static CommerceContext CreateCommerceContext()
        {
            var options = new DbContextOptionsBuilder<CommerceContext>().UseInMemoryDatabase().Options;
            return new CommerceContext(options);
        }
    }
}
