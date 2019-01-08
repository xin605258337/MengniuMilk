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

    public class UsersServices:IUsersServices
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
                return result;
            }
        }

    }
}
