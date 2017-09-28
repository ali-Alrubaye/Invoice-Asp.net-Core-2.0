using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ICustomer
    {
        Task<Customer> GetByID(int? id);

        IQueryable<Customer> SearchFor(Expression<Func<Customer, bool>> predicate);

        Task<IEnumerable<Customer>> GetAll();

        Task UpdateAsync(Customer entity);

        Task InsertAsync(Customer entity);

        Task DeleteAsync(int entity);
        bool CustomerExists(int id);
        IEnumerable<Customer> BlGetAllCustomer();
    }
}
