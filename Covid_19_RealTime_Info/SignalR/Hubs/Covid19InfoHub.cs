using System.Threading.Tasks;
using Covid_19_RealTime_Info.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace Covid_19_RealTime_Info.SignalR.Hubs
{
    public class Covid19InfoHub : Hub<ICovid19InfoHub>
    {
        public async Task Update(string content) // We call Update(string content) from the client app
        {
            // UpdateCovid19Info(string content) will be called in the client app (function in the client app)
            await Clients.All.UpdateCovid19Info(content);
        }
    }
}
