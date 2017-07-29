using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSD_Migrated.Models.MessageModels;
namespace SSD_Migrated.Data
{
    public class AppThreadDbContext : DbContext
    {
        public AppThreadDbContext(DbContextOptions<AppThreadDbContext> options)
            : base(options) {}
        public DbSet<Message> Messages { get; set; }
    }
    
}
