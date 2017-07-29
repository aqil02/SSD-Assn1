using SSD_Migrated.Data;
using SSD_Migrated.Services;
using SSD_Migrated.Models.MessageModels;
using System.Collections.Generic;
using System.Linq;



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
        private int tempID;
        public void SaveMessage(Message message)
        {
            
            if (message.mId == 0) /*Make sure mID changes*/
            {
                /*var MaxID = (from p in context.Messages select p.mId).Max();
                MaxID = MaxID + 1; 
                message.mId = MaxID; */
                message.author = "Placeholder";
                context.Messages.Add(message);         
            }
            /*else Might have to implement to make sure we dont have duplicate threads
            {

            } */
            context.SaveChanges();
        }

    }
   
}
