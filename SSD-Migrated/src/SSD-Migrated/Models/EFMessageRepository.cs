using SSD_Migrated.Data;
using SSD_Migrated.Services;
using SSD_Migrated.Models.MessageModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SSD_Migrated.Models
{
    public class EFMessageRepository : IMessageRespository
    {
        private AppThreadDbContext context;

        public EFMessageRepository(AppThreadDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Message> Messages => context.Messages;
        public void SaveMessage(Message message)
        {
            
            if (message.mId == 0) /*Make sure mID changes*/
            {               
                context.Messages.Add(message);         
            }
            /*else Might have to implement to make sure we dont have duplicate threads
            {

            } */
            context.SaveChanges();
        }

    }
   
}
