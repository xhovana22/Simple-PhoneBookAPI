using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PhoneBook.DAL.Repository;
using PhoneBook.DAL.Repository.Interface;
using PhoneBook.SL.DTO.Mappings;
using PhoneBook.SL.Interface;
using AutoMapper;
using PhoneBook.SL.Services;

namespace PhoneBookApi
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
            services.AddControllers();

            //DI
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddScoped<IPhoneBookService, PhoneBookService>();


            //Added automapper service 
            services.AddAutoMapper(typeof(Mappings));


            //Added Smagger service
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("PhoneBookAPI",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Phone Book API",
                        Version = "1",
                         Contact = new OpenApiContact
                         {
                             Name = "Xhovana Gjinaj",
                             Email = "xgjinaj16@epoka.edu.al",
                             Url = new Uri("https://www.linkedin.com/in/xhovana-gjinaj-971653145/"),
                         }
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

            app.UseHttpsRedirection();

            //added Swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/PhoneBookAPI/swagger.json", "Phone Book API");
                options.RoutePrefix = "";
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
