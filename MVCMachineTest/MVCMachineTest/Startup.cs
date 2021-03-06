using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCMachineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest
{
    public class Startup
    {
        public IConfiguration Config { get; }

        public Startup(IConfiguration _config)
        {
            Config = _config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => { options.UseSqlServer(Config.GetConnectionString("SqlDbPath")); });
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseMvcWithDefaultRoute();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
