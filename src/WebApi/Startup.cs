global using  Microsoft.EntityFrameworkCore;
global using System.Collections.Generic;
global using System.Threading.Tasks;
global using WebApi.Models;
global using WebApi.Repository;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            // Контекст для работы с БД
            services.AddDbContextFactory<AppFactory>(
                options => options.UseSqlServer("name=ConnectionStrings:WebApiDatabase"));
            
            services.AddScoped(typeof(IRepository<>), typeof(RepoEF<>));
            
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}