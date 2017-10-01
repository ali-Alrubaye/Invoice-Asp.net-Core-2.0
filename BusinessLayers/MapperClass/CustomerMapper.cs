using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.IRepositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayers.MapperClass
{
    public class CustomerMapper : ICustomerMapper
    {
        private readonly ICustomer _customerRepository;
        public CustomerMapper(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<CustomerVm>> BlGetAll()
        {
            var getData = await _customerRepository.GetAll();
            var randomCustomer = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerVm>>(getData);

            return randomCustomer;
        }

        public async Task<CustomerVm> BlGet_Cust_Comp_ById(int? id)
        {
            var getRepo = await _customerRepository.GetCustomer_include_CompanyByID(id);
            var randomCustomer = Mapper.Map<Customer, CustomerVm>(getRepo);
            return randomCustomer;
        }
        public async Task<CustomerVm> BlGetCustById(int? id)
        {
            var getRepo = await _customerRepository.GetCustomerById(id);
            var randomCustomer = Mapper.Map<Customer, CustomerVm>(getRepo);
            return randomCustomer;
        }
        public async Task BlInser(CustomerVm Customer)
        {
            var addMap = Mapper.Map<CustomerVm, Customer>(Customer);
            await _customerRepository.InsertAsync(addMap);
        }

        public async Task BlUpdateAsync(CustomerVm Customer)
        {
            var editMap = Mapper.Map<CustomerVm, Customer>(Customer);
            await _customerRepository.UpdateAsync(editMap);
        }

        public async Task BlDeleteAsync(int id)
        {
            //var getFromR =await _CustomerRepository.GetByIdAsync(id);
            await _customerRepository.DeleteAsync(id);
        }
        public bool CustomerExists(int id)
        {
            var r = _customerRepository.CustomerExists(id);
            return r;
        }

        public IEnumerable<CustomerVm> BlGetAllCustomer()
        {
            var getData =  _customerRepository.BlGetAllCustomer();
            var randomCustomer = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerVm>>(getData);

            return randomCustomer;
        }
    }
}
