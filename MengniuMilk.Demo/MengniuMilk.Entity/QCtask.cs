using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    //质检任务表
    public class QCtask : QCPlan
    {
        /// <summary>
        /// 质检任务ID
        /// </summary>
        public int QCtask_ID { get; set; }
        /// <summary>
        /// 质检计划
        /// </summary>
        public int QCPLAN_ID { get; set; }
        /// <summary>
        /// 质检类型
        /// </summary>
        public string QCPlanType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 样品ID
        /// </summary>
        public int SAMPIEID { get; set; }
        /// <summary>
        /// 通知时间
        /// </summary>

        public string InformTime { get; set; }
        /// <summary>
        /// 质检计划名称
        /// </summary>
        public new string QCPlanName { get; set; }

    }
}
