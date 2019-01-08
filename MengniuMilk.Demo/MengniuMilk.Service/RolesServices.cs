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
    public  class RolesServices:IRolesServices
    {
        
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int AddRoles(Roles roles)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into Roles(RolesName,PermissionIDs,PermissionName,RolesRemark) values(:RolesName,:PermissionIDs,:PermissionName,:RolesRemark)";
                var result = conn.Execute(sql, roles);

                //如果上条语句执行成功则执行下面语句
                if (result > 0)
                {
                    //根据角色名称查询角色ID
                    string sql1 = @"select RolesID from Roles where RolesName=:RolesName";
                    //返回一个对象(第一个元素)
                    var ids = conn.Query<Roles>(sql1, new { RolesName = roles.RolesName }).FirstOrDefault();
                    //分割权限id
                    var permissionIDs = roles.PermissionIDs.Split(',');

                    //循环添加到角色权限关联表
                    for (int i = 0; i < permissionIDs.Length; i++)
                    {
                        //实例化角色权限关联表
                        Permission_Roles permission_Roles = new Permission_Roles();
                        permission_Roles.RolesID = ids.RolesID;//为角色ID赋值
                        permission_Roles.PermissionID = Convert.ToInt32(permissionIDs[i]);//为权限ID赋值
                        //角色权限关联表添加语句
                        string sql2 = @"insert into Permission_Roles(PermissionID,RolesID) values(:PermissionID,:RolesID)";
                        //执行
                        var result1 = conn.Execute(sql2, permission_Roles);
                    }
                }

                return result;
            }
        }



        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRoles(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete from Roles where RolesID=:RolesID";
                var result = conn.Execute(sql, new { RolesID = id });
                return result;
            }
        }

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Roles> GetRolesByID(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select * from Roles where RolesID=:RolesID";
                var result = conn.Query<Roles>(sql, new { RolesID = id });
                return result.ToList<Roles>();
            }
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        public List<Roles> GetRoles()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Roles";
                var result = conn.Query<Roles>(sql, null);
                return result.ToList<Roles>();
            }
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int UpdateRoles(Roles roles)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "update Roles set RolesName=:RolesName,PermissionIDs=:PermissionIDs,PermissionName=:PermissionName,RolesRemark=:RolesRemark where RolesID=:RolesID";
                var result = conn.Execute(sql, roles);
                return result;
            }
        }

    }
}
