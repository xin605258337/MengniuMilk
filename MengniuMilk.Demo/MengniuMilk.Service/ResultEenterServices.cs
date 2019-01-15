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
        ///质检结果录入表显示
        /// </summary>
        /// <returns></returns>
        public List<ResultEenter> GetResultEenters()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select u.UsersName,r.Result,qt.QCtask_ID,qp.QCPlanName,qp.targettype_id,ta.TargetType_Name from ResulteEnter r inner join Users u on r.Users_ID=u.UsersID inner join QCtask qt on qt.QCtask_ID=r.QCtask_ID inner join QCPlan qp on qp.ID=qt.QCPLAN_ID inner join TargetType ta on ta.TargetType_ID=qp.TargetType_ID";
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
