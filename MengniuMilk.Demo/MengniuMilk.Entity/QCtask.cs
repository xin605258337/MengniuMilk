using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    //质检任务表
    public class QCtask
    {
        /// <summary>
        /// 质检任务ID
        /// </summary>
        public int QCtask_ID { get; set; }
        /// <summary>
        /// 质检计划
        /// </summary>
        public int QCPlan_ID { get; set; }
        /// <summary>
        /// 质检类型
        /// </summary>
        public int QCPlanType { get; set;}
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }

    }
}
