using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface IQCResultListServices
    {
        /// <summary>
        /// 根据质检计划查出所对应所有指标项主键ID
        /// </summary>
        /// <param name="qcPlanId">质检计划ID</param>
        /// <returns></returns>
        List<Target> GetTargets(int qcPlanId);
        /// <summary>
        /// 添加质检结果明细表
        /// </summary>
        /// <returns></returns>
        int AddQCResult(QCResultList qcResult);
    }
}
