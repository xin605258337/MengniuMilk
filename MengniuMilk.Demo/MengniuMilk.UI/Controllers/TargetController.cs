using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class TargetController : Controller
    {
        // GET: Target
        public ActionResult AddTarget()
        {
            return View();
        }

        public ActionResult GetTarget()
        {
            return View();
        }
    }
}