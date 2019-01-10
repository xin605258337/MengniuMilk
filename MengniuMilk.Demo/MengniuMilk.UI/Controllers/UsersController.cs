using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    using MengniuMilk.Entity;
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult Login()
        {       
          
            return View();
        }

        public ActionResult AddUsers() 
        {
            return View();
        }

        public ActionResult ShowUser()
        {
            return View();
        }

        public ActionResult UpdateUsers()
        {
            return View();
        }
    }
}