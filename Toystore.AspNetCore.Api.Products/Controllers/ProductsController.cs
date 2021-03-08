using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toystore.AspNetCore.Api.Products.Definition;
using Toystore.AspNetCore.Api.Products.Presentation;
using Toystore.AspNetCore.Api.Products.Util;
using Toystore.Core.Products.Exceptions;
using Toystore.Core.Products.Servicing;

namespace Toystore.AspNetCore.Api.Products.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly ProductService<Product> ProductService;

        public ProductsController(ProductService<Product> productService)
        {
            ProductService = productService;
        }

        [HttpDelete("{id}")]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<ProductResponse<bool>> DeleteProduct(int id)
        {
            try
            {
                await ProductService.DeleteProductAsync(id);
                return ProductResponse<bool>.Create("Operation successfully.", true);
            }
            catch (Exception e)
            {
                return ProductResponse<bool>.Create($"Server Error: { e.Message }");
            }
        }

        [HttpGet("{id}")]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<ProductResponse<ProductView>> FindProductById(int id)
        {
            try
            {
                var product = await ProductService.FindProductByIdAsync(id);

                if (product == null)
                {
                    throw new ProductException("Product doesn't exist.");
                }

                var productView = ProductMapper.ToView(product);
                return ProductResponse<ProductView>.Create("Operation successfully.", productView);
            }
            catch (Exception e)
            {
                return ProductResponse<ProductView>.Create($"Server Error: { e.Message }");
            }
        }

        [HttpGet]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<ProductResponse<ICollection<ProductView>>> FindProducts()
        {
            try
            {
                var products = await ProductService.FindProductsAsync();
                var views = ProductMapper.ToViews(products);
                return ProductResponse<ICollection<ProductView>>.Create("Operation successfully.", views);
            }
            catch (Exception e)
            {
                return ProductResponse<ICollection<ProductView>>.Create($"Server Error: { e.Message }");
            }
        }

        [HttpPost]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<ProductResponse<ProductView>> SaveProduct([FromBody] ProductView productView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ProductException(ModelState.GetErrors());
                }
                var product = ProductMapper.ToProduct(productView);
                await ProductService.SaveProductAsync(product);
                productView = ProductMapper.ToView(product);
                return ProductResponse<ProductView>.Create("Operation successfully.", productView);
            }
            catch (Exception e)
            {
                return ProductResponse<ProductView>.Create($"Server Error: { e.Message }");
            }
        }

        [HttpPut]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<ProductResponse<ProductView>> UpdateProduct([FromBody] ProductView productView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ProductException(ModelState.GetErrors());
                }
                var product = ProductMapper.ToProduct(productView);
                await ProductService.UpdateProductAsync(product);
                productView = ProductMapper.ToView(product);
                return ProductResponse<ProductView>.Create("Operation Successfully.", productView);
            }
            catch (Exception e)
            {
                return ProductResponse<ProductView>.Create($"Server Error: { e.Message }");
            }
        }
    }
}