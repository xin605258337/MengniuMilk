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
    public class RawMilkServices : IRawMilkServices
    {
        /// <summary>
        /// 添加生乳质量检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        public int AddRawMilk(RawMilk rawMilk)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into RawMilk(QCtaskID,ResultValue,State) values(:QCtaskID,:ResultValue,:State)";
                int result = conn.Execute(sql, rawMilk);
                return result;
            }
        }
        /// <summary>
        /// 删除生乳检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelRawMilk(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from RawMilk where ID=:ID";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
        }
        /// <summary>
        /// 根据ID获取生乳检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RawMilk GetRawMilkByID(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * RawMilk where ID=:ID";
                var result = conn.Query<RawMilk>(sql, new { ID = id }).FirstOrDefault();
                return result;
            }
        }
        /// <summary>
        /// 获取生乳检验信息
        /// </summary>
        /// <returns></returns>
        public List<RawMilk> GetRawMilks()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select r.*,q.SAMPIEID,q.QCPlan_ID,s.Name,p.QCPlanName,p.Type_ID,p.TargetType_ID,t.*,y.*,g.* from RawMilk r 
                        inner join QCtask q on r.QCtaskID=q.QCtask_ID 
                        inner join Sample s on q.SAMPIEID =s.ID
                        inner join QCPlan p on q.QCPlan_ID =p.ID
                        inner join TargetType t on p.TargetType_ID = t.TargetType_ID
                        inner join Target g on t.TargetType_ID = g.TargetTypePid
                        inner join QCPlanType y on y.Type_ID=p.Type_ID";
                var result = conn.Query<RawMilk>(sql, null);
                return result.ToList<RawMilk>();
            }
        }
        /// <summary>
        /// 修改生乳检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        public int UptRawMilk(RawMilk rawMilk)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update RawMilk set ResultValue=:ResultValue,State=:State where ID=:ID";
                var result = conn.Execute(sql, rawMilk);
                return result;
            }
        }
    }
}
