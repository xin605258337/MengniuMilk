using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;

    public  interface IPermissionServices
    {
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        int AddPermission(Permission permission);

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeletePermission(int id);

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        List<Permission> GetPermissions();

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Permission> GetPermissionByID(int id);

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        int UpdatePermission(Permission permission);

    }
}
