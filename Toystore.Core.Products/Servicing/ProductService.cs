using System.Collections.Generic;
using System.Threading.Tasks;
using Toystore.Core.Products.Definition;
using Toystore.Core.Products.Exceptions;
using Toystore.Core.Products.Persistence;

namespace Toystore.Core.Products.Servicing
{
    public class ProductService<T>
        where T : class, IProduct
    {
        protected internal IProductRepository<T> ProductRepository { get; protected set; }

        public ProductService(IProductRepository<T> productRepository)
        {
            ProductRepository = productRepository != null
                                ? productRepository
                                : throw new ProductException($"Can't find service: { nameof(ProductRepository) }");
        }

        public virtual async Task DeleteProductAsync(int id)
        {
            if (!(id > 0))
            {
                throw new ProductException("Product id can't be empty.");
            }

            var product = await ProductRepository.FindProductAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ProductException("Product doesn't exist.");
            }

            await ProductRepository.DetachEntityAsync(product);
            await ProductRepository.DeleteProductAsync(product.Id);
        }

        public virtual async Task<T> FindProductByIdAsync(int id)
        {
            if (!(id > 0))
            {
                throw new ProductException("Product id must be greater than zero.");
            }

            return await ProductRepository.FindProductAsync(p => p.Id == id);
        }

        public virtual async Task<ICollection<T>> FindProductsAsync()
        {
            return await ProductRepository.FindProductsAsync();
        }

        public virtual async Task SaveProductAsync(T product)
        {
            if (product == null)
            {
                throw new ProductException("Product can´t be empty.");
            }
            if (product.Id > 0)
            {
                throw new ProductException("Product id can´t be greater than zero.");
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ProductException("Product name can't be empty.");
            }
            if (string.IsNullOrEmpty(product.Company))
            {
                throw new ProductException("Product company can´t be empty.");
            }
            if (!(product.Price > 0))
            {
                throw new ProductException("Product price must be greater than zero.");
            }

            var existingProduct = await ProductRepository.FindProductAsync(p => p.Name == product.Name);

            if (existingProduct != null)
            {
                throw new ProductException($"There is already a product called { product.Name }");
            }

            await ProductRepository.SaveProductAsync(product);
        }

        public virtual async Task UpdateProductAsync(T product)
        {
            if (product == null)
            {
                throw new ProductException("Product can´t be empty.");
            }
            if (!(product.Id > 0))
            {
                throw new ProductException("Product id must be greater than zero.");
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ProductException("Product name can't be empty.");
            }
            if (string.IsNullOrEmpty(product.Company))
            {
                throw new ProductException("Product company can´t be empty.");
            }
            if (!(product.Price > 0))
            {
                throw new ProductException("Product price must be greater than zero.");
            }

            var existingProduct = await ProductRepository.FindProductAsync(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                throw new ProductException("Product doesn't exist.");
            }

            existingProduct = await ProductRepository.FindProductAsync(p => p.Name == product.Name && p.Id != product.Id);

            if (existingProduct != null)
            {
                throw new ProductException($"There is already another product called { product.Name }.");
            }

            await ProductRepository.UpdateProductAsync(product);
        }
    }
}
