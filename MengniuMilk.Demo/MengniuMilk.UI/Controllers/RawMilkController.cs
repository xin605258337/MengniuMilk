﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class RawMilkController : Controller
    {
        // GET: RawMilk
        public ActionResult RawMilkIndex()
        {
            if (System.Web.HttpContext.Current.Session["UsersID"] != null)
            {
                ViewBag.UsersID = System.Web.HttpContext.Current.Session["UsersID"].ToString();

            }
            return View();
        }

        public ActionResult GetUser(int UserId)
        {
            System.Web.HttpContext.Current.Session["UsersID"] = UserId;

            return Content("<script>location.href='/RawMilk/RawMilkIndex'</script>");

        }
    }
}