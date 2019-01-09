using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface IUsersServices
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        int AddUsers(Users users);
       

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteUsers(int id);


        /// <summary>
        /// 根据id查询单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Users> GetUsersByID(int id);


        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<Users> GetUsers();


        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateUsers(Users users);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UsersName"></param>
        /// <param name="UsersPwd"></param>
        /// <returns></returns>
        Users Login(string UsersName, string UsersPwd);

        /// <summary>
        /// 根据登录时的用户ID获取该管理员权限(url)
        /// </summary>
        /// <returns></returns>
        List<Users> GetUsersPermissionUrls(int id);


    }
}
