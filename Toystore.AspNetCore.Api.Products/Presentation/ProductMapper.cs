using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toystore.AspNetCore.Api.Products.Definition;

namespace Toystore.AspNetCore.Api.Products.Presentation
{
    public class ProductMapper
    {
        public static Product ToProduct(ProductView productView)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductView, Product>();
            });
            var mapper = config.CreateMapper();
            var product = mapper.Map<Product>(productView);
            return product;
        }

        public static ICollection<Product> ToProducts(ICollection<ProductView> productView)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductView, Product>();
            });
            var mapper = config.CreateMapper();
            var products = mapper.Map<ICollection<Product>>(productView);
            return products;
        }

        public static ProductView ToView(Product product)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductView>();
            });
            var mapper = config.CreateMapper();
            var productView = mapper.Map<ProductView>(product);
            return productView;
        }

        public static ICollection<ProductView> ToViews(ICollection<Product> products)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductView>();
            });
            var mapper = config.CreateMapper();
            var productViews = mapper.Map<ICollection<ProductView>>(products);
            return productViews;
        }
    }
}
