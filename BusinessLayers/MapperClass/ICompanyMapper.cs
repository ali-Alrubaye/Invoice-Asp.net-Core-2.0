using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
    public interface ICompanyMapper
    {
        Task BlDeleteAsync(int id);
        Task<IEnumerable<CompanyVm>> BlGetAll();
        IEnumerable<CompanyVm> BlGetAllCompany();
        Task<CompanyVm> BlGetById(int? id);
        Task BlInser(CompanyVm Co);
        Task BlUpdateAsync(CompanyVm Company);
        bool CompanyExists(int id);
    }
}