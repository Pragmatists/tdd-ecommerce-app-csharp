using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TddEcommerce.Domain;
using TddEcommerce.Infrastructure;

namespace TddEcommerce.Tests
{
    public class TestStartup
    {
        public static CommerceContext commerceContext;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommerceContext>(
                optionsBuilder => optionsBuilder.UseInMemoryDatabase());

            services.AddMvc();

            services.AddScoped<IProductRepository, EfProductRepository>();
        }

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            CommerceContext commerceContext)
        {
            loggerFactory.AddConsole(LogLevel.Warning);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var repository = app.ApplicationServices.GetService<IProductRepository>();
                InitializeDatabaseAsync(repository);
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
            TestStartup.commerceContext = commerceContext;
        }

        public void InitializeDatabaseAsync(IProductRepository repo)
        {
            var products = repo.FindAll();
            if (!products.Any())
                repo.Save(new Product("Cup", new Money(2, 50)));
        }
    }
}