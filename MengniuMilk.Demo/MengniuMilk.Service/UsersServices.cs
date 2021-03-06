﻿using System;
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


    public class UsersServices : IUsersServices
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int AddUsers(Users users)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();             
                string Usersql = "select * from Users where UsersName=:UsersName";
             
                var usersName = conn.Query<Users>(Usersql,new { UsersName = users.UsersName });
                int j = -1;
                if (usersName.Count() == 0)
                {
                    string sql = @"insert into Users(UsersName,UsersPwd,Gender,UsersTel,RolesIDs,RolesName,UsersRemark) values(:UsersName,:UsersPwd,:Gender,:UsersTel,:RolesIDs,:RolesName,:UsersRemark)";
                    var result = conn.Execute(sql, users);
                    //如果上条语句执行成功则执行下面语句
                    if (result > 0)
                    {
                        //根据用户名称查询用户ID
                        string sql1 = @"select UsersID from Users where UsersName=:UsersName";
                        //返回一个对象(第一个元素)
                        var ids = conn.Query<Users>(sql1, new { UsersName = users.UsersName }).FirstOrDefault();
                        //分割角色id
                        var roleIDs = users.RolesIDs.Split(',');

                        //循环添加到用户角色关联表
                        for (int i = 0; i < roleIDs.Length; i++)
                        {
                            //实例化用户角色关联表
                            User_Roles user_Roles = new User_Roles();
                            user_Roles.UsersID = ids.UsersID;//为用户ID赋值
                            user_Roles.RolesID = Convert.ToInt32(roleIDs[i]);//为角色ID赋值
                                                                             //用户角色关联表添加语句
                            string sql2 = @"insert into User_Roles(UsersID,RolesID) values(:UsersID,:RolesID)";
                            //执行
                            var result1 = conn.Execute(sql2, user_Roles);
                        }
                    }
                    return result;
                }
                return j;

            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUsers(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"delete  from Users where UsersID=:UsersID";
                var result = conn.Execute(sql, new { UsersID = id });
                if (result > 0)
                {
                    string sql2 = @"delete from User_Roles where UsersID=:UsersID";
                    var result2 = conn.Execute(sql2, new { UsersID = id });
                }
                return result;
            }
        }

        /// <summary>
        /// 根据id查询单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Users> GetUsersByID(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Users where UsersID=:UsersID";
                var result = conn.Query<Users>(sql, new { UsersID = id });
                return result.ToList<Users>();
            }
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<Users> GetUsers()
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from Users";
                var result = conn.Query<Users>(sql, null);
                return result.ToList<Users>();
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUsers(Users users)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"update  Users set UsersName=:UsersName,UsersPwd=:UsersPwd,Gender=:Gender,UsersTel=:UsersTel,RolesIDs=:RolesIDs,RolesName=:RolesName,UsersRemark=UsersRemark where UsersID=:UsersID";
                var result = conn.Execute(sql, users);
                if (result > 0)
                {
                    //根据用户名称查询用户ID
                    string sql1 = @"select UsersID from Users where UsersName=:UsersName";
                    //返回一个对象(第一个元素)
                    var ids = conn.Query<Users>(sql1, new { UsersName = users.UsersName }).FirstOrDefault();

                    //根据用户ID删除用户角色关联表
                    string sql2 = @"delete from User_Roles where UsersID=:UsersID";
                    int result2 = conn.Execute(sql2, new { UsersID = users.UsersID });

                    //分割角色id
                    var roleIDs = users.RolesIDs.Split(',');

                    //循环添加到用户角色关联表
                    for (int i = 0; i < roleIDs.Length; i++)
                    {
                        //实例化用户角色关联表
                        User_Roles user_Roles = new User_Roles();
                        user_Roles.UsersID = ids.UsersID;//为用户ID赋值
                        user_Roles.RolesID = Convert.ToInt32(roleIDs[i]);//为角色ID赋值
                        //用户角色关联表添加语句
                        string sql3 = @"insert into User_Roles(UsersID,RolesID) values(:UsersID,:RolesID)";
                        //执行
                        var result1 = conn.Execute(sql3, user_Roles);
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UsersName"></param>
        /// <param name="UsersPwd"></param>
        /// <returns></returns>
        public Users Login(string UsersName, string UsersPwd)
        {

            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from Users where UsersName=:UsersName and UsersPwd=:UsersPwd";
                var result = conn.Query<Users>(sql, new { UsersName = UsersName, UsersPwd = UsersPwd }).FirstOrDefault();

                return result;
            }
        }

        /// <summary>
        /// 根据登录时的用户ID获取该管理员权限(url)
        /// </summary>
        /// <returns></returns>
        public List<Users> GetUsersPermissionUrls(int id)
        {
            using (OracleConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from Permission where PermissionID in(select  PermissionID  from PERMISSION_ROLES where RolesID in(select RolesID from USER_ROLES where UsersID=(select UsersID from Users where UsersID=:UsersID))) order by rownumber asc";
                var result = conn.Query<Users>(sql, new { UsersID = id });
                return result.ToList<Users>();
            }
        }
    }
}
