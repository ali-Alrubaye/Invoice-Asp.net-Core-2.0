using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly InvoiceContext ctx;
   
        public ProductRepository(InvoiceContext invoiceContext)
        {
            ctx = invoiceContext;
        }

        public async Task DeleteAsync(int entity)
        {
                var Product = await ctx.Products.SingleOrDefaultAsync(m => m.ProductId == entity);
                ctx.Products.Remove(Product);
                await ctx.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(Product entity)
        {
                ctx.Update(entity);
                await ctx.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
                var getAll = ctx.Products
                        .Include(c => c.ProtuctCategorys);
                return await getAll.ToListAsync(); 
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
                var find = ctx.Products.Where(p => p.ProductId == id)
                              .Include(p => p.ProtuctCategorys)
                              .FirstOrDefaultAsync();
                return await find; 
        }

        public async Task InsertAsync(Product entity)
        {
                ctx.Entry(entity).State = EntityState.Added;
                await ctx.SaveChangesAsync(); 
        }

        public IQueryable<Product> SearchFor(Expression<Func<Product, bool>> predicate)
        {
                var find = ctx.Products.Where(predicate);
                return find; 
            
            
        }

        public bool ProductExists(int id)
        {
                var getAll = ctx.Products.Any(p => p.ProductId == id);
                return getAll; 
        }

        public IEnumerable<Product> GetAllProduct()
        {
                var getAll = ctx.Products.Select(c => new Product { ProductId = c.ProductId, Article = c.Article });
                return getAll.ToList(); 
        }
        
    }
}
