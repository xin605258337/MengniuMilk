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

    public class UnqualifiedServicesController : ApiController
    {
        
        [Dependency]
        public IUnqualifiedServices UnqualifiedServices { get; set; }

        /// <summary>
        /// 获取不合格记录表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUnqualifieds")]
        public List<Unqualified> GetUnqualifieds()
        {
            var result = UnqualifiedServices.GetUnqualifieds();
            return result;
        }

        /// <summary>
        /// 删除不合格记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteUnqualified")]
        [HttpPost]
        public int DeleteUnqualified(int id)
        {
            var result = UnqualifiedServices.DeleteUnqualified(id);
            return result;
        }

        /// <summary>
        /// 修改不合格记录表状态和检验结果值
        /// </summary>
        /// <param name="unqualified"></param>
        /// <returns></returns>
        [Route("UpdateUnqualified")]
        [HttpPost]
        public int UpdateUnqualified(Unqualified unqualified)
        {
            var result = UnqualifiedServices.UpdateUnqualified(unqualified);
            return result;
        }
    }
}
