using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    //指标项名称表
    public class Target
    {
        /// <summary>
        /// 指标项ID
        /// </summary>
        public int Target_ID { get; set; }
        /// <summary>
        /// 指标项名称
        /// </summary>
        public string Target_Name { get; set; }
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

        /// <summary>
        /// 指标项分类
        /// </summary>
        public int TargetTypePid{ get; set; }
    }
}
