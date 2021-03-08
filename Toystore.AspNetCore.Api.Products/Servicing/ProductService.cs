using Toystore.AspNetCore.Api.Products.Definition;
using Toystore.Core.Products.Persistence;
using Toystore.Core.Products.Servicing;

namespace Toystore.AspNetCore.Api.Products.Servicing
{
    public class ProductService : ProductService<Product>
    {
        public ProductService(IProductRepository<Product> productRepository)
            : base(productRepository)
        {

        }
    }
}
