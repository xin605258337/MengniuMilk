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
        [HttpGet]
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

        /// <summary>
        /// 删除不合格样品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteSample")]
        public int DeleteSample(int id)
        {
            return UnqualifiedServices.DeleteSample(id);
        }

        /// <summary>
        /// 获得不合格样品的不合格指标项数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDispost")]
        public List<Unqualified> GetDispost(int sampleId)
        {
            return UnqualifiedServices.GetDispost(sampleId);
        }

        /// <summary>
        /// 修改处理方式
        /// </summary>
        /// <param name="unqualified"></param>
        /// <returns></returns>
        [Route("UpdateConduct")]
        [HttpPost]
        public int UpdateConduct(Unqualified unqualified)
        {
            return UnqualifiedServices.UpdateConduct(unqualified);
        }

        /// <summary>
        /// 根据处理方式处理不合格产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Enable")]
        public int Enable(int id)
        {
            return UnqualifiedServices.Enable(id);
        }
    }
}
