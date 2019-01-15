using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Service
{
    using Dapper;
    using MengniuMilk.Entity;
    using MengniuMilk.IService;
    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess;

    public class UnqualifiedServices:IUnqualifiedServices
    {
        /// <summary>
        /// 获取不合格记录表信息
        /// </summary>
        /// <returns></returns>
        public List<Unqualified> GetUnqualifieds()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select u.UnqualifiedID,u.state,u.result,q.qctask_id,p.id,q.sampieid,p.qcplanname,r.process_id,r.process_name,s.id,s.name,p.type_id,y.type_name from Unqualified u inner join QCtask q on u.qctask_id=q.qctask_id 
                            inner join QCPlan p on q.qcplan_id=p.id
                            inner join Sample s on q.sampieid=s.id
                            inner join Process r on r.process_id=p.process_id
                            inner join QCPlanType y on p.type_id=y.type_id";
                var result = conn.Query<Unqualified>(sql, null);
                return result.ToList<Unqualified>();
            }
        }

        /// <summary>
        /// 删除不合格记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUnqualified(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"delete from Unqualified where UnqualifiedID=:ID";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
        }

        /// <summary>
        /// 修改不合格记录表状态和检验结果值
        /// </summary>
        /// <param name="unqualified"></param>
        /// <returns></returns>
        public int UpdateUnqualified(Unqualified unqualified)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"update Unqualified set State=:State,Result=:Result where UnqualifiedID=:ID";
                var result = conn.Execute(sql, unqualified);
                return result;
            }
        }
    }
}
