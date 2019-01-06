using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult SampleIndex()
        {
            return View();
        }

        public ActionResult SampleAdd()
        {
            return View();
        }
    }
}