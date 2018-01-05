using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using ContactApp.Data;
using ContactApp.API.Core.Extensions;
using ContactApp.Data.Infrastructure;
using ContactApp.Services.Customers;
using ContactApp.Services.Enquiries;
using ContactApp.API.Infrastructure.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Buffers;

namespace ContactApp.API
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
            #region Coonection strings

            //Get connection string
            string sqlConnectionString = Configuration.GetConnectionString("ContactAppConnection");

            //InMemory provider config.
            bool useInMemoryProvider = bool.Parse(Configuration["AppSettings:InMemoryProvider"]);
            string inMemoryDb = Guid.NewGuid().ToString();
            string EfMigrationAssemblyName = Configuration["AppSettings:EfMigrationAssemblyName"];

            //Entity Framework contexts added to the services container.
            //AddDbContext internally uses Scoped lifetime.
            services.AddDbContext<ContactAppContext>(options =>
            {
                switch (useInMemoryProvider)
                {
                    case true:
                        options.UseInMemoryDatabase(inMemoryDb);
                        break;
                    default:
                        // Set connection string and inform EF about the assembly("ContactUs.API") 
                        // to be used for migrations explicitly.
                        options.UseSqlServer(sqlConnectionString,
                        optionsBuilder => optionsBuilder.MigrationsAssembly(EfMigrationAssemblyName));

                        /* options.UseSqlServer(sqlConnectionString,
                                             optionsBuilder => optionsBuilder
                                             .MigrationsAssembly(typeof(ContactAppContext)
                                                                 .GetTypeInfo().Assembly
                                                                 .GetName().Name)); */
                        break;
                }
            });

            //Inialize IdbContext as well as it is widely used in application.
            services.AddScoped<IDbContext, ContactAppContext>(
                provider => (ContactAppContext)provider.GetService(typeof(ContactAppContext)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEnquiryService, EnquiryService>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            #endregion

            // Automapper configuration
            // Register automapper as an instance instead of static for better unit testing.
            ServiceCollectionExtensions.UseStaticRegistration = false;
            services.AddAutoMapper();

            //Add CORS
            services.AddCors();

            // Add only core feature & prevent json reference looping.
            services.AddMvcCore()
                    .AddFormatterMappings()
                    .AddJsonFormatters()
                    .AddJsonOptions(options =>
                                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)


                    .AddApiExplorer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Development configuration
                //app.UseDeveloperExceptionPage();

            }
            else
            {
                // Staging/Production configuration
                // when an exception occurs, route to /Error
                //app.UseExceptionHandler("/Error");
            }

            // Configure global exception handler for web API
            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                  async context =>
                  {
                      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                      var error = context.Features.Get<IExceptionHandlerFeature>();
                      if (error != null)
                      {
                          context.Response.AddApplicationError(error.Error.Message);

                          await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                      }
                  });
            });

            //Enable static file response.
            app.UseStaticFiles();

            //Enable CORS.
            app.UseCors(builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());

            //Enable routing.
            // Attribute routing.

            app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }
    }
}

