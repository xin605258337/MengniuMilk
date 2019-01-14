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
    public class RawMilkServicesController : ApiController
    {
        [Dependency]

        public IRawMilkServices RawMilkServices { get; set;}

        /// <summary>
        /// 添加生乳质量检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRawMilk")]
        public int AddRawMilk(RawMilk rawMilk)
        {
            return RawMilkServices.AddRawMilk(rawMilk);
        }
        /// <summary>
        /// 删除生乳检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DelRawMilk")]
        public int DelRawMilk(int id)
        {
            return RawMilkServices.DelRawMilk(id);
        }
        /// <summary>
        /// 根据ID获取生乳检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRawMilkByID")]
        public RawMilk GetRawMilkByID(int id)
        {
            return RawMilkServices.GetRawMilkByID(id);
        }
        /// <summary>
        /// 获取生乳检验信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRawMilks")]
        public List<RawMilk> GetRawMilks()
        {
            return RawMilkServices.GetRawMilks();
        }
        /// <summary>
        /// 修改生乳检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UptRawMilk")]
        public int UptRawMilk(RawMilk rawMilk)
        {
            return RawMilkServices.UptRawMilk(rawMilk);
        }

        /// <summary>
        /// 修改质检任务状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangeState")]
        public int ChangeState(int id)
        {
            return RawMilkServices.ChangeState(id);

        }

        /// <summary>
        /// 根据检验结果将质检任务ID添加到质检结果录入表中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddResult")]
        public int AddResult(int id)
        {
            return RawMilkServices.AddResult(id);
        }
    }
}
