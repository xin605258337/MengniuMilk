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
    public class QCPlanServicesController : ApiController
    {
        [Dependency]
        public IQCPlanServices qcPlanServices { get; set; }

        /// <summary>
        /// 新增质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddQCPlan")]
        public int AddQCPlan(QCPlan qcPlan)
        {
            var result = qcPlanServices.AddQCPlan(qcPlan);
            return result;
        }

        /// <summary>
        /// 删除质检
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteQCPlan")]
        public int DeleteQCPlan(int id)
        {
            var result = qcPlanServices.DeleteQCPlan(id);
            return result;
        }

        /// <summary>
        /// 获取质检设备
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFacilities")]
        public List<Facility> GetFacilities()
        {
            var result = qcPlanServices.GetFacilities();
            return result;
        }

        /// <summary>
        /// 获取检验工序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProcess")]
        public List<Process> GetProcess()
        {
            var result = qcPlanServices.GetProcess();
            return result;
        }

        /// <summary>
        /// 获取质检对象
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCPlanObjTypes")]
        public List<QCPlanObjType> GetQCPlanObjTypes()
        {
            var result = qcPlanServices.GetQCPlanObjTypes();
            return result;
        }

        /// <summary>
        /// 获取质检计划信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCPlans")]
        public List<QCPlan> GetQCPlans()
        {
            var result = qcPlanServices.GetQCPlans();
            return result;

        }

        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCPlansByID")]
        public List<QCPlan> GetQCPlansByID(int id)
        {
            var result = qcPlanServices.GetQCPlansByID(id);
            return result;

        }

        /// <summary>
        /// 获取质检类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQCPlanTypes")]
        public List<QCPlanType> GetQCPlanTypes()
        {
            var result = qcPlanServices.GetQCPlanTypes();
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
            var result = qcPlanServices.GetTargetTypes();
            return result;
        }

        /// <summary>
        /// 修改质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateQCPlan")]
        public int UpdateQCPlan(QCPlan qcPlan)
        {
            var result = qcPlanServices.UpdateQCPlan(qcPlan);
            return result;
        }
    }
}
