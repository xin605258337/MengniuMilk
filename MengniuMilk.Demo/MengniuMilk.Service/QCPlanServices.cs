using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Service
{
    using MengniuMilk.Entity;
    using MengniuMilk.IService;
    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess;
    using System.Data;
    using Newtonsoft.Json;

    public class QCPlanServices : IQCPlanServices
    {
        ConnForOracle connForOracle = new ConnForOracle();

        /// <summary>
        /// 新增质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        public int AddQCPlan(QCPlan qcPlan)
        {
            string sql = string.Format("insert into QCPlan(Code,Name,Type_ID,ObjType_ID,Process_ID,Facility_ID,QCPlan_State,TargetType_ID,Target_ID,StandardValues,StandardValuesMax,StandardValuesMin) values(:Code,:Name,:Type_ID,:ObjType_ID,:Process_ID,:Facility_ID,:QCPlan_State,:TargetType_ID,:Target_ID,:StandardValues,:StandardValuesMax,:StandardValuesMin)",qcPlan.Code,qcPlan.Name,qcPlan.Type_ID,qcPlan.ObjType_ID,qcPlan.Process_ID, qcPlan.Facility_ID, qcPlan.QCPlan_State, qcPlan.TargetType_ID, qcPlan.Target_ID, qcPlan.StandardValues, qcPlan.StandardValuesMax, qcPlan.StandardValuesMin);
           
            int result = connForOracle.ExecuteSQL(sql);
            return result;
        }

        /// <summary>
        /// 删除质检
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteQCPlan(int id)
        {
            string sql = string.Format("delete from QCPlan where ID=:ID",id);
            int result = connForOracle.ExecuteSQL(sql);
            return result;
            
        }

        /// <summary>
        /// 获取质检设备
        /// </summary>
        /// <returns></returns>
        public List<Facility> GetFacilities()
        {
            string sql = "select * from Facility";
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<Facility>>(JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 获取检验工序
        /// </summary>
        /// <returns></returns>
        public List<Process> GetProcess()
        {
            string sql = "select * from Process";
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<Process>>(JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 获取质检对象
        /// </summary>
        /// <returns></returns>
        public List<QCPlanObjType> GetQCPlanObjTypes()
        {
            string sql = "select * from QCPlanObjType";
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<QCPlanObjType>>(JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 获取质检计划信息
        /// </summary>
        /// <returns></returns>
        public List<QCPlan> GetQCPlans()
        {
            string sql = "select q.id,q.code,q.name,t.type_name,p.process_name,o.objtype_name,f.facility_name,r.targettype_name,g.target_name,q.standardvalues,q.standardvaluesmax,q.standardvaluesmin from QCPlan q inner join QCPlanType t on q.type_id = t.type_id inner join Process p on q.process_id = p.process_id inner join QCPlanObjType o on q.objtype_id = o.objtype_id inner join Facility f on q.facility_id = f.facility_id inner join TargetType r on q.targettype_id = r.targettype_id inner join Target g on q.target_id = g.target_id";
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<QCPlan>>(JsonConvert.SerializeObject(dt));
            
        }

        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<QCPlan> GetQCPlansByID(int id)
        {
            string sql =string.Format("select * from QCPlan where ID=:ID",id);
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<QCPlan>>(JsonConvert.SerializeObject(dt));


        }

        /// <summary>
        /// 获取质检类型
        /// </summary>
        /// <returns></returns>
        public List<QCPlanType> GetQCPlanTypes()
        {
            string sql = "select * from QCPlanType";
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<QCPlanType>>(JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 获取指标项名称
        /// </summary>
        /// <returns></returns>
        public List<Target> GetTargets()
        {
            string sql = "select * from Target";
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<Target>>(JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 获取指标项分类
        /// </summary>
        /// <returns></returns>
        public List<TargetType> GetTargetTypes()
        {
            string sql = "select * from TargetType";
            DataTable dt = connForOracle.ReturnDataSet(sql);
            return JsonConvert.DeserializeObject<List<TargetType>>(JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 修改质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        public int UpdateQCPlan(QCPlan qcPlan)
        {
            string sql = string.Format("update QCPlan set Code=:Code,Name=:Name,Type_ID=:Type_ID,ObjType_ID=:ObjType_ID,Process_ID=:Process_ID,Facility_ID=:Facility_ID,QCPlan_State=:QCPlan_State,TargetType_ID=:TargetType_ID,Target_ID=:Target_ID,StandardValues=:StandardValues,StandardValuesMax=:StandardValuesMax,StandardValuesMin=:StandardValuesMin", qcPlan.Code, qcPlan.Name, qcPlan.Type_ID, qcPlan.ObjType_ID, qcPlan.Process_ID, qcPlan.Facility_ID, qcPlan.QCPlan_State, qcPlan.TargetType_ID, qcPlan.Target_ID, qcPlan.StandardValues, qcPlan.StandardValuesMax, qcPlan.StandardValuesMin);
            var result = connForOracle.ExecuteSQL(sql);
            return result;
        }
    }
}
