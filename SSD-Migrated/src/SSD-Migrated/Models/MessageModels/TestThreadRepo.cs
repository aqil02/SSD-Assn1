using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSD_Migrated.Services;

namespace SSD_Migrated.Models.MessageModels
{
    public class TestThreadRepo : IMessageRespository
    {
        public IEnumerable<Message> Messages => new List<Message>
        {
            new Message { title = "Welcome to our forums", author = "System", content ="Minimum 300watts needed. Buying a mATX Case as well",mID = "1"},
            new Message { title = "Test Thread 2", author = "System", content = "Test2", mID = "2" },
            new Message { title = "Test Thread 3", author = "System", content = "Test3", mID = "3" }


        };
    }
}
