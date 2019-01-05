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
    public class DataGatherServices : IDataGatherServices
    {
        /// <summary>
        /// 人工数据采集表添加
        /// </summary>
        /// <param name="dataGather"></param>
        /// <returns></returns>
        public int AddDataGather(DataGather dataGather)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into DATAGATHER(FACILITY_ID,PROCESS_ID,SURVEYOR,DATETIME,PARAMETERVALUES,REMARK) values(:FACILITY_ID,:PROCESS_ID,:SURVEYOR,:DATETIME,:PARAMETERVALUES,:REMARK)";
                int result = conn.Execute(sql, dataGather);
                return result;
            }
        }
        /// <summary>
        /// 人工数据采集表删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelDateGathers(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from DATAGATHER where ID=:ID";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
        }
        /// <summary>
        /// 人工数据采集表添加查看
        /// </summary>
        /// <returns></returns>
        public List<DataGather> GetDataGathers()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from DATAGATHER";
                var result = conn.Query<DataGather>(sql, null);
                return result.ToList<DataGather>();
            }
        }
        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<DataGather> GetDataGathersById(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from DATAGATHER where ID=:ID";
                var result = conn.Query<DataGather>(sql, new { ID = id });
                return result.ToList<DataGather>();
            }
        }

        /// <summary>
        /// 人工数据采集表添加修改
        /// </summary>
        /// <param name="dataGather"></param>
        /// <returns></returns>
        public int UptDateGathers(DataGather dataGather)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update DATAGATHER set FACILITY_ID=:FACILITY_ID,PROCESS_ID=:PROCESS_ID,SURVEYOR=:SURVEYOR,DATETIME=:DATETIME,PARAMETERVALUES=:PARAMETERVALUES,REMARK=:REMARK where ID=:ID";
                var result = conn.Execute(sql, dataGather);
                return result;
            }
        }
    }
}
