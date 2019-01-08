using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MengniuMilk.Api.Controllers
{
    using MengniuMilk.Entity;
    using MengniuMilk.IService;
    using MengniuMilk.Service;
    using Unity.Attributes;
    public class QCtaskServicesController : ApiController
    {
        [Dependency]

        public IQCtaskServices QCtaskServices { get; set;  }

        /// <summary>
        /// 添加质检任务信息
        /// </summary>
        /// <param name="qCtask"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddQCtask")]
        public int AddQCtask(QCtask qCtask)
        {
            return QCtaskServices.AddQCtask(qCtask);
        }
        /// <summary>
        /// 获取质检任务信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCtasks")]
        public List<QCtask> GetQCtasks()
        {
            return QCtaskServices.GetQCtasks();
        }

        /// <summary>
        /// 获取质检名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCPlansName")]
        public List<QCPlan> GetQCPlansName()
        {

            return QCtaskServices.GetQCPlansName();
        }
        /// <summary>
        /// 删除质检任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DelQCtask")]
        public int DelQCtask(int id)
        {
            return QCtaskServices.DelQCtask(id);

        }
        /// <summary>
        /// 修改质检任务信息
        /// </summary>
        /// <param name="qCtask"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UptQCtask")]
        public int UptQCtask(QCtask qCtask)
        {
            return QCtaskServices.UptQCtask(qCtask);

        }
    }
}
