using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MengniuMilk.UI.Controllers
{
    public class QCResultListController : Controller
    {
        // GET: QCResultList
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加质检结果明细
        /// </summary>
        /// <returns></returns>
        public ActionResult AddQCResult()
        {
            return View();
        }
    }
}