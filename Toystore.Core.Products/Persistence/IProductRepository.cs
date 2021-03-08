using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Toystore.Core.Products.Definition;

namespace Toystore.Core.Products.Persistence
{
    public interface IProductRepository<T>
        where T : class, IProduct
    {
        Task DeleteProductAsync(int id);
        Task DetachEntityAsync(T entity);
        Task<T> FindProductAsync(Expression<Func<T, bool>> condition);
        Task<ICollection<T>> FindProductsAsync();
        Task SaveProductAsync(T product);
        Task UpdateProductAsync(T product);
    }
}
