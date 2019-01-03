using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 质检计划表
    /// </summary>
  public class QCPlan
    {
        /// <summary>
        /// 质检计划ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 质检计划编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type_ID { get; set; }
        /// <summary>
        /// 对象类型
        /// </summary>
        public int ObjType_ID { get; set; }
        /// <summary>
        /// 检验工序
        /// </summary>
        public int Process_ID { get; set; }
        /// <summary>
        /// 质检设备
        /// </summary>
        public int Facility_ID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>

        public int QCPlan_State { get; set; }
        /// <summary>
        /// 指标项分类
        /// </summary>
        public int TargetType_ID { get; set; }
        /// <summary>
        /// 指标项名
        /// </summary>
        public int Target_ID { get; set; }
        /// <summary>
        /// 标准值
        /// </summary>
        public decimal StandardValues { get; set; }
        /// <summary>
        /// 标准值上限
        /// </summary>
        public decimal StandardValuesMax { get; set; }
        /// <summary>
        /// 标准值下限
        /// </summary>
        public decimal StandardValuesMin { get; set; }
    }
}
