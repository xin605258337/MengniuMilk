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
                string sql = @"";
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
                string sql = @"delete from Unqualified where ID=:ID";
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
                string sql = @"update Unqualified set QCtask_ID=:QCtask_ID,State=:State,Result=:Result where ID=:ID";
                var result = conn.Execute(sql, unqualified);
                return result;
            }
        }
    }
}
