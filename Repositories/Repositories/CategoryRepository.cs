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
    public class CategoryRepository : ICategory
    {
        private readonly InvoiceContext ctx;

        public CategoryRepository(InvoiceContext context)
        {
            ctx = context;
        }
        public async Task DeleteAsync(int entity)
        {

          
                var p = await ctx.Categorys.SingleOrDefaultAsync(x => x.CategoryId == entity);
                ctx.Categorys.Remove(p);
                await ctx.SaveChangesAsync(); 
            
            
        }

        public async Task UpdateAsync(Category entity)
        {
            
                ctx.Update(entity);
                await ctx.SaveChangesAsync(); 
            
        }

        public async Task<IEnumerable<Category>> GetAll()
        {

                var getAll = ctx.Categorys
                        .Include(c => c.Products);
                return await getAll.ToListAsync(); 
            
        }

        public async Task<Category> GetByIdAsync(int? id)
        {

                var find = ctx.Categorys.Where(p => p.CategoryId == id)

                               //.Include(p => p.Products)
                               .FirstOrDefaultAsync();

                return await find; 
            
            
        }

        public async Task InsertAsync(Category entity)
        {
                ctx.Entry(entity).State = EntityState.Added;
                await ctx.SaveChangesAsync(); 
            
        }

        public IQueryable<Category> SearchFor(Expression<Func<Category, bool>> predicate)
        {

                var find = ctx.Categorys.Where(predicate);
                return find; 
            
            
        }

        public bool CategoryExists(int id)
        {
            
                return ctx.Categorys.Any(e => e.CategoryId == id); 
           
        }

        public IEnumerable<Category> GetAllCategory()
        {

           
                var getAll = ctx.Categorys.Select(c => new Category { CategoryId = c.CategoryId, CategoryName = c.CategoryName });

                return  getAll.ToList(); 
            
            
        }
    }
}
