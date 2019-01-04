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

    public class PermissionServicesController : ApiController
    {
        [Dependency]
        public IPermissionServices permissionServices { get; set; }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPermission")]
        public int AddPermission(Permission permission)
        {
            var result = permissionServices.AddPermission(permission);
            return result;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeletePermission")]
        public int DeletePermission(int id)
        {
            var result = permissionServices.DeletePermission(id);
            return result;
        }

        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPermissionByID")]
        public List<Permission> GetPermissionByID(int id)
        {
            var result = permissionServices.GetPermissionByID(id);
            return result;
        }

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPermissions")]
        public List<Permission> GetPermissions()
        {
            var result = permissionServices.GetPermissions();
            return result;
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePermission")]
        public int UpdatePermission(Permission permission)
        {
            var result = permissionServices.UpdatePermission(permission);
            return result;
        }
    }
}
