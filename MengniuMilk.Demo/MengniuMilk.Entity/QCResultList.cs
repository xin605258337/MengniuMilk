using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    //指标项检验结果明细表(指标项和样品多对多，输入每个指标项的结果值)
    public class QCResultList: TargetType
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 检验样品ID（外键）
        /// </summary>
        public int SampleID { get; set; }
        /// <summary>
        /// 指标项ID 
        /// </summary>
        public int TargetID { get; set; }
        /// <summary>
        /// 检验结果值
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 检验结果（0为不符合，1为符合）
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 质检任务
        /// </summary>
        public int QCTaskID { get; set; }
    }
}
