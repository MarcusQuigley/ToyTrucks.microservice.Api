using HessTrucks.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HessTrucks.Web
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
            services.AddRazorPages();
            services.AddControllersWithViews(config =>
            {
                //config.OutputFormatters.Insert(0, new XmlSerializerOutputFormatter());
                //config.InputFormatters.Insert(0, new XmlSerializerInputFormatter(config));
            })
            .AddRazorRuntimeCompilation();

            services.AddHttpClient<ITruckCatalogService, TruckCatalogService>();// (config =>
            //{
            //    config.BaseAddress = new Uri(Configuration["ApiConfigs:TruckCatalog:Uri"]);
            //    config.Timeout = new TimeSpan(0, 0, 30);
            //    config.DefaultRequestHeaders.Clear();//best practice
            //    config.DefaultRequestHeaders.Accept.Add(
            //        new MediaTypeWithQualityHeaderValue("application/json"));
            //    //config.DefaultRequestHeaders.Accept.Add(
            //    //    new MediaTypeWithQualityHeaderValue("application/xml"));


            //});
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
