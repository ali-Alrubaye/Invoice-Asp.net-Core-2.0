using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
    public interface IProductMapper
    {
        Task BlDeleteAsync(int id);
        Task<IEnumerable<ProductVm>> BlGetAll();
        IEnumerable<ProductVm> BlGetAllProduct();
        Task<ProductVm> BlGetById(int? id);
        Task BlInser(ProductVm Product);
        Task BlUpdateAsync(ProductVm Product);
        bool ProductExists(int id);
        //IEnumerable<CategoryVM> BlGetCategoryIProducts();
    }
}