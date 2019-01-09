using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface IRawMilkServices
    {
        /// <summary>
        /// 添加生乳质量检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        int AddRawMilk(RawMilk rawMilk);
        /// <summary>
        /// 获取生乳检验信息
        /// </summary>
        /// <returns></returns>
        List<RawMilk> GetRawMilks();
        /// <summary>
        /// 删除生乳检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelRawMilk(int id);
        /// <summary>
        /// 根据ID获取生乳检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RawMilk GetRawMilkByID(int id);
        /// <summary>
        /// 修改生乳检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        int UptRawMilk(RawMilk rawMilk);
    }
}
