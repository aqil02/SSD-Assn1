using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SSD_Migrated.Models.MessageModels;
using SSD_Migrated.Services;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SSD_Migrated.Models;

namespace SSD_Migrated.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRespository repository; /* Private copy of message repository */
        private UserManager<ApplicationUser> _usermanager;

        public MessageController(IMessageRespository repo,UserManager<ApplicationUser> usermanager)
        {
            repository = repo;
            _usermanager = usermanager;
        }
        public ViewResult List() => View(repository.Messages);
        
        public ViewResult Thread(int mid)
        {
            
            foreach (var p in repository.Messages)
            {
                //HTML Tag Filters
                var filteredcontent = Regex.Replace(p.content, "<.*?>", string.Empty);
                var filteredtitle = Regex.Replace(p.title, "<.*?>", string.Empty);
                var threadlist = repository.Messages.Where(x => x.tId == p.tId);
                threadlist = threadlist.OrderBy(x => x.pId);
                if (p.mId == mid)
                    {
                    ViewData["Message"] = filteredcontent;
                    ViewData["Author"] = p.author;
                    ViewData["Title"] = filteredtitle;
                    ViewData["tId"] = p.tId;
                    ViewData["threadlist"] = threadlist;            
                    }
            }
            return View();
        }
        public IActionResult CreateThread()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateThread(Message message)
        {
            if (ModelState.IsValid)
            {
                message.author = _usermanager.GetUserName(User);
                message.pId = 0;
                //Change tId to be representitive of each thread
                var newtId = repository.Messages.Max(x => x.tId);
                newtId = newtId + 1;
                message.tId = newtId;
                repository.SaveMessage(message);
                return RedirectToAction("List");
            }
            else
            {
                //Damn there's problems with the data
                return View("List");
            }
        }
        [HttpPost]
        public IActionResult Reply(Message message)
        {
            //Change Author to currrent-user here
            message.author = _usermanager.GetUserName(User);
            //Change tId to be max+1 here where mId is the same as the curent thread(Yup definitely need to pass current mId)
            IEnumerable<Message> newtIdList = repository.Messages.Where(x => x.tId == message.tId); //Compares and returns messages with tId same as the one passed to me from thread
            var finalIdObj = newtIdList.Max(x => x.pId); //Object with the highest tId in that mId
            finalIdObj = finalIdObj + 1;
            message.pId = finalIdObj;
            //Finally save the message to the database
            repository.SaveMessage(message);
            return RedirectToAction("Thread",new { tId = message.tId }); //Change to bring back to current thread (Maybe pass current mId to Reply?
        }
        
    }
}
