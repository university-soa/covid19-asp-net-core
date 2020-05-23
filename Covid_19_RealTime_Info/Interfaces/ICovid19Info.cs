using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_RealTime_Info.Interfaces
{
    public interface ICovid19Info
    {
        Task<string> GetCovid19Info();
    }
}
