using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Netflix.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix
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
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddLamar(new ApplicationRegistry());
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v0", new OpenApiInfo { Title = "Netflix Service", Version = "v0" });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Netflix.xml");
               
                swag.DescribeAllEnumsAsStrings();
                swag.DescribeAllParametersInCamelCase();
                swag.CustomSchemaIds(i => i.FullName);
            });
            services.AddDbContext<NetflixDbContext>(options => options.UseSqlServer(Configuration["database:connection"], b => b.MigrationsAssembly("Netflix")));

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authentication}/{action=Login}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("v0/swagger.json", "Netflix Service"));
        }
    }
}
