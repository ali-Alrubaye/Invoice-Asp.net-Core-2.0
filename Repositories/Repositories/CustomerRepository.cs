using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;
using Repositories.Models;

namespace Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly InvoiceContext ctx;
     
        public CustomerRepository(InvoiceContext invoiceContext)
        {
            ctx = invoiceContext;
        }
        public async Task DeleteAsync(int entity)
        {
           
                var customer = await ctx.Customers.SingleOrDefaultAsync(m => m.CustomerId == entity);
                ctx.Customers.Remove(customer);
                await ctx.SaveChangesAsync();
            

        }

        public async Task UpdateAsync(Customer entity)
        {
           
                ctx.Update(entity);
                await ctx.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {

            var getAll = ctx.Customers;
                //.Where(x => true)
                //.Include(c => c.Companys)
                //.Include(o => o.Orders);
                return await getAll.ToListAsync();
            
        }

        public async Task<Customer> GetByID(int? id)
        {
            
                var find = ctx.Customers.Where(p => p.CustomerId == id).Include(c => c.Companys)
                       .FirstOrDefaultAsync();
                return await find;
            
        }

        public async Task InsertAsync(Customer entity)
        {
           
                //ctx.Add(entity);
                ctx.Entry(entity).State = EntityState.Added;
                await ctx.SaveChangesAsync();
            
        }

        public IQueryable<Customer> SearchFor(Expression<Func<Customer, bool>> predicate)
        {
           
                var find = ctx.Customers.Where(predicate);
                return find;
            

        }
        public bool CustomerExists(int id)
        {
           
                return ctx.Customers.Any(e => e.CustomerId == id);
            
        }

        public IEnumerable<Customer> BlGetAllCustomer()
        {
           
                var getAll =  ctx.Customers.Select(c => new Customer { CustomerId = c.CustomerId, LastName = c.LastName, FirstMidName = c.FirstMidName});
                
                return  getAll.ToList();
            
        }
    }
}
