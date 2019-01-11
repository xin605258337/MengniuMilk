using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class TargetTypeController : Controller
    {
        // GET: TargetType
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加指标项分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

       
    }
}