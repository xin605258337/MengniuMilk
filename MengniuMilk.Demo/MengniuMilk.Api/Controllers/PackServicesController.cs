﻿using System;
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
        public IPackServices  PackServices { get; set; }

        /// <summary>
        /// 修改质检任务状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangeStatePack")]
        public int ChangeStatePack(int id)
        {
            return PackServices.ChangeStatePack(id);
        }

        /// <summary>
        /// 获取包装检验信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPack")]
        public List<Pack> GetPack()
        {
            return PackServices.GetPack();
        }

        /// <summary>
        /// 删除包装检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeletePack")]
        public int DeletePack(int id)
        {

            return PackServices.DeletePack(id);
        }

        /// <summary>
        /// 修改包装检验信息
        /// </summary>
        /// <param name="Pack"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePack")]
        public int UpdatePack(Pack pack)
        {

            return PackServices.UpdatePack(pack);
        }

        /// <summary>
        /// 根据检验结果将质检任务ID添加到质检结果录入表中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddResultByPack")]
        public int AddResultByPack(int id)
        {
            return PackServices.AddResultByPack(id);
        }

    }
}
