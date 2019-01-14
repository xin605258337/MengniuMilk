using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    //指标项分类
    public class TargetType:Target
    {
        /// <summary>
        /// 指标项分类ID
        /// </summary>
        public int TargetType_ID { get; set; }
        /// <summary>
        /// 分类名
        /// </summary>
        public string TargetType_Name { get; set; }
    }
}
