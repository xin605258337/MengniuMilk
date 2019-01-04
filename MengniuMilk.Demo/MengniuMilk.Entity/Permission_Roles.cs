using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 权限角色关联表
    /// </summary>
    public class Permission_Roles
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Permission_RolesID { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public int PermissionID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RolesID { get; set; }
    }
}
