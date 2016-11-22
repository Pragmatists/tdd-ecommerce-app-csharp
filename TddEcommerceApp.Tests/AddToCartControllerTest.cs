using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TddEcommerceApp.Domain;
using TddEcommerceApp.Infrastructure;

namespace TddEcommerceApp.Tests
{
    public class AddToCartControllerTest
    {
        private HttpClient client;
        private TestServer server;

        [Fact]
        public async Task AddProductToCart()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>();
            server = new TestServer(webHostBuilder);
            client = server.CreateClient();

            var content = new StringContent(@" { 
                                                  productId : 1,
                                                  quantity : 3
                                               }
                                                ", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/user/5/cart/items", content);
            response.EnsureSuccessStatusCode();

            var options = new DbContextOptionsBuilder<CommerceContext>().Options;
            var cart = new CommerceContext(options).Carts.First();
            cart.Items.Should().Contain(new CartItem {ProductId = 1});
        }
    }
}