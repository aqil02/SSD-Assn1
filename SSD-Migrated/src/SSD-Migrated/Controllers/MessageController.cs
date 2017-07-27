using Microsoft.AspNetCore.Mvc;
using SSD_Migrated.Models.MessageModels;
using SSD_Migrated.Services;

namespace SSD_Migrated.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRespository repository; /* Private copy of message repository */

        public MessageController(IMessageRespository repo)
        {
            repository = repo;
        }
        public ViewResult List() => View(repository.Messages);

        public ViewResult Thread(string title)
        {
            ViewData["Title"] = title;
            foreach (var p in repository.Messages)
            {
                if (p.title.Contains (title))
                    {
                    ViewData["Message"] = p.content;
                    ViewData["Author"] = p.author;
                    }
            }
            return View();
        }
    }
}
