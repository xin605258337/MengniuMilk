using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class QCPlanController : Controller
    {
        // GET: QCPlan
        public ActionResult ShowIndex()
        {
            return View();
        }
        /// <summary>
        /// 添加质检计划
        /// </summary>
        /// <returns></returns>
        public ActionResult AddQCPlan()
        {
            return View();
        }
    }
}