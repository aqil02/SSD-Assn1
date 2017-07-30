﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SSD_Migrated.Models.MessageModels;
using SSD_Migrated.Services;
using System.Linq;
using System.Text.RegularExpressions;
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
                //var mid = p.mId.ToString();
                var filteredcontent = Regex.Replace(p.content, "<.*?>", string.Empty);
                var filteredtitle = Regex.Replace(p.title, "<.*?>", string.Empty);
                if (p.mId == mid)
                    {
                    ViewData["Message"] = filteredcontent;
                    ViewData["Author"] = p.author;
                    ViewData["Title"] = filteredtitle;
                    
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
                repository.SaveMessage(message);
                return RedirectToAction("List");
            }
            else
            {
                //Damn there's problems with the data
                return View("List");
            }
        }
        public IActionResult Reply(Message message)
        {

        }
    }
}
