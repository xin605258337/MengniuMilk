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

        /// <summary>
        /// 根据质检任务ID获取质检任务中样品ID把质检任务样品ID添加到质检结果录入表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCtaskbyName")]
        public int GetQCtaskbyName(int id)
        {
            return QCtaskServices.GetQCtaskbyName(id);
        }
        /// <summary>
        /// 把质检任务ID添加到生乳质量检验表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCtaskbyID")]
        public int GetQCtaskbyID(int id)
        {
            return QCtaskServices.GetQCtaskbyID(id);
        }

        /// <summary>
        /// 把质检任务ID添加到包装质量检验表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AddPack")]
        public int AddPack(int id)
        {
            return QCtaskServices.AddPack(id);
        }

        /// <summary>
        ///根据质检任务获取质检工序
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProcessByID")]
        public int GetProcessByID(int id)
        {
            return QCtaskServices.GetProcessByID(id);
        }
    }
}
