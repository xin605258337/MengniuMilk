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
    public class QCResultListServicesController : ApiController
    {
        [Dependency]
        public IQCResultListServices  QCResultListServices { get; set; }

        /// <summary>
        /// 添加质检结果明细表
        /// </summary>
        /// <returns></returns>
        [Route("AddQCResult")]
        [HttpPost]
        public int AddQCResult(QCResultList qcResult)
        {
            return QCResultListServices.AddQCResult(qcResult);
        }


        /// <summary>
        /// 根据质检计划查出所对应所有指标项主键ID
        /// </summary>
        /// <param name="qcPlanId">质检计划ID</param>
        /// <returns></returns>
        [Route("GetTargetsAndAddQCResult")]
        [HttpGet]
        public int GetTargetsAndAddQCResult(int qcPlanId, int sampleId)
        {
            return QCResultListServices.GetTargetsAndAddQCResult(qcPlanId,sampleId);
        }

        /// <summary>
        /// 根据采样品ID获取检验明细表
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        [Route("GetQCResultLists")]
        [HttpGet]
        public List<QCResultList> GetQCResultLists(int sampleId, int qcTaskID)
        {
            return QCResultListServices.GetQCResultLists(sampleId, qcTaskID);
        }

        /// <summary>
        /// 修改生乳检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public int Update(QCResultList qCResultList)
        {
            return QCResultListServices.Update(qCResultList);
        }

        /// <summary>
        /// 根据样品ID获取样品状态
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        [Route("GetQCResultState")]
        [HttpGet]
        public int GetQCResultState(int sampleId)
        {
            return QCResultListServices.GetQCResultState(sampleId);
        }
    }
}
