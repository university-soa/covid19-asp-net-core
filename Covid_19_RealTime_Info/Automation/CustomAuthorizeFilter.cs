using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Covid_19_RealTime_Info.Automation
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}

