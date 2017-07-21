using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeServices uptime;

        public HomeController(UptimeServices up)
        {
            uptime = up;
        }
        public ViewResult Index()
            => View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index Action",
                ["Uptime"] = $"{uptime.Uptime}ms"
            });
    }
}
