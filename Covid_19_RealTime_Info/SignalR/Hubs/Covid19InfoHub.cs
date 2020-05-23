using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Covid_19_RealTime_Info.SignalR.Hubs
{
    public class Covid19InfoHub : Hub
    {
        public async Task UpdateCovid19Info(string text) // We call UpdateCovid19Info() from the client app
        {
            // UpdateCovid19Info(string text) will be called in the client app (function in the client app)
            await Clients.All.SendAsync("UpdateCovid19Info", text);
        }
    }
}
