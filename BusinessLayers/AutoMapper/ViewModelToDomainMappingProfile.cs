using AutoMapper;
using BusinessLayers.Models;
using Repositories.Models;

namespace BusinessLayers.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        public ViewModelToDomainMappingProfile()
        {
            Configure();
        }
       
        protected void Configure()
        {
            CreateMap<CategoryVm, Category>()
                 .ForMember(dto => dto.Products, opt => opt.MapFrom(scr => scr.ProductsVm));
            CreateMap<CompanyVm, Company>()
                 .ForMember(dto => dto.Customers, opt => opt.MapFrom(scr => scr.CustomersVm));
            CreateMap<CustomerVm, Customer>()
                .ForMember(dto => dto.Orders, opt => opt.MapFrom(scr => scr.OrdersVm))
                 .ForMember(dto => dto.Companys, opt => opt.MapFrom(scr => scr.CompanysVm));
            var ordDetailVm = CreateMap<OrderDetailVm, OrderDetail>();
            ordDetailVm.ForMember(dest => dest.Orders, opt => opt.MapFrom(src => new Order
                {
                OrderId = src.OrdersVm.OrderId,
                    OrderNumber = src.OrdersVm.OrderNumber,
                    OrderDate = src.OrdersVm.OrderDate,
                    RequiredDate = src.OrdersVm.RequiredDate,
                    OfferlDetails = src.OrdersVm.OfferlDetails,
                    AdvancePaymentTax = src.OrdersVm.AdvancePaymentTax,
                    Paid = src.OrdersVm.Paid,
                    CustomerId = src.OrdersVm.CustomerId,
                CustomerOrders = new Customer
                    {
                    FirstMidName = src.OrdersVm.CustomerOrdersVm.FirstMidName,
                        LastName = src.OrdersVm.CustomerOrdersVm.LastName,
                        ContactPerson = src.OrdersVm.CustomerOrdersVm.ContactPerson,
                        ContactTitle = src.OrdersVm.CustomerOrdersVm.ContactTitle,
                        Address = src.OrdersVm.CustomerOrdersVm.Address,
                        City = src.OrdersVm.CustomerOrdersVm.City,
                        PostCode = src.OrdersVm.CustomerOrdersVm.PostCode,
                        Region = src.OrdersVm.CustomerOrdersVm.Region,
                        Country = src.OrdersVm.CustomerOrdersVm.Country,
                        Phone = src.OrdersVm.CustomerOrdersVm.Phone,
                        Phone2 = src.OrdersVm.CustomerOrdersVm.Phone2,
                        Fax = src.OrdersVm.CustomerOrdersVm.Fax,
                        Email = src.OrdersVm.CustomerOrdersVm.Email,
                        Notes = src.OrdersVm.CustomerOrdersVm.Notes,
                }
                }));
            ordDetailVm.ForMember(dto => dto.Products, opt => opt.MapFrom(scr => new Product
            {
                ProductId = scr.ProductsVm.ProductId,
                Article = scr.ProductsVm.Article,
                SupplierName = scr.ProductsVm.SupplierName,
                CategoryId = (int)scr.ProductsVm.CategoryId,
                Price = scr.ProductsVm.Price,
                Vat = scr.ProductsVm.VatProduct,
                Notes = scr.ProductsVm.Notes,
                ProtuctCategorys = new Category
                {
                    CategoryId = (int)scr.ProductsVm.CategorysVm.CategoryId,
                    CategoryName = scr.ProductsVm.CategorysVm.CategoryName,
                    Description = scr.ProductsVm.CategorysVm.Description,
                    Picture = scr.ProductsVm.CategorysVm.Picture
                }
            }));
            //.ForMember(dto => dto.Orders, opt => opt.MapFrom(scr => scr.OrdersVm))
            // .ForMember(dto => dto.Products, opt => opt.MapFrom(scr => scr.ProductsVm));
            CreateMap<OrderVm, Order>()
               //.ForMember(dto => dto.CustomerOrders, opt => opt.MapFrom(scr => scr.CustomerOrdersVM))
               .ForMember(dest => dest.CustomerOrders, opt => opt.MapFrom(src => new Customer
               {
                   CustomerId = src.CustomerOrdersVm.CustomerId,
                   FirstMidName = src.CustomerOrdersVm.FirstMidName,
                   LastName = src.CustomerOrdersVm.LastName
               }))
               .ForMember(dto => dto.OrderODs, opt => opt.MapFrom(scr => scr.OrderDetailsVm));
            CreateMap<ProductVm, Product>()
              .ForMember(dto => dto.ProODs, opt => opt.MapFrom(scr => scr.OrderDetailsVm))
               .ForMember(dto => dto.ProtuctCategorys, opt => opt.MapFrom(scr => scr.CategorysVm));

            var inviceInfo = CreateMap<InvoiceVm, Invoice>();
            inviceInfo.ForMember(dto => dto.CatInsts, opt => opt.MapFrom(scr => scr.CatInstVMs));
            inviceInfo.ForMember(dto => dto.CompInsts, opt => opt.MapFrom(scr => scr.CompInstVMs));
            inviceInfo.ForMember(dto => dto.CustomerInsts, opt => opt.MapFrom(scr => scr.CustomerInstVMs));
            inviceInfo.ForMember(dto => dto.OrdInsts, opt => opt.MapFrom(scr => scr.OrderInstVMs));
            inviceInfo.ForMember(dto => dto.OrdDetInsts, opt => opt.MapFrom(scr => scr.OrdDetInstVMs));
            inviceInfo.ForMember(dto => dto.ProInsts, opt => opt.MapFrom(scr => scr.ProdInstVMs));
        }
    }
}
