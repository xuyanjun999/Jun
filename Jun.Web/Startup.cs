using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jun.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jun.Web
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
            services.AddDbContext<JunDbContext>(x =>
            {
                x.UseMySql("charset=utf8;server=47.94.140.80;UID=root;PWD=sa!123456;Database=eap");
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routeBuilder =>
            {
                //areas
                routeBuilder.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                //default
                routeBuilder.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
