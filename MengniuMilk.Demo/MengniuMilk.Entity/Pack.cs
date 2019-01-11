using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 包装检验
    /// </summary>
   public class Pack
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 质检任务ID
        /// </summary>
        public int QCtaskID { get; set; }
        /// <summary>
        /// 检验结果值
        /// </summary>
        public int ResultValue { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

    }
}
