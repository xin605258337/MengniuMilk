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

    public class TargetTypeServices:ITargetTypeServices
    {
        /// <summary>
        /// 添加指标项分类
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public int AddTargetType(TargetType targetType)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"insert into TargetType(TargetType_Name) values(:TargetType_Name)";
                var result = conn.Execute(sql, targetType);
                return result;
            }
        }

        /// <summary>
        /// 获取指标项分类
        /// </summary>
        /// <returns></returns>
        public List<TargetType> GetTargetTypes()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from TargetType";
                var result = conn.Query<TargetType>(sql, null);
                return result.ToList<TargetType>();
            }
        }


        /// <summary>
        /// 删除指标项分类
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public int DeleteTargetType(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"delete from TargetType where TargetType_ID=:TargetType_ID";
                var result = conn.Execute(sql, new { TargetType_ID = id });
                return result;
            }
        }

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<TargetType> GetTargetTypesByID(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from TargetType where TargetType_ID=:TargetType_ID";
                var result = conn.Query<TargetType>(sql, new { TargetType_ID = id });
                return result.ToList<TargetType>();
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public int UpdateTargetType(TargetType targetType)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"update TargetType set TargetType_Name=:TargetType_Name where TargetType_ID=:TargetType_ID";
                var result = conn.Execute(sql, targetType);
                return result;
            }
        }

    }
}
