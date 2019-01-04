using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.Service
{
    using Dapper;
    using MengniuMilk.Entity;
    using MengniuMilk.IService;
    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess;

    public class PermissionServices : IPermissionServices
    {
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int AddPermission(Permission permission)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into Permission(PermissionName,PermissionURL,PermissionEnabel,PermissionRemark,pID) values(:PermissionName,:PermissionURL,:PermissionEnabel,:PermissionRemark,:pID)";
                var result = conn.Execute(sql, permission);
                return result;
            }
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePermission(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from Permission where PermissionID=:PermissionID";
                var result = conn.Execute(sql, new { PermissionID = id });
                return result;
            }
        }

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Permission> GetPermissionByID(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetPermissions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int UpdatePermission(Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
