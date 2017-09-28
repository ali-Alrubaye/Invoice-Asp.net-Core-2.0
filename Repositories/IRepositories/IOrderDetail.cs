using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IOrderDetail
    {
        Task<IEnumerable<OrderDetail>> GetByIdAsync(int? id);

        IQueryable<OrderDetail> SearchFor(Expression<Func<OrderDetail, bool>> predicate);

        Task<IEnumerable<OrderDetail>> GetAll();

        Task UpdateAsync(OrderDetail entity);

        Task InsertAsync(OrderDetail entity);

        Task DeleteAsync(int entity);

        bool OrderDetailExists(int id);
        IEnumerable<OrderDetail> BlGetAllOrderDetail();
    }
}
