using System.Collections.Generic;

namespace SSD_Assn.Models
{
    public interface IMessageRespository
    {
        IEnumerable<Message> Messages { get; }
    }
}
