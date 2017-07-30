using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SSD_Migrated.Data;

namespace SSD_Migrated.Models.MessageModels
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppThreadDbContext context = app.ApplicationServices.GetRequiredService<AppThreadDbContext>();
            if (!context.Messages.Any())
            {
                context.Messages.Add(new Message { author = "System", title = "Welcome to the forums!", content = "We hope you enjoy your time browsing these forums"});
            }
            context.SaveChanges();
        }
    }
}
