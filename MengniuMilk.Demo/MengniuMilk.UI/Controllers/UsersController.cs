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
            if (Session["UsersID"] !=null)
            {
                ViewBag.UsersID = Session["UsersID"].ToString();
           
            }
            return View();
        }

        public ActionResult UpdateUsers()
        {
            return View();
        }
        /// <summary>
        /// session存用户名密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult GetUser(int UserId ,string UserName)
        {
            System.Web.HttpContext.Current.Session["UsersID"] = UserId;
          
            return Content("<script>location.href='/ResultEenter/Index'</script>");

        }


    }
}