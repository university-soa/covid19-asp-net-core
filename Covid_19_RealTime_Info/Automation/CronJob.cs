using Covid_19_RealTime_Info.Interfaces;
using Covid_19_RealTime_Info.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Covid_19_RealTime_Info.Automation
{
    public class CronJob : ICronJob
    {
        private readonly ICovid19Info covid19Info;
        private readonly IHubContext<Covid19InfoHub, ICovid19InfoHub> hub;

        public CronJob(ICovid19Info covid19Info, IHubContext<Covid19InfoHub, ICovid19InfoHub> hub)
        {
            this.covid19Info = covid19Info;
            this.hub = hub;
        }

        public async Task GetCovid19Info()
        {
            try
            {
                var content = await covid19Info.GetCovid19Info();
                await hub.Clients.All.UpdateCovid19Info(content);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
