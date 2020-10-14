using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PrestiProject_DataAccess.Dapper;
using PrestiProject_Models.Interfaces;
using PrestiProject_Models.Models;
using PrestiProject_Models.Services;
using PrestiProject_Models.Services.Interfaces;

namespace PresrtiProject_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new JsonCustomConverter<IAddress>());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            /* all the injection services is done here */
            InjectServices(services);
        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseCors(x=> x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseMvc();
        }

        public void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IDataBaseManager, SQL_DataBase>();
            services.AddTransient<INotificationProvider, NotificationProvider>();

            services.AddTransient<IAddresseService, AddresseService>();
            services.AddTransient<IAddress, Address>();

            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<ICompany, Company>();

            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<ICustomer, Customer>();

            services.AddTransient<IDesignService, DesignService>();
            services.AddTransient<IDesign, Design>();

            services.AddTransient<IEmployee_Work_DetailsService, Employee_Work_DetailsService>();
            services.AddTransient<IEmployee_Work_Details, Employee_Work_Details>();

            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IEmployee, Employee>();

            services.AddTransient<IFilesService, FilesService>();
            services.AddTransient<IFile, File>();

            services.AddTransient<IOrder_DetailsService, Order_DetailsService >();
            services.AddTransient<IOrder_Details, Order_Details>();

            services.AddTransient<IProduct_BrandService, Product_BrandService>();
            services.AddTransient<IProduct_Brand, Product_Brand>();

            services.AddTransient<IProduct_CategoryService, Product_CategoryService>();
            services.AddTransient<IProduct_Category, Product_Category>();

            services.AddTransient<IProduct_Command_DetailsService, Product_Command_DetailsService>();
            services.AddTransient<IProduct_Command_Details, Product_Command_Details>();

            services.AddTransient<IProduct_CommandService, Product_CommandService>();
            services.AddTransient<IProduct_Command, Product_Command>();

            services.AddTransient<IProduct_CompositionService, Product_CompositionService>();
            services.AddTransient<IProduct_Composition, Product_Composition>();

            services.AddTransient<IProduct_StockService, Product_StockService>();
            services.AddTransient<IProduct_Stock, Product_Stock>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProduct, Product>();

            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IProject, Project>();

            services.AddTransient<IPropertiesService, PropertiesService>();
            services.AddTransient<IProperty, Property>();

            services.AddTransient<IService_CallsService, Service_CallsService>();
            services.AddTransient<IService_Call, Service_Call>();

            services.AddTransient<ISuppliersService, SuppliersService>();
            services.AddTransient<ISupplier, Supplier>();

            services.AddTransient<IUsed_Products_DetailsService, Used_Products_DetailsService>();
            services.AddTransient<IUsed_Products_Details, Used_Products_Details>();

            services.AddTransient<IColorsService, ColorsService>();
            services.AddTransient<IColor, Color>();
        }
    }
}
