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
      
    }
}
