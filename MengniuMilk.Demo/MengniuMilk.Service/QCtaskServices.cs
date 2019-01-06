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
                string sql = @"insert into QCtask(QCPlan_ID,QCPlanType,StartDate,EndDate) values(:QCPlan_ID,:QCPlanType,:StartDate,:EndDate)";
                int result = conn.Execute(sql, qCtask);
                return result;
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
                string sql = @"select q.*,p.Name,t.Type_Name from QCtask q left join QCPlan p on q.QCPlan_ID =p.ID left join QCPlanType t on q.QCPlanType =p.Type_ID";
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
                string sql = @"update QCtask set QCPlan_ID=:QCPlan_ID,QCPlanType=:QCPlanType,StartDate=:StartDate,EndDate=:EndDate where QCtask_ID=:QCtask_ID";
                var result = conn.Execute(sql, qCtask);
                return result;
            }

        }
    }
}
