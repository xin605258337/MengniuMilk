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
        int GetTargetsAndAddQCResult(int qcPlanId, int sampleId);

        /// <summary>
        /// 添加质检结果明细表
        /// </summary>
        /// <returns></returns>
        int AddQCResult(QCResultList qcResult);

        /// <summary>
        /// 根据采样品ID获取检验明细表
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        List<QCResultList> GetQCResultLists(int sampleId, int qcTaskID);

        /// <summary>
        /// 修改生乳检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        int Update(QCResultList qCResultList);

        /// <summary>
        /// 根据样品ID获取样品状态
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        int GetQCResultState(int sampleId);

        /// <summary>
        /// 根据检验结果将不合格的质检任务ID添加到不合格记录表中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int AddUnqualified(int qcTaskID);
    }
}
