using Covid_19_RealTime_Info.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid_19_RealTime_Info.Services
{
    public class Covid19Info : ICovid19Info
    {
        static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetCovid19Info()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://api.covid19api.com/world/total");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
