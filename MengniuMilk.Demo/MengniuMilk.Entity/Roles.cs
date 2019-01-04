using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RolesID { get; set; }
        
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RolesName { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionIDs { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string RolesRemark { get; set; }
    }
}
