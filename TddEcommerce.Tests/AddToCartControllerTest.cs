﻿using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TddEcommerce.Domain;
using Xunit;

namespace TddEcommerce.Tests
{
    public class AddToCartControllerTest
    {
        private HttpClient client;
        private TestServer server;

        [Fact]
        public async Task AddProductToCart()
        {
            IConfiguration config = new ConfigurationBuilder().Build();
            var webHostBuilder = new WebHostBuilder().UseConfiguration(config).UseStartup<TestStartup>();
            server = new TestServer(webHostBuilder);
            client = server.CreateClient();

            var content = new StringContent(@" { 
                                                  productId : 1,
                                                  quantity : 3
                                               }
                                                ", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/user/5/cart/items", content);
            response.EnsureSuccessStatusCode();

            var cart = TestStartup.commerceContext.Carts.Include(x=>x.Items).First();
            cart.Items.Should().Contain(new CartItem {ProductId = 1});
        }
    }
}