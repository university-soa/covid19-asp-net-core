using Microsoft.EntityFrameworkCore;

namespace Covid_19_RealTime_Info.Persistence
{
    public class Covid19RealTimeInfoDbContext : DbContext
    {
        public Covid19RealTimeInfoDbContext(DbContextOptions<Covid19RealTimeInfoDbContext> options)
            : base(options)
        {

        }
    }
}
