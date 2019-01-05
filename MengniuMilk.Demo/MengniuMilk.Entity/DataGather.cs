using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 人工数据采集表
    /// </summary>
   public class DataGather
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 设备
        /// </summary>
        public int Facility_ID { get; set; }
        /// <summary>
        /// 工序
        /// </summary>
        public int Process_ID { get; set; }
        /// <summary>
        /// 检验人
        /// </summary>
        public string surveyor { get; set; }
        /// <summary>
        /// 检验时间
        /// </summary>
        public string DateTime { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public int ParameterValues { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
