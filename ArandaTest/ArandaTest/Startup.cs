using ArandaTest.Extensions;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ArandaTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ArandaTest.API", Version = "V1" });
                c.CustomSchemaIds(ShemaIdStrategy);
                c.OperationFilter<CustomFilters.AddheaderFilter>();
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc();
            services.AddInfra(Configuration);
            services.AddService();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
        }
        private string ShemaIdStrategy(Type currentClass)
        {
            return currentClass.Name.EndsWith("Model") ? currentClass.Name.Replace("Model", string.Empty) : currentClass.Name;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "ArandaTest.API");
                c.InjectStylesheet("./swagger-ui/custom.css");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
