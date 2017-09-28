using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.IRepositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayers.MapperClass
{
    public class CompanyMapper : ICompanyMapper
    {
        private ICompany _CompanyRepository;
        public CompanyMapper(ICompany companyRepository)
        {
            _CompanyRepository = companyRepository;
        }
        public async Task<IEnumerable<CompanyVm>> BlGetAll()
        {
            var getData = await _CompanyRepository.GetAll();
            var randomCompany = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyVm>>(getData);

            return randomCompany;
        }

        public async Task<CompanyVm> BlGetById(int? id)
        {
            var getRepo = await _CompanyRepository.GetByIdAsync(id);
            var randomCompany = Mapper.Map<Company, CompanyVm>(getRepo);
            return randomCompany;
        }

        public async Task BlInser(CompanyVm Co)
        {
            var addMap = Mapper.Map<CompanyVm, Company>(Co);
            await _CompanyRepository.InsertAsync(addMap);
        }

        public async Task BlUpdateAsync(CompanyVm Company)
        {
            var editMap = Mapper.Map<CompanyVm, Company>(Company);
            await _CompanyRepository.UpdateAsync(editMap);
        }

        public async Task BlDeleteAsync(int id)
        {
            //var getFromR =await _CompanyRepository.GetByIdAsync(id);
            await _CompanyRepository.DeleteAsync(id);
        }
        public bool CompanyExists(int id)
        {
            var getRepo =  _CompanyRepository.CompanyExists(id);
            return getRepo;
        }

        public IEnumerable<CompanyVm> BlGetAllCompany()
        {
            var getData =  _CompanyRepository.GetCompany();
            var randomCompany = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyVm>>(getData);

            return randomCompany;
        }
    }
}
