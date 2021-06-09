using Backend.Extensions;
using Backend.Helpers;
using Backend.Middleware;
using Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json;

namespace Backend
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            });

            services.AddAutoMapper(typeof(MappingProfiles));

            // EF CORE
            //services.AddDbContext<StoreContext>(opts => opts.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            //services.AddScoped<IUnitOfWork, InfrastructureEF.Data.UnitOfWork>();

            // LiteDB
            //services.AddScoped<LiteDbContext, LiteDbContext>();
            //services.AddScoped<IUnitOfWork, InfrastructureLiteDB.Data.UnitOfWork>();

            // JSON
            //services.AddScoped<IUnitOfWork, InfrastructureJson.Data.UnitOfWork>();

            services.AddApplicationServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend v1"));
            }

            app.UseMiddleware<ErrorMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
