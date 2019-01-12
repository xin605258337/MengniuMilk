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
    public class SampleServices : ISampleServices
    {
        /// <summary>
        /// 采样表添加
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public int AddSample(Sample sample)
        {
            using (OracleConnection conn=DapperHelper.GetConnString())
            {
                var uuidN = Guid.NewGuid().ToString("N");
                sample.Code = uuidN;
                conn.Open();
                string sql = @"insert into Sample(Name,Code) values(:Name,:Code)";
                int result = conn.Execute(sql, sample);
                return result;

            }
        }

        /// <summary>
        /// 采样表删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelSample(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from Sample where ID=:ID";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
        }

        /// <summary>
        /// 获取采样表数据
        /// </summary>
        /// <returns></returns>
        public List<Sample> GetSample()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Sample";
                var result = conn.Query<Sample>(sql, null);
                return result.ToList<Sample>();
            }
        }

        /// <summary>
        /// 获取采样表单个ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Sample> GetSampleById(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Sample where ID=:ID";
                var result = conn.Query<Sample>(sql, new { ID = id });
                return result.ToList<Sample>();
            }
        }

        /// <summary>
        /// 采样表修改
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public int UptSample(Sample sample)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update Sample set Name=:Name,Code=:Code where ID=:ID";
                var result = conn.Execute(sql, sample);
                return result;
            }
        }
    }
}
