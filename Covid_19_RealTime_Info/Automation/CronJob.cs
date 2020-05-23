using Covid_19_RealTime_Info.Interfaces;
using Covid_19_RealTime_Info.Persistence;
using Covid_19_RealTime_Info.Services;
using Covid_19_RealTime_Info.SignalR.Hubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_RealTime_Info.Automation
{
    public class CronJob
    {
        private readonly ICovid19Info covid19Info;
        private readonly Covid19InfoHub hub;
        private readonly Covid19RealTimeInfoDbContext context;
        public CronJob(IWebHostEnvironment host, Covid19RealTimeInfoDbContext context)
        {
            this.covid19Info = new Covid19Info();
            this.hub = new Covid19InfoHub();
            this.context = context;
        }

        public async Task GetCovid19Info()
        {
            try
            {
                var responseBody = await covid19Info.GetCovid19Info();
                await hub.UpdateCovid19Info(responseBody);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
