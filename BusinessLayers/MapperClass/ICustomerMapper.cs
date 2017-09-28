﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayers.Models;

namespace BusinessLayers.MapperClass
{
    public interface ICustomerMapper
    {
        Task BlDeleteAsync(int id);
        Task<IEnumerable<CustomerVm>> BlGetAll();
        IEnumerable<CustomerVm> BlGetAllCustomer();
        Task<CustomerVm> BlGetById(int? id);
        Task BlInser(CustomerVm Customer);
        Task BlUpdateAsync(CustomerVm Customer);
        bool CustomerExists(int id);
    }
}