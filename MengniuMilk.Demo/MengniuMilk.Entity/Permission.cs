using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 权限表
    /// </summary>
    public  class Permission
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PermissionID { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// 地址URL
        /// </summary>
        public string PermissionURL { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int PermissionEnabel { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string PermissionRemark { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int pID { get; set; }


    }
}
