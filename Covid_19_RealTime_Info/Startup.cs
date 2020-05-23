using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid_19_RealTime_Info.Automation;
using Covid_19_RealTime_Info.Interfaces;
using Covid_19_RealTime_Info.Persistence;
using Covid_19_RealTime_Info.Services;
using Covid_19_RealTime_Info.SignalR.Hubs;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Covid_19_RealTime_Info
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
            services.AddScoped<ICovid19Info, Covid19Info>();

            services.AddControllers();
            services.AddSignalR();
            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials()
                      .WithOrigins("http://localhost:8080");
                });
            });

            services.AddHangfire(config =>
            config.UseSqlServerStorage(Configuration.GetConnectionString("Default")));
            services.AddDbContext<Covid19RealTimeInfoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("VueCorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new[] { new CustomAuthorizeFilter() }
            });

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<Covid19InfoHub>("/covid19Info"); // Use Covid19InfoHub class
            });

            var optionsBuilder = new DbContextOptionsBuilder<Covid19RealTimeInfoDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));
            var context = new Covid19RealTimeInfoDbContext(optionsBuilder.Options);
            var job = new CronJob(env, context);

            //local time
            RecurringJob.AddOrUpdate(
                () => job.GetCovid19Info(),
                Cron.Minutely(),
                TimeZoneInfo.Local);
        }
    }
}
