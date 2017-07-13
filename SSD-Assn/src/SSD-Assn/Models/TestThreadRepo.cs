using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD_Assn.Models
{
    public class TestThreadRepo : IMessageRespository
    {
        public IEnumerable<Message> Messages => new List<Message>
        {
            new Message { title = "Welcome to our forums", author = "System", content ="Test",},
            new Message { title = "Test Thread 2", author = "System", content = "Test2" },
            new Message { title = "Test Thread 3", author = "System", content = "Test3" }


        };
    }
}
