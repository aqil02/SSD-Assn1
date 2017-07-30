using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SSD_Migrated.Models.MessageModels
{
    public class Message
    {
        [Key]
        public int mId { get; set; }

        public string title { get; set; }
        public string author { get; set; }
        public string content { get; set; }
        /* TODO: Timestamp */
        public int tId { get; set; } = 0;
    }
}
