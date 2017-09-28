using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayers.Models;
using Repositories.Models;

namespace BusinessLayers.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        public DomainToViewModelMappingProfile()
        {
            Configure();
        }
        protected void Configure()
        {
            CreateMap<Category, CategoryVm>()
                 .ForMember(dto => dto.ProductsVm, opt => opt.MapFrom(scr => scr.Products));
            CreateMap<Company, CompanyVm>()
                 .ForMember(dto => dto.CustomersVm, opt => opt.MapFrom(scr => scr.Customers));
            CreateMap<Customer, CustomerVm>()
                .ForMember(dto => dto.OrdersVm, opt => opt.MapFrom(scr => scr.Orders))
                 .ForMember(dto => dto.CompanysVm, opt => opt.MapFrom(scr => scr.Companys));
            var ordDetail= CreateMap<OrderDetail, OrderDetailVm>();
            ordDetail.ForMember(dest => dest.OrdersVm, opt => opt.MapFrom(src => new OrderVm
                {
                    OrderId = src.Orders.OrderId,
                    OrderNumber = src.Orders.OrderNumber,
                    OrderDate = src.Orders.OrderDate,
                    RequiredDate = src.Orders.RequiredDate,
                   OfferlDetails = src.Orders.OfferlDetails,
                    AdvancePaymentTax = src.Orders.AdvancePaymentTax,
                    Paid = src.Orders.Paid,
                    IsOffer = src.Orders.IsOffer,
                    CustomerId = src.Orders.CustomerId,
                CustomerOrdersVm = new CustomerVm {
                    FirstMidName = src.Orders.CustomerOrders.FirstMidName,
                    LastName = src.Orders.CustomerOrders.LastName,
                    ContactPerson = src.Orders.CustomerOrders.ContactPerson,
                    ContactTitle = src.Orders.CustomerOrders.ContactTitle,
                    Address = src.Orders.CustomerOrders.Address,
                    City = src.Orders.CustomerOrders.City,
                    PostCode = src.Orders.CustomerOrders.PostCode,
                    Region = src.Orders.CustomerOrders.Region,
                    Country = src.Orders.CustomerOrders.Country,
                    Phone = src.Orders.CustomerOrders.Phone,
                    Phone2 = src.Orders.CustomerOrders.Phone2,
                    Fax = src.Orders.CustomerOrders.Fax,
                    Email = src.Orders.CustomerOrders.Email,
                    Notes = src.Orders.CustomerOrders.Notes,
                    CompanysVm = new CompanyVm
                    {
                        CompanyId = src.Orders.CustomerOrders.Companys.CompanyId,
                        CompanyName = src.Orders.CustomerOrders.Companys.CompanyName,
                        Address = src.Orders.CustomerOrders.Companys.Address,
                        City = src.Orders.CustomerOrders.Companys.City,
                        PostCode = src.Orders.CustomerOrders.Companys.PostCode,
                        Region = src.Orders.CustomerOrders.Companys.Region,
                        Country = src.Orders.CustomerOrders.Companys.Country,
                        Phone = src.Orders.CustomerOrders.Companys.Phone,
                    }

                }
                }));

            ordDetail.ForMember(dto => dto.ProductsVm, opt => opt.MapFrom(scr => new ProductVm
                {
                    ProductId = scr.Products.ProductId,
                    Article = scr.Products.Article,
                    SupplierName = scr.Products.SupplierName,
                    CategoryId = (int) scr.Products.CategoryId,
                    Price = scr.Products.Price,
                    VatProduct = scr.Products.Vat,
                    Notes = scr.Products.Notes,
                CategorysVm =  new CategoryVm { CategoryId = (int) scr.Products.ProtuctCategorys.CategoryId,
                                                CategoryName = scr.Products.ProtuctCategorys.CategoryName,
                                                Description = scr.Products.ProtuctCategorys.Description,
                                                Picture = scr.Products.ProtuctCategorys.Picture}
                }));
            //ordDetail.ForMember(dto => dto.OrdersVM.CustomerOrdersVM, opt => opt.MapFrom(src => src.Orders.CustomerOrders));
            //ordDetail.ForMember(dto => dto.ProductsVM.CategorysVM, opt => opt.MapFrom(src => src.Products.ProtuctCategorys));

            //.ForMember(dto => dto.ProductsVM.CategorysVM, opt => opt.MapFrom(scr => scr.Products.ProtuctCategorys));
            //.ForMember(dto => dto.OrdersVM, opt => opt.MapFrom(scr => scr.Orders))
            // .ForMember(dto => dto.ProductsVM, opt => opt.MapFrom(scr => scr.Products));
            CreateMap<Order, OrderVm>()
               //.ForMember(dto => dto.CustomerOrdersVM, opt => opt.MapFrom(scr => scr.CustomerOrders))
               .ForMember(dest => dest.CustomerOrdersVm, opt => opt.MapFrom(src => new CustomerVm
               {
                   CustomerId = src.CustomerOrders.CustomerId,
                   FirstMidName = src.CustomerOrders.FirstMidName,
                   LastName = src.CustomerOrders.LastName
               }))
               .ForMember(dto => dto.OrderDetailsVm, opt => opt.MapFrom(scr => scr.OrderODs));
            CreateMap<Product, ProductVm>()
              .ForMember(dto => dto.OrderDetailsVm, opt => opt.MapFrom(scr => scr.ProODs))
               .ForMember(dto => dto.CategorysVm, opt => opt.MapFrom(scr => scr.ProtuctCategorys));
            var inviceInfo = CreateMap<Invoice, InvoiceVm>();
            inviceInfo.ForMember(dto => dto.CatInstVMs, opt => opt.MapFrom(scr => scr.CatInsts));
            inviceInfo.ForMember(dto => dto.CompInstVMs, opt => opt.MapFrom(scr => scr.CompInsts));
            inviceInfo.ForMember(dto => dto.CustomerInstVMs, opt => opt.MapFrom(scr => scr.CustomerInsts));
            inviceInfo.ForMember(dto => dto.OrderInstVMs, opt => opt.MapFrom(scr => scr.OrdInsts));
            inviceInfo.ForMember(dto => dto.OrdDetInstVMs, opt => opt.MapFrom(scr => scr.OrdDetInsts));
            inviceInfo.ForMember(dto => dto.ProdInstVMs, opt => opt.MapFrom(scr => scr.ProInsts));
        }
    }
}
