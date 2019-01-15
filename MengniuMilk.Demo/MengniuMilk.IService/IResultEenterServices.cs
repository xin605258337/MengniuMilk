using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
   public interface IResultEenterServices
    {
        /// <summary>
        /// 获取日志
        /// </summary>
        /// <returns></returns>
        List<ResultEenter> GetResultEenters();

        /// <summary>
        /// 添加结果录入信息
        /// </summary>
        /// <returns></returns>
        int AddResultEenters(ResultEenter resultEenter);

    }
}
