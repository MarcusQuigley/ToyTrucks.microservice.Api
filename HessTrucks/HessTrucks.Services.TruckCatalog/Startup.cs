using HessTrucks.Services.TruckCatalog.DbContexts;
using HessTrucks.Services.TruckCatalog.Repositories;
using Microsoft.AspNetCore.Builder;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace HessTrucks.Services.TruckCatalog
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

            //services.AddControllers()                
            //    .AddNewtonsoftJson(setupAction => {
            //    setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    setupAction.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //}).AddXmlDataContractSerializerFormatters();

            services.AddControllers(options=> {
                options.ReturnHttpNotAcceptable = true;
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
            })//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            ;

            services.AddDbContext<TruckCatalogDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("TruckDBConnectionString"))
                     .EnableSensitiveDataLogging()
                     );

            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddGrpc(opt=> {
            //    opt.EnableDetailedErrors = true;
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HessTrucks.Services.TruckCatalog", Version = "v1" });
            }); 
          }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HessTrucks.Services.TruckCatalog v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //rest
             //   endpoints.MapGrpcService<TruckGrpcService>(); // grpc
            });
         }
    }
}
