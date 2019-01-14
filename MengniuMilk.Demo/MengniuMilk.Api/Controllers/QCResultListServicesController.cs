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
        [Route("GetTargets")]
        [HttpGet]
        public int GetTargetsAndAddQCResult(int qcPlanId, int sampleId)
        {
            return QCResultListServices.GetTargetsAndAddQCResult(qcPlanId,sampleId);
        }
    }
}
