using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Services.Services.Interface;

namespace Services
{
    public static class DependencyInjection
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryServies, CategoryService>();
        }

    }
}
