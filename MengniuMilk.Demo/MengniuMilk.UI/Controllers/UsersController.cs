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
        public ActionResult Index(int userId)
        {
            System.Web.HttpContext.Current.Session["UsersID"] = userId;
            return View();
        }
        

        public ActionResult Login()
        {
            if (System.Web.HttpContext.Current.Session["UsersID"] != null)
            {
                ViewBag.UsersID = System.Web.HttpContext.Current.Session["UsersID"].ToString();

            }
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