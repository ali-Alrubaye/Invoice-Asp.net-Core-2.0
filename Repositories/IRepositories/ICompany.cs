using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ICompany
    {
        Task<Company> GetByIdAsync(int? id);

       IEnumerable<Company> SearchFor(Expression<Func<Company, bool>> predicate);

        Task<IEnumerable<Company>> GetAll();

        Task UpdateAsync(Company entity);

        Task InsertAsync(Company entity);

        Task DeleteAsync(int entity);
        bool CompanyExists(int id);
        IEnumerable<Company> GetCompany();
    }
}
