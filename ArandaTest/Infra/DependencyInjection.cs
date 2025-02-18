using EntityFreamWorkBD.Data;
using Infra.Category;
using Infra.Interface;
using Infra.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependencyInjection
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArandaTestDbContext>(db => db.UseSqlServer("ArandaTestContext"));

            services.AddTransient<IProductSave, ProductSave>();
            services.AddTransient<IProductGet, ProductGet>();
            services.AddTransient<IProductUpdate, ProductUpdate>();
            services.AddTransient<IProductDelete, ProductDelete>();
            services.AddTransient<ICategoryGet, CategoryGet>();
            services.AddTransient<ICategorySave, CategorySave>();
        }
    }
}
