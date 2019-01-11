using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;

    public  interface ITargetTypeServices
    {
        /// <summary>
        /// 添加指标项分类
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        int AddTargetType(TargetType targetType);

        /// <summary>
        /// 获取指标项分类
        /// </summary>
        /// <returns></returns>
        List<TargetType> GetTargetTypes();

        /// <summary>
        /// 删除指标项分类
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        int DeleteTargetType(int id);


        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<TargetType> GetTargetTypesByID(int id);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        int UpdateTargetType(TargetType targetType);
       
    }
}
