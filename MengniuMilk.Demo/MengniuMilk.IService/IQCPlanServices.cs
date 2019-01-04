using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
     public  interface IQCPlanServices
    {
        /// <summary>
        /// 新增质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        int AddQCPlan(QCPlan qcPlan);

        /// <summary>
        /// 删除质检
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteQCPlan(int id);

        /// <summary>
        /// 获取质检计划信息
        /// </summary>
        /// <returns></returns>
        List<QCPlan> GetQCPlans();

        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<QCPlan> GetQCPlansByID(int id);

        /// <summary>
        /// 修改质检计划
        /// </summary>
        /// <param name="qcPlan"></param>
        /// <returns></returns>
        int UpdateQCPlan(QCPlan qcPlan);


        /// <summary>
        /// 获取质检类型
        /// </summary>
        /// <returns></returns>
        List<QCPlanType> GetQCPlanTypes();

        /// <summary>
        /// 获取检验工序
        /// </summary>
        /// <returns></returns>
        List<Process> GetProcess();

        /// <summary>
        /// 获取质检对象
        /// </summary>
        /// <returns></returns>
        List<QCPlanObjType> GetQCPlanObjTypes();

        /// <summary>
        /// 获取质检设备
        /// </summary>
        /// <returns></returns>
        List<Facility> GetFacilities();

        /// <summary>
        /// 获取指标项分类
        /// </summary>
        /// <returns></returns>
        List<TargetType> GetTargetTypes();

        /// <summary>
        /// 获取指标项名称
        /// </summary>
        /// <returns></returns>
        List<Target> GetTargets(); 
    }
}
