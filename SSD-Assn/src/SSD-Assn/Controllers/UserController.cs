using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSD_Assn.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SSD_Assn.Controllers
{
    public class UserController : Controller
    {
        IList<User> studentList = new List<User>() {
                    new User(){ StudentId=1, StudentName="John", Age = 18 },
                    new User(){ StudentId=2, StudentName="Steve", Age = 21 },
                    new User(){ StudentId=3, StudentName="Bill", Age = 25 },
                    new User(){ StudentId=4, StudentName="Ram", Age = 20 },
                    new User(){ StudentId=5, StudentName="Ron", Age = 31 },
                    new User(){ StudentId=6, StudentName="Chris", Age = 17 },
                    new User(){ StudentId=7, StudentName="Rob", Age = 19 }
                };
        // GET: Student
        public ActionResult Index()
        {
            return View(studentList);
        }

        public ActionResult Edit(int StudentId)
        {
            //Get the student from studentList sample collection for demo purpose.
            //You can get the student from the database in the real application
            var std = studentList.Where(s => s.StudentId == StudentId).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(User std)
        {
            //write code to update student 

            return RedirectToAction("Index");
        }
    }
}
