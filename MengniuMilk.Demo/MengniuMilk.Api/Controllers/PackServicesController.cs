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
    public class PackServicesController : ApiController
    {
        [Dependency]
        public IPackServices  packServices { get; set; }

        /// <summary>
        /// 修改质检任务状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangeState1")]
        public int ChangeState(int id)
        {
            return packServices.ChangeState(id);
        }

        /// <summary>
        /// 获取包装检验信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPack")]
        public List<Pack> GetPack()
        {
            return packServices.GetPack();
        }

        /// <summary>
        /// 删除包装检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("deletePack")]
        public int deletePack(int id)
        {

            return packServices.deletePack(id);
        }

        /// <summary>
        /// 修改包装检验信息
        /// </summary>
        /// <param name="Pack"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updatePack")]
        public int updatePack(Pack pack)
        {

            return packServices.updatePack(pack);
        }

        }
}
