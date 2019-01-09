using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 采样表
    /// </summary>
   public class Sample
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 样品名称    
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 样品编号
        /// </summary>
        public string Code { get; set; }
    }
}
