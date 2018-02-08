using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jun.Core.Dependency;
using Jun.Core.Modules;
using Jun.Data.Context;
using Jun.Data.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<JunDbContext>(x =>
            {
                x.UseMySql("charset=utf8;server=47.94.140.80;UID=root;PWD=sa!123456;Database=eap");
            });

            services.AddSession();


            var mvcBuilder = services.AddMvc();

            mvcBuilder.AddJsonOptions(opt =>
            {
                opt.SerializerSettings.Formatting = Formatting.Indented;
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new DefaultNamingStrategy() };
            });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
            });



            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterModule<JunModule>();

            builder.RegisterModule<DataModule>();

            builder.RegisterModule<ServiceModule>();

            IocManager.Instance.Container = builder.Build();

            return new AutofacServiceProvider(IocManager.Instance.Container);

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

            app.UseSession();

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
