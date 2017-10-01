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
    public class OrderRepository : IOrder
    {
        private readonly InvoiceContext ctx;

        public OrderRepository(InvoiceContext invoiceContext)
        {
            ctx = invoiceContext;
        }
        public async Task DeleteAsync(int entity)
        {
            var order = await ctx.Orders.SingleOrDefaultAsync(m => m.OrderId == entity);
            ctx.Orders.Remove(order);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            ctx.Update(entity);
            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            
            var getAll = ctx.Orders
                .Include(c => c.CustomerOrders)
                .Include(o => o.OrderODs).ThenInclude(i => i.Products)
                .AsNoTracking().ToListAsync();
            return await getAll;
        }

        public async Task<Order> GetByIdAsync(int? id)
        {
            var find = ctx.Orders
                .Include(c => c.CustomerOrders)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(p => p.OrderId == id);
            return await find;
        }
        public async Task<List<Order>> GetOrderById(int? id)
        {
            var find = ctx.Orders
                .Where(i => i.CustomerOrders.CustomerId == id)
                .Include(m => m.OrderODs).Where(i => true).ToListAsync();
                
            return await find;
        }

        public async Task InsertAsync(Order entity)
        {
            

            var num = ctx.Orders.Select(c => c.OrderNumber).LastOrDefault();
            if (entity.OrderNumber == 0 || entity.OrderNumber == null)
            {
                entity.OrderNumber = num + 1;
            }
            //ctx.Add(entity);
            ctx.Entry(entity).State = EntityState.Added;
            await ctx.SaveChangesAsync();
        }

        public IQueryable<Order> SearchFor(Expression<Func<Order, bool>> predicate)
        {
            var find = ctx.Orders.Where(predicate);
            return find;
        }
        public bool OrderExists(int id)
        {
            return ctx.Orders.Any(e => e.OrderId == id);
        }

        public IEnumerable<Order> BlGetAllOrder()
        {
            var getAll = ctx.Orders.ToList();

            return getAll.ToList();
        }
        public async Task<List<Order>> GetInvoiceInfoById(int? id)
        {

            var find = await ctx.OrderDetails

                .Include(s => s.Orders)
                .ThenInclude(c => c.CustomerOrders)
                .ThenInclude(co => co.Companys)
                .Include(o => o.Products)
                .ThenInclude(c => c.ProtuctCategorys)
                .Select(i => i.Orders)
                .Where(c => c.OrderId == id)
                .AsNoTracking()
                .ToListAsync();

            return find;
        }

    }
}
