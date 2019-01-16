using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class UnqualifiedController : Controller
    {
        // GET: Unqualified
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 不合格处理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Disposeindex()
        {
            return View();
        }
        
      
    }
}