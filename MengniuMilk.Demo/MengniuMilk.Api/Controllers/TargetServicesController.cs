using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MengniuMilk.Api.Controllers
{
    using MengniuMilk.Entity;
    using MengniuMilk.Service;
    using MengniuMilk.IService;
    using Unity.Attributes;   
    public class TargetServicesController : ApiController
    {
        [Dependency]
        public ITargetServices targetServices { get; set; }

        /// <summary>
        /// 添加指标项名称
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddTarget")]
        public int AddTarget(Target target)
        {
            return targetServices.AddTarget(target);
        }

        /// <summary>
        /// 获取指标项名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTargets")]
        public List<Target> GetTargets()
        {
            return targetServices.GetTargets();
        }

        /// <summary>
        /// 删除指标项信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DelTarget")]
        public int DelTarget(int id)
        {
            return targetServices.DelTarget(id);
        }
        /// <summary>
        /// 修改指标项信息
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UptTarget")]
        public int UptTarget(Target target)
        {
            return targetServices.UptTarget(target);
        }
    }
}
