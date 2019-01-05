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
    
    public class QCPlanServices : IQCPlanServices
    {
       

        /// <summary>
        /// 新增质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        public int AddQCPlan(QCPlan qcPlan)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into QCPlan(Code,Name,Type_ID,ObjType_ID,Process_ID,Facility_ID,QCPlan_State,TargetType_ID,Target_ID,StandardValues,StandardValuesMax,StandardValuesMin) values(:Code,:Name,:Type_ID,:ObjType_ID,:Process_ID,:Facility_ID,:QCPlan_State,:TargetType_ID,:Target_ID,:StandardValues,:StandardValuesMax,:StandardValuesMin)";
                int result = conn.Execute(sql, qcPlan);
                return result;
            }
        }

        /// <summary>
        /// 删除质检
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteQCPlan(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from QCPlan where ID=:ID";
                var result = conn.Execute(sql, new { ID = id });
                return result;
            }
            
        }

        /// <summary>
        /// 获取质检设备
        /// </summary>
        /// <returns></returns>
        public List<Facility> GetFacilities()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Facility";
                var result = conn.Query<Facility>(sql, null);
                return result.ToList<Facility>();
            }
        }

        /// <summary>
        /// 获取检验工序
        /// </summary>
        /// <returns></returns>
        public List<Process> GetProcess()
        {

            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Process";
                var result = conn.Query<Process>(sql, null);
                return result.ToList<Process>();
            }
        }
        
        /// <summary>
        /// 获取质检对象
        /// </summary>
        /// <returns></returns>
        public List<QCPlanObjType> GetQCPlanObjTypes()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from QCPlanObjType";
                var result = conn.Query<QCPlanObjType>(sql, null);
                return result.ToList<QCPlanObjType>();
            }
        }

        /// <summary>
        /// 获取质检计划信息
        /// </summary>
        /// <returns></returns>
        public List<QCPlan> GetQCPlans()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "select q.ID,q.Code,q.Name,t.Type_Name,p.Process_Name,o.ObjType_Name,f.Facility_Name,r.TargetType_Name,g.Target_Name,q.QCPlan_State,q.StandardValues,q.StandardValuesMax,q.StandardValuesMin,q.Type_ID,q.Process_ID,q.ObjType_ID,q.Facility_ID,q.TargetType_ID,q.Target_ID from QCPlan q left join QCPlanType t on q.Type_ID=t.Type_ID left join Process p on q.Process_ID=p.Process_ID left join QCPlanObjType o on q.ObjType_ID=o.ObjType_ID left join Facility f on q.Facility_ID=f.Facility_ID left join TargetType r on q.TargetType_ID=r.TargetType_ID left join Target g on q.Target_ID=g.Target_ID";
                var result = conn.Query<QCPlan>(sql, null);
                return result.ToList<QCPlan>();
            }
        }

        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<QCPlan> GetQCPlansByID(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from QCPlan where ID=:ID";
                var result = conn.Query<QCPlan>(sql, new { ID = id });
                return result.ToList<QCPlan>();
            }


        }

        /// <summary>
        /// 获取质检类型
        /// </summary>
        /// <returns></returns>
        public List<QCPlanType> GetQCPlanTypes()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from QCPlanType";
                var result = conn.Query<QCPlanType>(sql, null);
                return result.ToList<QCPlanType>();
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
                string sql = @"select * from Target";
                var result = conn.Query<Target>(sql, null);
                return result.ToList<Target>();
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
        /// 修改质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        public int UpdateQCPlan(QCPlan qcPlan)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update QCPlan set Code=:Code,Name=:Name,Type_ID=:Type_ID,ObjType_ID=:ObjType_ID,Process_ID=:Process_ID,Facility_ID=:Facility_ID,QCPlan_State=:QCPlan_State,TargetType_ID=:TargetType_ID,Target_ID=:Target_ID,StandardValues=:StandardValues,StandardValuesMax=:StandardValuesMax,StandardValuesMin=:StandardValuesMin where ID=:ID";
                var result = conn.Execute(sql, qcPlan);
                return result;
            }
        }
    }
}
