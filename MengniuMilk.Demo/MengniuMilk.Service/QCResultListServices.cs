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
                string sql1 = @"select QCtask_ID from QCtask where QCPLAN_ID=:QCPLAN_ID and SAMPIEID=:SAMPIEID";
                int qctaskID = conn.Query<QCtask>(sql1, new { QCPLAN_ID = qcPlanId, SAMPIEID = sampleId }).FirstOrDefault().QCtask_ID;
                string sql = @"select ta.Target_ID from QCPlan q inner join TargetType t on q.targettype_id=t.TargetType_ID inner join Target ta on t.TargetType_ID=ta.targettypepid
                  where q.ID=:ID";
                var targetList = conn.Query<Target>(sql, new { ID = qcPlanId }).ToList();
                for (int i=0;i<targetList.Count;i++)
                {
                    QCResultList qcResult = new QCResultList();
                    qcResult.QCTaskID = qctaskID;
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
                string sql = @"insert into QCRESULTLIST(sampleID,targetID,qctaskID) values(:sampleID,:targetID,:qctaskID)";
                var result = conn.Execute(sql, qcResult);
                return result;
            }
        }

        /// <summary>
        /// 根据采样品ID获取检验明细表
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        public List<QCResultList> GetQCResultLists(int sampleId,int qcTaskID)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select q.ID,ta.TargetType_Name,t.Target_Name,t.StandardValues,t.StandardValuesMax,t.StandardValuesMin,q.Result,q.State from QCRESULTLIST q inner join Target t on q.targetid=t.Target_ID inner join TargetType ta on t.TargetTypePid=ta.TargetType_ID inner join Sample sm on q.sampleid=sm.id where q.sampleid=:sampleid and QCTaskID=:QCTaskID";
                var result = conn.Query<QCResultList>(sql, new { sampleid = sampleId, QCTaskID= qcTaskID }).ToList();
                return result;
            }
        }

        /// <summary>
        /// 修改生乳检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        public int Update(QCResultList qCResultList)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update QCResultList set Result=:Result,State=:State where ID=:ID";
                var result = conn.Execute(sql, qCResultList);
                return result;
            }
        }

        /// <summary>
        /// 根据样品ID获取样品状态
        /// </summary>
        /// <param name="sampleId"></param>
        /// <returns></returns>
        public int GetQCResultState(int sampleId)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select state from QCRESULTLIST where SampleID = :SampleID";
                var resultList = conn.Query<QCResultList>(sql, new { SampleID =sampleId}).ToList();
                int  result= 1;
                for(int i=0;i< resultList.Count;i++)
                {
                    if(resultList[i].State==2)
                    {
                        result = 0;
                        break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 根据检验结果将不合格的质检任务ID添加到不合格记录表中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddUnqualified(int qcTaskID)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into Unqualified(QCtask_ID) values(:QCtask_ID)";
                var result = conn.Execute(sql, new { QCtask_ID = qcTaskID });
                return result;
            }
        }
    }
}
