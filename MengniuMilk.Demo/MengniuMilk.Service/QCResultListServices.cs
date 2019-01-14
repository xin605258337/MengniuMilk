using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Service
{
    using MengniuMilk.Entity;
    using MengniuMilk.IService;
    using Dapper;
    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess;
    using System.Configuration;
    public  class QCResultListServices:IQCResultListServices
    {
        /// <summary>
        /// 根据质检计划查出所对应所有指标项主键ID
        /// </summary>
        /// <param name="qcPlanId">质检计划ID</param>
        /// <returns></returns>
        public int GetTargetsAndAddQCResult(int qcPlanId,int sampleId)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select ta.Target_ID from QCPlan q inner join TargetType t on q.targettype_id=t.TargetType_ID inner join Target ta on t.TargetType_ID=ta.targettypepid
                  where q.ID=:ID";
                var targetList = conn.Query<Target>(sql, new { ID = qcPlanId }).ToList();
                for (int i=0;i<targetList.Count;i++)
                {
                    QCResultList qcResult = new QCResultList();
                    qcResult.SampleID = sampleId;
                    qcResult.TargetID =Convert.ToInt32(targetList[i].Target_ID);
                    AddQCResult(qcResult);
                }
                return 1;
            }
        }
        /// <summary>
        /// 添加质检结果明细表
        /// </summary>
        /// <returns></returns>
        public int AddQCResult(QCResultList qcResult)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into QCRESULTLIST(sampleID,targetID) values(:sampleID,:targetID)";
                var result = conn.Execute(sql, qcResult);
                return result;
            }
        }

        /// <summary>
        /// 根据采样品ID获取检验明细表
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        public List<QCResultList> GetQCResultLists(int sampleId)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select ta.TargetType_Name,t.Target_Name,t.StandardValues,t.StandardValuesMax,t.StandardValuesMin,q.Result,q.State from QCRESULTLIST q inner join Target t on q.targetid=t.Target_ID inner join TargetType ta on t.TargetTypePid=ta.TargetType_ID inner join Sample sm on q.sampleid=sm.id where q.sampleid=:sampleid";
                var result = conn.Query<QCResultList>(sql, new { sampleid = sampleId }).ToList();
                return result;
            }
        }
    }
}
