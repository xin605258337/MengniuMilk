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
    public class PackServices : IPackServices
    { 
        
      /// <summary>
      /// 修改包装任务状态
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public int ChangeState(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update QCtask set State=1 where QCtask_ID = (select QCtaskID from Pack where ID=:ID)";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
        }

        /// <summary>
        /// 删除包装检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePack(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from Pack where ID=:ID";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
        }

        /// <summary>
        /// 获取包装检验信息
        /// </summary>
        /// <returns></returns>
        public List<Pack> GetPack()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select k.*,q.SAMPIEID,q.QCPlan_ID,s.Name,p.QCPlanName,p.Type_ID,p.TargetType_ID,t.*,y.*,g.* from Pack k
                        inner join QCtask q on k.QCtaskID=q.QCtask_ID 
                        inner join Sample s on q.SAMPIEID =s.ID
                        inner join QCPlan p on q.QCPlan_ID =p.ID
                        inner join TargetType t on p.TargetType_ID = t.TargetType_ID
                        inner join Target g on t.TargetType_ID = g.TargetTypePid
                        inner join QCPlanType y on y.Type_ID=p.Type_ID";
                var result = conn.Query<Pack>(sql, null);
                return result.ToList<Pack>();
            }
        }

        /// <summary>
        /// 根据ID获取包装检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pack GetPackByID(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * Pack where ID=:ID";
                var result = conn.Query<Pack>(sql, new { ID = id }).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 修改包装检验信息
        /// </summary>
        /// <param name="Pack"></param>
        /// <returns></returns>
        public int UpdatePack(Pack pack)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update Pack set ResultValue=:ResultValue,State=:State where ID=:ID";
                var result = conn.Execute(sql, pack);
                return result;
            }
        }

        /// <summary>
        /// 根据检验结果将质检任务ID添加到质检结果录入表中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddResultByPack(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into ResultEenter(QCTASK_ID) select QCtaskID from Pack where ID=:ID ";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
        }
    }
}
