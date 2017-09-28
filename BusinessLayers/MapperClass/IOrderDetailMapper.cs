using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
    public interface IOrderDetailMapper
    {
        Task BlDeleteAsync(int id);
        Task<IEnumerable<OrderDetailVm>> BlGetAll();
        IEnumerable<OrderDetailVm> BlGetAllOrder();
        Task<IEnumerable<OrderDetailVm>> BlGetById(int? id);
        Task BlInser(OrderDetailVm OrderDetail);
        Task BlUpdateAsync(OrderDetailVm OrderDetail);
        bool OrderDetailExists(int id);
    }
}