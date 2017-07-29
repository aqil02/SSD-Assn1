using SSD_Migrated.Data;
using SSD_Migrated.Services;
using System.Collections.Generic;


namespace SSD_Migrated.Models
{
    public class EFMessageRepository : IMessageRespository
    {
        private AppThreadDbContext context;

        public EFMessageRepository(AppThreadDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<MessageModels.Message> Messages => context.Messages;
    }
   
}
