using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
    public interface IInvoiceMapper
    {
        Task BlDeleteAsync(int id);
        Task<InvoiceVm> BlGetAll();
        IEnumerable<InvoiceVm> BlGetAllInstructor();
        Task<InvoiceVm> BlGetById(int? id);
        Task BlInser(InvoiceVm Category);
        Task BlUpdateAsync(InvoiceVm Category);
        bool CategoryExists(int id);
    }
}