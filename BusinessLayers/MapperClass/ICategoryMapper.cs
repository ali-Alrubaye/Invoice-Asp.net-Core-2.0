using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
    public interface ICategoryMapper
    {
        Task BlDeleteAsync(int id);
        Task<IEnumerable<CategoryVm>> BlGetAll();
        
        Task<CategoryVm> BlGetById(int? id);
        Task BlInser(CategoryVm category);
        Task BlUpdateAsync(CategoryVm category);
        bool CategoryExists(int id);
        IEnumerable<CategoryVm> BlGetAllCategory();
    }
}