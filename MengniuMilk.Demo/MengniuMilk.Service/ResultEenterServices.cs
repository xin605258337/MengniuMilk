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
                string sql = @"";
                var result = conn.Query<ResultEenter>(sql, null);
                return result.ToList<ResultEenter>();
            }
        }
    }
}
