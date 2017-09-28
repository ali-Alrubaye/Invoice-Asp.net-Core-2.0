using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IOrder
    {
        Task<Order> GetByIdAsync(int? id);

        IQueryable<Order> SearchFor(Expression<Func<Order, bool>> predicate);

        Task<IEnumerable<Order>> GetAll();

        Task UpdateAsync(Order entity);

        Task InsertAsync(Order entity);

        Task DeleteAsync(int entity);

        bool OrderExists(int id);

        IEnumerable<Order> BlGetAllOrder();

    }
}
