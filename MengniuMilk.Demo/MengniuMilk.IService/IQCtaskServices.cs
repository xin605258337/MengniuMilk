using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface IQCtaskServices
    {
        /// <summary>
        /// 添加质检任务信息
        /// </summary>
        /// <param name="qCtask"></param>
        /// <returns></returns>
        int AddQCtask(QCtask qCtask);

        /// <summary>
        /// 获取质检任务信息
        /// </summary>
        /// <returns></returns>
        List<QCtask> GetQCtasks();

        /// <summary>
        /// 获取之间计划名称
        /// </summary>
        /// <returns></returns>
        List<QCPlan> GetQCPlansName();

        /// <summary>
        /// 删除质检任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelQCtask(int id);

        /// <summary>
        /// 修改质检任务信息
        /// </summary>
        /// <param name="qCtask"></param>
        /// <returns></returns>
        int UptQCtask(QCtask qCtask);

        /// <summary>
        /// 根据质检任务ID获取质检任务中样品ID把质检任务样品ID添加到质检结果录入表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetQCtaskbyID(int id);

        /// <summary>
        /// 把质检任务ID添加到生乳质量检验表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetQCtaskbyName(int id);



        }
}
