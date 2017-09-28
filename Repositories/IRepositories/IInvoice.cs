using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Repositories.Models;

namespace Repositories
{
    public interface IInvoice
    {
        bool InstructorExists(int id);
        Task DeleteAsync(int entity);
        Task<Invoice> GetAll();
        Task<Invoice> GetByIdAsync(int? id);
        IEnumerable<Invoice> GetInstructor();
        Task InsertAsync(Invoice entity);
        IEnumerable<Company> SearchFor(Expression<Func<Invoice, bool>> predicate);
        Task UpdateAsync(Invoice entity);
    }
}