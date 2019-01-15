using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class ResultEenterController : Controller
    {
        // GET: ResultEenter
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["UsersID"] != null)
            {
                ViewBag.UsersID = System.Web.HttpContext.Current.Session["UsersID"].ToString();

            }
            return View();
        }

        /// <summary>
        /// session存用户名密码
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public ActionResult GetUser(int UserId)
        {
            System.Web.HttpContext.Current.Session["UsersID"] = UserId;

            return Content("<script>location.href='/ResultEenter/Index'</script>");

        }
    }
}