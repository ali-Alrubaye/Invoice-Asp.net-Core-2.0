using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   public class InvoiceRepository : IInvoice
    {
        private readonly InvoiceContext ctx;

        public InvoiceRepository(InvoiceContext invoiceContext)
        {
            ctx = invoiceContext;
        }

        public async Task DeleteAsync(int entity)
        {

            var company = await ctx.Companys.SingleOrDefaultAsync(m => m.CompanyId == entity);
            ctx.Companys.Remove(company);
            await ctx.SaveChangesAsync();


        }

        public async Task UpdateAsync(Invoice entity)
        {

            ctx.Update(entity);
            await ctx.SaveChangesAsync();
           

        }

        public async Task<Invoice> GetAll()
        {
            Invoice viewModel = new Invoice();
            viewModel.OrdDetInsts = ctx.OrderDetails;
            viewModel.CatInsts = ctx.Categorys;
            viewModel.CompInsts = ctx.Companys;
            viewModel.CustomerInsts = ctx.Customers;
            viewModel.OrdInsts = ctx.Orders;
            viewModel.ProInsts = ctx.Products;
            return  viewModel;

        }

        public async Task<Invoice> GetByIdAsync(int? id)
        {
            
            var orderDetailCheck = ctx.OrderDetails.FirstOrDefault(c => c.Orders.CustomerOrders.CustomerId ==  id);
            Invoice viewModel = new Invoice();
            viewModel.CustomerInsts =  new[] {await ctx.Customers.FirstOrDefaultAsync(o => o.CustomerId == id)};
            viewModel.OrdInsts = new[] {await ctx.Orders.FirstOrDefaultAsync(o => o.CustomerId == id)};
            viewModel.CompInsts = await ctx.Companys.Where(o => o.CompanyId == orderDetailCheck.Orders.CustomerOrders.CompanyId).ToListAsync();
            viewModel.ProInsts = await ctx.Products.Where(o => o.ProductId == orderDetailCheck.ProductId).ToListAsync();
            viewModel.CatInsts = await ctx.Categorys.Where(o => o.CategoryId == orderDetailCheck.Products.CategoryId).ToListAsync();
            viewModel.OrdDetInsts =await ctx.OrderDetails.Where(o => o.Orders.CustomerId == id).ToListAsync();

            
            return  viewModel ;

        }

        public async Task InsertAsync(Invoice entity)
        {

            ctx.Entry(entity).State = EntityState.Added;
            await ctx.SaveChangesAsync();

        }

        public IEnumerable<Company> SearchFor(Expression<Func<Invoice, bool>> predicate)
        {

            var find = ctx.Companys;
            return find;

        }
        public bool InstructorExists(int id)
        {

            return ctx.Companys.Any(e => e.CompanyId == id);

        }

        public IEnumerable<Invoice> GetInstructor()
        {

            var getAll = ctx.Companys.Select(c => new Invoice { });
            return getAll.ToList();

        }
    }
}
