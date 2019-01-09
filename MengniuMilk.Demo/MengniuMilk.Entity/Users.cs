using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    public  class Users:Permission
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UsersID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UsersName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string UsersPwd { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string UsersTel { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RolesIDs { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RolesName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string UsersRemark { get; set; }
    }
}
