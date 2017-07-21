using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConfiguringApps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate nextDelegate;
    }
    public ShortCircuitMiddleware(RequestDelegate next)
    {
        nextDelegate = next;
    }
}
