using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayers.AutoMapper;
using BusinessLayers.MapperClass;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.IRepositories;

namespace Invoice
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InvoiceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            AutoMapperConfig.RegisterMappings();

            services.AddTransient<ICategoryMapper, CategoryMapper>();
            services.AddTransient<ICompanyMapper, CompanyMapper>();
            services.AddTransient<ICustomerMapper, CustomerMapper>();
            services.AddTransient<IOrderMapper, OrderMapper>();
            services.AddTransient<IOrderDetailMapper, OrderDetailMapper>();
            services.AddTransient<IProductMapper, ProductMapper>();
            services.AddTransient<IInvoiceMapper, InvoiceMapper>();

            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ICompany, CompanyRepository>();
            services.AddTransient<ICustomer, CustomerRepository>();
            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<IOrderDetail, OrderDetailRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IInvoice, InvoiceRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
