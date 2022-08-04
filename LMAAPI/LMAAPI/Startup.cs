using LMAAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMAAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LmaApiContext>(opt => opt.UseInMemoryDatabase("LoanApplication"));
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Loan Management Application Service API",
                    Version = "v1",
                    Description = "Loan Management Application Service",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Loan Management Application Service"));
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<LmaApiContext>();
            LmaTestData(context);
        }

        private static void LmaTestData(LmaApiContext context)
        {
            var User1 = new Model.Login
            {
                Username = "admin",
                Password = "admin",
                Role = "admin"
            };
           
            var User2 = new Model.Login
            {
                Username = "user",
                Password = "user",
                Role = "user"
            };
            context.Logins.Add(User1);
            context.Logins.Add(User2);
            context.SaveChanges();
        }
    }
   
}
