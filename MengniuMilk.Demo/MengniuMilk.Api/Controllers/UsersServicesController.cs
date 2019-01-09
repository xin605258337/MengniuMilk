using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MengniuMilk.Api.Controllers
{
    using MengniuMilk.Entity;
    using MengniuMilk.Service;
    using MengniuMilk.IService;
    using Unity.Attributes;
  

    public class UsersServicesController : ApiController
    {
        [Dependency]
        public IUsersServices UsersServices { get; set; }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUsers")]
        public int AddUsers(Users users)
        {
            // 对用户输入的密码进行MD5加密  
            users.UsersPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(users.UsersPwd, "MD5");
            var result = UsersServices.AddUsers(users);
            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteUsers")]
        public int DeleteUsers(int id)
        {
            var result = UsersServices.DeleteUsers(id);
            return result;
        }

        /// <summary>
        /// 根据id查询单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsersByID")]
        public List<Users> GetUsersByID(int id)
        {
            var result = UsersServices.GetUsersByID(id);
            return result;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            var result = UsersServices.GetUsers();
            return result;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateUsers")]
        public int UpdateUsers(Users users)
        {
            var result = UsersServices.UpdateUsers(users);
            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UsersName"></param>
        /// <param name="UsersPwd"></param>
        /// <returns></returns>
        public Users Login(string UsersName, string UsersPwd)
        {
            // 对用户输入的密码进行MD5加密  
            UsersPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(UsersPwd, "MD5");
            var result = UsersServices.Login(UsersName, UsersPwd);
            return result;
        }
    }
}
