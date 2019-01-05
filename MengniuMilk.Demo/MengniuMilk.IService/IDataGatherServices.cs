using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
   
   public  interface IDataGatherServices
    {
        /// <summary>
        /// 人工数据采集表添加
        /// </summary>
        /// <param name="dataGather"></param>
        /// <returns></returns>
        int AddDataGather(DataGather dataGather);

        /// <summary>
        /// 获取人工数据采集表信息
        /// </summary>
        /// <returns></returns>
        List<DataGather> GetDataGathers();
        /// <summary>
        /// 人工数据表删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelDateGathers(int id);
        /// <summary>
        /// 人工数据采集表修改
        /// </summary>
        /// <param name="dataGather"></param>
        /// <returns></returns>

        int UptDateGathers(DataGather dataGather);

        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<DataGather> GetDataGathersById(int id);
    }
}
