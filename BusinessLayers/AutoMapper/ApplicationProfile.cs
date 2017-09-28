using AutoMapper;
using BusinessLayers.Models;
using Repositories.Models;

namespace BusinessLayers.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Category, CategoryVm>()
                .ReverseMap();
            CreateMap<Company, CompanyVm>()
               .ReverseMap();
            CreateMap<Customer, CustomerVm>()
               .ReverseMap();
            CreateMap<Order, OrderVm>()
               .ReverseMap();
            CreateMap<OrderDetail, OrderDetailVm>()
               .ReverseMap();
            CreateMap<Product, ProductVm>()
               .ReverseMap();
        }
    }
}
