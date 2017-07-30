using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Migrated.Models.MessageModels
{
    public class ThreadViewModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public Message MessageObj { get; set; }
    }
}
