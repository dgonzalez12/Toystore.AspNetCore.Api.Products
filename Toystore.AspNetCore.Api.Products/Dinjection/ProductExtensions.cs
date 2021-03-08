using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Toystore.AspNetCore.Api.Products.Definition;
using Toystore.AspNetCore.Api.Products.Persistence;
using Toystore.AspNetCore.Api.Products.Servicing;
using Toystore.Core.Products.Persistence;
using Toystore.Core.Products.Servicing;

namespace Toystore.AspNetCore.Api.Products.Dinjection
{
    public static class ProductExtensions
    {
        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            services.AddSingleton<IProductContextConfiguration, ProductContextConfiguration>();
            services.AddSingleton<DbContext, ProductContext>();

            return services;
        }

        public static IServiceCollection AddProduct(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository<Product>, ProductRepository>();
            services.AddScoped<ProductService<Product>, ProductService>();

            return services;
        }

        public static IServiceCollection AddProductRows(this IServiceCollection services)
        {
            var productContext = services.BuildServiceProvider().GetService<DbContext>();

            if (productContext != null)
            {
                var products = new List<Product>
                {
                    new Product { Id = 0, Name = "Max Steel", Description = "Action Figure", MinimumAge = 0, Company = "Mattel", Price = (decimal) 150.00, Image = null },
                    new Product { Id = 0, Name = "Jessie", Description = "Disney Collection Figure", MinimumAge = 0, Company = "Disney Collection", Price = (decimal) 524.30, Image = null },
                    new Product { Id = 0, Name = "Woody", Description = "Disney Collection Figure", MinimumAge = 0, Company = "Disney Collection", Price = (decimal) 599.20, Image = null }
                };

                productContext.AddRange(products);
                productContext.SaveChanges();
            }

            return services;
        }
    }
}
