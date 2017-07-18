using System.Diagnostics;

namespace ConfiguringApps.Infrastructure
{
    public class UptimeServices
    {
        private Stopwatch timer;

        public UptimeServices()
        {
            timer = Stopwatch.StartNew();
        }
        public long Uptime => timer.ElapsedMilliseconds;
    }
    
}
