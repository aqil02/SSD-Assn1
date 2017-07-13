using Microsoft.AspNetCore.Mvc;
using SSD_Assn.Models;

namespace SSD_Assn.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRespository repository; /* Private copy of message repository */

        public MessageController(IMessageRespository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Messages);
    }
}
