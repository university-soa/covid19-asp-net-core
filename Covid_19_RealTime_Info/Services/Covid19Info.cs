using Covid_19_RealTime_Info.Interfaces;
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
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (System.Exception e)
            {

                throw new System.Exception(e.Message);
            }
        }
    }
}
