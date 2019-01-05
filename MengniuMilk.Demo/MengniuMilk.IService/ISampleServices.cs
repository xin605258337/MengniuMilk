using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public  interface ISampleServices
    {
        /// <summary>
        /// 采样表添加
        /// </summary>
        /// <param name="Sample"></param>
        /// <returns></returns>
        int AddSample(Sample sample);

        /// <summary>
        /// 获取采样表信息
        /// </summary>
        /// <returns></returns>
        List<Sample> GetSample();
        /// <summary>
        /// 采样表删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelSample(int id);
        /// <summary>
        /// 采样表修改
        /// </summary>
        /// <param name="Sample"></param>
        /// <returns></returns>

        int UptSample(Sample sample);

        /// <summary>
        /// 根据ID单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Sample> GetSampleById(int id);
    }
}
