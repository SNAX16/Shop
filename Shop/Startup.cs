using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfacas;
using Shop.Data.Models;
using Shop.Data.Repository;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot confString;
        public Startup(IHostEnvironment hostEnv)
        {
            confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();


        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars,CarRepository>();
            services.AddTransient<ICarsCategory,CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // app.UseDeveloperExceptionPage();
            //  app.UseStatusCodePages();
            //  app.UseStaticFiles();
            // app.UseMvcWithDefaultRoute();
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {   endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("categoryFilter", "Car/{action}/{category?}", defaults: new { Controllers="Car",action = "List"});
            });

          
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

           
        }
    }
}
