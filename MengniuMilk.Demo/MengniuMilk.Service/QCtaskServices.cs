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
    public class QCtaskServices:IQCtaskServices
    {
        /// <summary>
        /// 添加质检任务信息
        /// </summary>
        /// <param name="qCtask"></param>
        /// <returns></returns>
        public int AddQCtask(QCtask qCtask)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into QCtask(QCPLAN_ID,InformTime,State,SAMPIEID) values(:QCPlan_ID,sysdate,:State,:SAMPIEID)";
                int result = conn.Execute(sql, qCtask);
                return result; 
            }
        }
        /// <summary>
        /// 获取质检名称
        /// </summary>
        /// <returns></returns>
        public List<QCPlan> GetQCPlansName()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from QCPlan ";
               var result = conn.Query<QCPlan>(sql, null);
                return result.ToList<QCPlan>();
            }
        }

        /// <summary>
        /// 获取质检任务信息
        /// </summary>
        /// <returns></returns>
        public List<QCtask> GetQCtasks()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select q.*,p.QCPlanName from QCtask q left join QCPlan p on q.QCPlan_ID =p.ID left join  Sample s on q.SAMPIEID=s.ID ";
                var result = conn.Query<QCtask>(sql, null);
                return result.ToList<QCtask>();
            }
        }
        /// <summary>
        /// 删除质检任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelQCtask(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from QCtask where QCtask_ID=:QCtask_ID";
                var result = conn.Execute(sql, new { QCtask_ID = id });
                return result;
            }

        }
        /// <summary>
        /// 修改质检任务信息
        /// </summary>
        /// <param name="qCtask"></param>
        /// <returns></returns>
        public int UptQCtask(QCtask qCtask)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update QCtask set QCPlan_ID=:QCPlan_ID,State=:State,SAMPIEID=:SAMPIEID where QCtask_ID=:QCtask_ID";
                var result = conn.Execute(sql, qCtask);
                return result;
            }

        }
        /// <summary>
        /// 根据质检任务ID获取质检任务中样品ID把质检任务样品ID添加到质检结果录入表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetQCtaskbyName(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert  into RESULTEENTER(Sample_ID) select SAMPIEID from QCtask where  QCtask_ID=:QCtask_ID ";
                var result = conn.Execute(sql,new { QCtask_ID = id});
                return result;
            }
        }
        /// <summary>
        /// 把质检任务ID添加到生乳质量检验表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetQCtaskbyID(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert  into RawMilk(QCTASKID) select QCTASK_ID from QCtask where  QCtask_ID=:QCtask_ID";
                var result = conn.Execute(sql, new { QCtask_ID = id });
                return result;
            }
        }

        
    }
}
