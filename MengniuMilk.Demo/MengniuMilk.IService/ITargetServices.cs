using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface ITargetServices
    {
        /// <summary>
        /// 添加指标项名称
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        int AddTarget(Target target);
       

        /// <summary>
        /// 获取指标项名称
        /// </summary>
        /// <returns></returns>
        List<Target> GetTargets();
     

        /// <summary>
        /// 删除指标项信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelTarget(int id);
       
        /// <summary>
        /// 修
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        int UptTarget(Target target);
        
    }
}
