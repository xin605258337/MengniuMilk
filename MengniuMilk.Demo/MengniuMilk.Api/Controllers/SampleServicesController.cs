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
    public class SampleServicesController : ApiController
    {
        [Dependency]
        public ISampleServices SampleServices { get; set; }

        /// <summary>
        /// 采样表添加
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddSample")]
        public int AddSample(Sample sample)
        {
            return SampleServices.AddSample(sample);
        }
        /// <summary>
        /// 采样表删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DelSample")]
        public int DelSample(int id)
        {
            return SampleServices.DelSample(id);
        }
        /// <summary>
        /// 获取采样表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSample")]
        public List<Sample> GetSample()
        {
            return SampleServices.GetSample();
        }
        /// <summary>
        /// 获取采样表单个ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSampleById")]
        public List<Sample> GetSampleById(int id)
        {
            return SampleServices.GetSampleById(id);
        }
        /// <summary>
        /// 采样表修改
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UptSample")]
        public int UptSample(Sample sample)
        {
            return SampleServices.UptSample(sample);
        }

    }
}
