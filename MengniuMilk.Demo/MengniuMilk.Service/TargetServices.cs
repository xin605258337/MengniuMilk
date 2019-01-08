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
    public class TargetServices:ITargetServices
    {
        /// <summary>
        /// 添加指标项名称
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int AddTarget(Target target)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into Target(Target_Name,StandardValues,StandardValuesMax,StandardValuesMin,TargetTypePid) values(:Target_Name,:StandardValues,:StandardValuesMax,:StandardValuesMin,:TargetTypePid)";
                int result = conn.Execute(sql, target);
                return result;
            }
        }

        /// <summary>
        /// 获取指标项名称
        /// </summary>
        /// <returns></returns>
        public List<Target> GetTargets()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select t.*,g.TargetType_Name from Target t inner join TargetType g on t.TargetTypePid=g.TargetType_ID";
                var result = conn.Query<Target>(sql, null);
                return result.ToList<Target>();
            }
        }

        /// <summary>
        /// 删除指标项信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelTarget(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from Target where Target_ID=:Target_ID";
                var result = conn.Execute(sql, new { Target_ID = id });
                return result;
            }
        }
        /// <summary>
        /// 修
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int UptTarget(Target target)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update Target set Target_Name=:Target_Name,StandardValues=:StandardValues,StandardValuesMax=:StandardValuesMax,StandardValuesMin=:StandardValuesMin,TargetTypePid=:TargetTypePid where Target_ID=:Target_ID";
                var result = conn.Execute(sql, target);
                return result;
            }
        }
    }
}
