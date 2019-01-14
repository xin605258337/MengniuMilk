using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 不合格记录表
    /// </summary>
    public  class Unqualified:QCtask
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 质检任务ID
        /// </summary>
        public int QCtask_ID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 检验结果值
        /// </summary>
        public int Result { get; set; }

    }
}
