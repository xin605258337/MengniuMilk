using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class QCtaskController : Controller
    {
        // GET: QCtask
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddQCtask()
        {
            return View();
        }
    }
}