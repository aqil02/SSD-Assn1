using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SSD_Migrated.Models.MessageModels;
using SSD_Migrated.Services;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SSD_Migrated.Models;
using Ganss.XSS;

namespace SSD_Migrated.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRespository repository; /* Private copy of message repository */
        private UserManager<ApplicationUser> _usermanager;
        private SignInManager<ApplicationUser> _signinmanager;

        public MessageController(IMessageRespository repo,UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signinmanager)
        {
            repository = repo;
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        public ViewResult List() => View(repository.Messages);
        
        public ViewResult Thread(int tid)
        {
            var threadlist = repository.Messages.Where(x => x.tId == tid); //Get all messages with same thread number
            threadlist = threadlist.OrderBy(x => x.pId); // Position them correctly
            ViewData["threadlist"] = threadlist;
            var firstobj = threadlist.FirstOrDefault();
            foreach (var p in repository.Messages)
            {
                //HTML Tag Filters
                var filteredcontent = Regex.Replace(p.content, "<.*?>", string.Empty);
                var filteredtitle = Regex.Replace(firstobj.title, "<.*?>", string.Empty);

                if (p.tId == tid)
                    {
                    ViewData["Message"] = filteredcontent;
                    ViewData["Author"] = p.author;
                    ViewData["Title"] = filteredtitle;
                    ViewData["tId"] = p.tId;                 
                    ViewData["mId"] = p.mId;
                    ViewData["signin"] = _signinmanager.IsSignedIn(User);
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
            var sanitizer = new HtmlSanitizer();
            var sanitizedcontent = sanitizer.Sanitize(message.content);
            var sanitizedtitle = sanitizer.Sanitize(message.title);
            message.title = sanitizedtitle;
            message.content = sanitizedcontent;
            if (ModelState.IsValid)
            {
                message.author = _usermanager.GetUserName(User);
                message.pId = 0; //Start of thread thus position 0
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
            //Sanitize Title and Content
            var sanitizer = new HtmlSanitizer();
            var sanitizedtitle = sanitizer.Sanitize(message.title);
            var sanitizedcontent = sanitizer.Sanitize(message.content);
            //Change to Sanitized
            message.title = sanitizedtitle;
            message.content = sanitizedcontent;
            //Change Author to currrent-user here
            message.author = _usermanager.GetUserName(User);
            //Change tId to be max+1 here where mId is the same as the curent thread(Yup definitely need to pass current mId)
            IEnumerable<Message> newtIdList = repository.Messages.Where(x => x.tId == message.tId); //Compares and returns messages with tId same as the one passed to me from thread
            var finalIdObj = newtIdList.Max(x => x.pId); //Object with the highest tId in that mId
            finalIdObj = finalIdObj + 1;
            message.pId = finalIdObj;
            //Finally save the message to the database
            repository.SaveMessage(message);
            return RedirectToAction("Thread", new { tid = message.tId }); //Change to bring back to current thread (Maybe pass current mId to Reply?
        }
        
    }
}
