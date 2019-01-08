using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface IRolesServices
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int AddRoles(Roles roles);


        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteRoles(int id);


        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Roles> GetRolesByID(int id);

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        List<Roles> GetRoles();


        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        int UpdateRoles(Roles roles);
      
    }
}
