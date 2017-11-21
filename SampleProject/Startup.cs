﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACB.FCMPushNotifications;
using ACB.FCMPushNotifications.Data;
using ACB.FCMPushNotifications.Data.Abstractions;
using ACB.FCMPushNotifications.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleProject
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
            services.AddDbContext<NotifServerDbContext>(builder =>
                builder.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), 
                    opts => opts.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name)));

            services.AddScoped(typeof(IUserDeviceRepository), typeof(UserDeviceRepository));
            services.AddScoped(typeof(IFcmPushNotificationService), typeof(FcmPushNotificationService));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
