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
    public class DataGatherServicesController : ApiController
    {
        [Dependency]
        
        
        public IDataGatherServices DataGatherServices { get; set; }
        /// <summary>
        /// 人工数据采集表添加
        /// </summary>
        /// <param name="dataGather"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddDataGather")]
        public int AddDataGather(DataGather dataGather)
        {
            return DataGatherServices.AddDataGather(dataGather);
        
        }
        /// <summary>
        /// 人工数据采集表删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DelDateGathers")]
        public int DelDateGathers(int id)
        {
            return DataGatherServices.DelDateGathers(id);
        }
        /// <summary>
        /// 人工数据采集表添加查看
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDataGathers")]
        public List<DataGather> GetDataGathers()
        {
            return DataGatherServices.GetDataGathers();
        }
        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDataGathersById")]
        public List<DataGather> GetDataGathersById(int id)
        {
            return DataGatherServices.GetDataGathersById(id);
        }

        /// <summary>
        /// 人工数据采集表添加修改
        /// </summary>
        /// <param name="dataGather"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UptDateGathers")]
        public int UptDateGathers(DataGather dataGather)
        {
            return DataGatherServices.UptDateGathers(dataGather);
        }
    }
}
