using back_end.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace back_end
{
    public static class DependencyInjection
    {
        public static IMvcBuilder AddProjectApplication(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddApplicationPart(Assembly.GetExecutingAssembly());
            return mvcBuilder;
        }

        public static IServiceCollection AddEShopAdminApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddDbContext<Context>(o => o.UseSqlServer(configuration.GetConnectionString("Project")));
            /*services.AddDbContext<EshopContext>(o => o.UseSqlServer(configuration.GetConnectionString("ESHOP")));
            services.AddDbContext<NavKikaEeContext>(o => o.UseSqlServer(configuration.GetConnectionString("NAV")));
            services.AddDbContext<NavKikaLtContext>(o => o.UseSqlServer(configuration.GetConnectionString("NAV")));

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISalesChannelsService, SalesChannelsService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IShopsService, ShopsService>();
            services.AddTransient<ILocationsService, LocationsService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ISKUService, SKUService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<ILogService, LogService>();
            services.TryAddTransient<IOrderPaymentsService, OrderPaymentsService>();

            services.AddScoped<Intranet.IApp, App>();*/

            return services;
        }
    }
}
