global using  Microsoft.EntityFrameworkCore;
global using System.Collections.Generic;
global using System.Threading.Tasks;
global using System.Linq;

global using WebApi.Models;
global using WebApi.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Startup
    {
        private string ConnectionString = "Data Source=91.219.6.251\\SQLEXPRESS; Initial Catalog=Otus; User Id=otuslogin; Password=1234";
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<AppFactory>(
                options => options.UseSqlServer(ConnectionString));
            
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