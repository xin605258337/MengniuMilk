using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 质检结果录入表
    /// </summary>
   public class ResultEenter:QCtask
    {
        /// <summary>
        /// 质检结果录入ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 质检任务ID
        /// </summary>
        public int QCtask_ID { get; set; }
        /// <summary>
        /// 质检人[登录用户]
        /// </summary>
        public int Users_ID { get; set; }
        /// <summary>
        /// 质检结果
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UsersName { get; set; }

        /// <summary>
        /// 分类名
        /// </summary>
        public string TargetType_Name { get; set; }


    }
}
