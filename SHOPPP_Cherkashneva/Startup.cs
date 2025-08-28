using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SHOPPP_Cherkashneva.Data.DataBase;
using SHOPPP_Cherkashneva.Data.Interfaces;
using SHOPPP_Cherkashneva.Data.Models;
using System.Collections.Generic;

namespace SHOPPP_Cherkashneva
{
    public class Startup
    {
        public static List<ItemsBasket> BasketItem = new List<ItemsBasket>();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IItems, BDItems>();
            services.AddTransient<ICategorys, DBCategorys>();


            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
