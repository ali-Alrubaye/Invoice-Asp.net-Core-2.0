using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ICategory
    {
        Task<Category> GetByIdAsync(int? id);

        IQueryable<Category> SearchFor(Expression<Func<Category, bool>> predicate);

        Task<IEnumerable<Category>> GetAll();

        Task UpdateAsync(Category entity);

        Task InsertAsync(Category entity);

        Task DeleteAsync(int entity);
        bool CategoryExists(int id);
        IEnumerable<Category> GetAllCategory();
    }
}
