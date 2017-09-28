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
    public class CompanyRepository : ICompany
    {
        private InvoiceContext ctx;
    
        public CompanyRepository(InvoiceContext invoiceContext)
        {
            ctx = invoiceContext;
        }

        public async Task DeleteAsync(int entity)
        {
                var company = await ctx.Companys.SingleOrDefaultAsync(m => m.CompanyId == entity);
                ctx.Companys.Remove(company);
                await ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company entity)
        {
                ctx.Update(entity);
                await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
                var getAll = ctx.Companys
                .Include(c => c.Customers)
                .AsNoTracking();
                return await  getAll.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int? id)
        {
                var find = ctx.Companys.Where(p => p.CompanyId == id)
                       //.Include(p => p.Customers)
                       .FirstOrDefaultAsync();
                return await find;
        }

        public async Task InsertAsync(Company entity)
        {
           
                ctx.Entry(entity).State = EntityState.Added;
                await ctx.SaveChangesAsync();
            
        }

        public IEnumerable<Company> SearchFor(Expression<Func<Company, bool>> predicate)
        {
                var find = ctx.Companys.Where(predicate);
                return find;
        }
        public bool CompanyExists(int id)
        {
                return ctx.Companys.Any(e => e.CompanyId == id);
        }

        public IEnumerable<Company> GetCompany()
        {
                var getAll = ctx.Companys.Select(c => new Company { CompanyId= c.CompanyId,CompanyName = c.CompanyName});
                return getAll.ToList();
        }
    }
}
