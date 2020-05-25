using System.Threading.Tasks;

namespace Covid_19_RealTime_Info.Interfaces
{
    public interface ICronJob
    {
        Task GetCovid19Info();
    }
}
