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
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select * from Permission where PermissionID=:PermissionID";
                var result = conn.Query<Permission>(sql, new { PermissionID = id });
                return result.ToList<Permission>();
            }
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetPermissions()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Permission";
                var result = conn.Query<Permission>(sql, null);
                return result.ToList<Permission>();
            }
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int UpdatePermission(Permission permission)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "update Permission set PermissionName=:PermissionName,PermissionURL=:PermissionURL,PermissionEnabel=:PermissionEnabel,PermissionRemark=:PermissionRemark,pID=:pID where PermissionID=:PermissionID";
                var result = conn.Execute(sql, permission);
                return result;
            }
        }

        /// <summary>
        /// 获得权限所有父节点
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public List<Permission> GetPermissionsPid()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "select * from permission where pID=0";
                var resul = conn.Query<Permission>(sql);
                return resul.ToList<Permission>();
            }
        }


    }
}
