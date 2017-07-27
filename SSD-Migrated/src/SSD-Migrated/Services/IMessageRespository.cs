using System.Collections.Generic;
using SSD_Migrated.Models.MessageModels;

namespace SSD_Migrated.Services
{
    public interface IMessageRespository
    {
        IEnumerable<Message> Messages { get; }
    }
}
