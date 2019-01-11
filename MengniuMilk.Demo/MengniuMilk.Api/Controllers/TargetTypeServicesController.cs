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

    public class TargetTypeServicesController : ApiController
    {
        [Dependency]
        public ITargetTypeServices TargetTypeServices { get; set; }

        /// <summary>
        /// 添加指标项分类
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddTargetType")]
        public int AddTargetType(TargetType targetType)
        {
            var result = TargetTypeServices.AddTargetType(targetType);
            return result;
        }

        /// <summary>
        /// 获取指标项分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTargetTypes")]
        public List<TargetType> GetTargetTypes()
        {
            var result = TargetTypeServices.GetTargetTypes();
            return result;
        }

        /// <summary>
        /// 删除指标项分类
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteTargetType")]
        public int DeleteTargetType(int id)
        {
            var result = TargetTypeServices.DeleteTargetType(id);
            return result;
        }

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTargetTypesByID")]
        public List<TargetType> GetTargetTypesByID(int id)
        {
            var result = TargetTypeServices.GetTargetTypesByID(id);
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateTargetType")]
        public int UpdateTargetType(TargetType targetType)
        {
            var result = TargetTypeServices.UpdateTargetType(targetType);
            return result;
        }
    }
}
