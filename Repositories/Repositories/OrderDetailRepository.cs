using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetail
    {
        private readonly InvoiceContext ctx;
    
        public OrderDetailRepository(InvoiceContext invoiceContext)
        {
            ctx = invoiceContext;
        }
        public async Task DeleteAsync(int entity)
        {
                var orderDetail = await ctx.OrderDetails.SingleOrDefaultAsync(m => m.OrderId == entity);
                ctx.OrderDetails.Remove(orderDetail);
                await ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail entity)
        {
            //var studentToUpdate = await ctx.OrderDetails.SingleOrDefaultAsync(s => s.OrderId == entity.OrderId);
            //await OperationExecutor.t.UpdateDatabase()

              //var updateOd = ctx.OrderDetails
              //      .FirstOrDefault(p => p.OrderId == entity.OrderId);
              //  if (updateOd != null)
              //  {
              //      updateOd.OrderId = entity.OrderId;
              //      updateOd.ProductId = entity.ProductId;
              //      updateOd.Notes = entity.Notes;
              //      updateOd.Quantity = entity.Quantity;
              //      updateOd.Price = entity.Price;
              //      updateOd.Vat = entity.Vat;
              //  }
              //   ctx.SaveChanges();
              

            ctx.Update(entity);
            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetAll()
        {
                var getAll = ctx.OrderDetails
                .Where(c => true)
                .Include(s => s.Orders).ThenInclude(c => c.CustomerOrders).ThenInclude(co => co.Companys)
                .Include(o => o.Products).ThenInclude(c => c.ProtuctCategorys)
                .AsNoTracking()
                .ToListAsync();
                return await getAll;
        }

        public async Task<IEnumerable<OrderDetail>> GetByIdAsync(int? id)
        {
            var find = ctx.OrderDetails
                
                    .Include(s => s.Orders)
                        .ThenInclude(c => c.CustomerOrders)
                        .ThenInclude(co => co.Companys)
                .Include(o => o.Products).ThenInclude(c => c.ProtuctCategorys)
                .Where(c => c.OrderId == id)
                    .AsNoTracking()
                    .ToListAsync();
            
            return await find;
        }

        public async Task<List<OrderDetail>> GetInvoiceInfoById(int? id)
        {
            var find = await ctx.OrderDetails
                .Include(s => s.Orders)
                    .ThenInclude(c => c.CustomerOrders)
                    .ThenInclude(co => co.Companys)
                .Include(o => o.Products)
                    .ThenInclude(c => c.ProtuctCategorys)
               .Where(c => c.Orders.CustomerOrders.CustomerId == id)
               .ToListAsync();

           

            return find;
        }

        public async Task<OrderDetail> GetOdById(int? id)
        {
            var find = ctx.OrderDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.OrderId == id);
            return await find;
        }
        public async Task InsertAsync(OrderDetail entity)
        {
            var num = await ctx.Orders.Select(c => c.OrderId).ToListAsync();
            var n = num.Count();
            
            entity.OrderId =  n;
            //ctx.Add(entity);
            ctx.Entry(entity).State = EntityState.Added;
                await ctx.SaveChangesAsync();
        }

        public IQueryable<OrderDetail> SearchFor(Expression<Func<OrderDetail, bool>> predicate)
        {
                var find = ctx.OrderDetails.Where(predicate);
                return find;
        }
        public bool OrderDetailExists(int id)
        {
                return ctx.OrderDetails.Any(e => e.OrderId == id);
        }

        public IEnumerable<OrderDetail> BlGetAllOrderDetail()
        {
                var getAll = ctx.OrderDetails.Select(c => new OrderDetail {  OrderId = c.OrderId });
                return getAll.ToList();
        }
    }
}
