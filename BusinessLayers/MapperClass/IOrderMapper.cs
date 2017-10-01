using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
    public interface IOrderMapper
    {
        Task BlDeleteAsync(int id);
        Task<IEnumerable<OrderVm>> BlGetAll();
        
        Task<OrderVm> BlGetById(int? id);
        Task BlInser(OrderVm Order);
        Task BlUpdateAsync(OrderVm Order);
        bool OrderExists(int id);
        IEnumerable<OrderVm> BlGetAllOrder();

        Task<List<OrderVm>> GetOrderById(int? id);
    }
}