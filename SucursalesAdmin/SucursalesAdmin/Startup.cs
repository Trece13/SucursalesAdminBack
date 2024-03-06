using DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SucursalesAdmin
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

            services.AddControllers();
            services.AddDbContext<MyDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SucursalesConnection"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SucursalesAdmin", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext dbContext)
        {

            app.UseCors(builder =>
        builder.WithOrigins("http://localhost:4200", "https://localhost:44345")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SucursalesAdmin v1"));
            }

            dbContext.Database.Migrate();
                
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
