using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IProduct
    {
        Task<Product> GetByIdAsync(int? id);

        IQueryable<Product> SearchFor(Expression<Func<Product, bool>> predicate);

        Task<IEnumerable<Product>> GetAll();

        Task UpdateAsync(Product entity);

        Task InsertAsync(Product entity);

        Task DeleteAsync(int entity);
        bool ProductExists(int id);
        IEnumerable<Product> GetAllProduct();
        //IEnumerable<Category> GetCategoryIProduct();
    }
}
