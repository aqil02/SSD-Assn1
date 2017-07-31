using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Migrated.Models.MessageModels
{
    public class ThreadViewModel
    {
        public IEnumerable<Message> MessagesI { get; set; }
        public Message Message { get; set; }
    }
}
