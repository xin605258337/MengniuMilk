using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Entity
{
    public class User_Roles
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Users_RolesID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UsersID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RolesID { get; set; }

    }
}
