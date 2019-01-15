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
    using System.Configuration;
    public class ResultEenterServices : IResultEenterServices
    {
        /// <summary>
        ///质检结果录入日志
        /// </summary>
        /// <returns></returns>
        public List<ResultEenter> GetResultEenters()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select r.id, r.Result,u.usersname,c.qcplanname,s.name from ResultEenter r 
                               inner join QCtask q on q.qctask_id=r.qctask_id
                               inner join QCPlan c on c.id=q.qcplan_id
                               inner join Sample s on s.id=q.sampieid
                               inner join Users u on r.users_id=u.usersid";
                var result = conn.Query<ResultEenter>(sql, null);
                return result.ToList<ResultEenter>();
            }
        }


        /// <summary>
        /// 添加至结果录入表
        /// </summary>
        /// <param name="resultEenter"></param>
        /// <returns></returns>
        public int AddResultEenters(ResultEenter resultEenter)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into ResultEenter(QCtask_ID,Users_ID,Result) values(:QCtask_ID,:Users_ID,:Result)";
                int result = conn.Execute(sql, resultEenter);
                return result;
            }

        }
    }
}
