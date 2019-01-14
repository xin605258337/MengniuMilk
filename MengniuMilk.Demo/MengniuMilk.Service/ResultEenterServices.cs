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
                string sql = @"select  r.Result,r.Users_ID,c.qcplanname,s.name from ResultEenter r inner join QCtask q on q.qctask_id=r.qctask_id inner join QCPlan c on c.id=q.qcplan_id inner join Sample s on s.id=q.sampieid";
                var result = conn.Query<ResultEenter>(sql, null);
                return result.ToList<ResultEenter>();
            }
        }

        public int AddResultEenters(ResultEenter resultEenter)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into ResultEenter(ID,QCtask_ID,Users_ID,Result) values(:ID,:QCtask_ID,:Users_ID,:Result)";
                int result = conn.Execute(sql, resultEenter);
                return result;
            }

        }
    }
}
