using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MengniuMilk.Api.Controllers
{
    using MengniuMilk.Entity;
    using MengniuMilk.IService;
    using MengniuMilk.Service;
    using Unity.Attributes;
    public class RolesServicesController : ApiController
    {
        [Dependency]
        public IRolesServices RolesServices { get; set; }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRoles")]
        public int AddRoles(Roles roles)
        {
            var result = RolesServices.AddRoles(roles);
            return result;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteRoles")]
        public int DeleteRoles(int id)
        {
            var result = RolesServices.DeleteRoles(id);
            return result;
        }

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRolesByID")]
        public List<Roles> GetRolesByID(int id)
        {
            var result = RolesServices.GetRolesByID(id);
            return result;
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRoles")]
        public List<Roles> GetRoles()
        {
            var result = RolesServices.GetRoles();
            return result;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateRoles")]
        public int UpdateRoles(Roles roles)
        {
            var result = RolesServices.UpdateRoles(roles);
            return result;
        }
    }
}
