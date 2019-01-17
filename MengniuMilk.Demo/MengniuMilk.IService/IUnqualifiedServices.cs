using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface IUnqualifiedServices
    {
        /// <summary>
        /// 获取不合格记录表信息
        /// </summary>
        /// <returns></returns>
        List<Unqualified> GetUnqualifieds();

        /// <summary>
        /// 删除不合格记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteUnqualified(int id);

        /// <summary>
        /// 修改不合格记录表状态和检验结果值
        /// </summary>
        /// <param name="unqualified"></param>
        /// <returns></returns>
        int UpdateUnqualified(Unqualified unqualified);

        /// <summary>
        /// 删除不合格样品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteSample(int id);

        /// <summary>
        /// 获得不合格样品的不合格指标项数据
        /// </summary>
        /// <returns></returns>
        List<Unqualified> GetDispost(int sampleId);

        /// <summary>
        /// 修改处理方式
        /// </summary>
        /// <param name="unqualified"></param>
        /// <returns></returns>
        int UpdateConduct(Unqualified unqualified);

        /// <summary>
        /// 根据处理方式处理不合格产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Enable(int id);

    }
}
