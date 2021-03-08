using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Toystore.AspNetCore.Api.Products.Definition;
using Toystore.Core.Products.Exceptions;
using Toystore.Core.Products.Persistence;

namespace Toystore.AspNetCore.Api.Products.Persistence
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly DbContext Db;

        public ProductRepository(DbContext db)
        {
            Db = db != null
                    ? db
                    : throw new ProductException($"Can´t find service: { nameof(db) }");
        }

        public async Task DeleteProductAsync(int id)
        {
            await Task.Run(() =>
            {
                var product = Db.Set<Product>().SingleOrDefault(p => p.Id == id);
                Db.Entry<Product>(product).State = EntityState.Deleted;
                Db.SaveChanges();
            });
        }

        public async Task DetachEntityAsync(Product product)
        {
            await Task.Run(() =>
            {
                Db.Entry<Product>(product).State = EntityState.Detached;
                Db.SaveChanges();
            });
        }

        public async Task<Product> FindProductAsync(Expression<Func<Product, bool>> condition)
        {
            return await Db.Set<Product>().AsNoTracking().SingleOrDefaultAsync(condition);
        }

        public async Task<ICollection<Product>> FindProductsAsync()
        {
            return await Db.Set<Product>().AsNoTracking().ToListAsync();
        }

        public async Task SaveProductAsync(Product product)
        {
            Db.Set<Product>().Add(product);
            await Db.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            Db.Entry<Product>(product).Property(p => p.Name).IsModified = true;
            Db.Entry<Product>(product).Property(p => p.Description).IsModified = true;
            Db.Entry<Product>(product).Property(p => p.MinimumAge).IsModified = true;
            Db.Entry<Product>(product).Property(p => p.Company).IsModified = true;
            Db.Entry<Product>(product).Property(p => p.Price).IsModified = true;
            Db.Entry<Product>(product).Property(p => p.Image).IsModified = true;
            await Db.SaveChangesAsync();
        }
    }
}
