﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengniuMilk.IService
{
    using MengniuMilk.Entity;
    public interface IPackServices
    {
        /// <summary>
        /// 获取包装检验信息
        /// </summary>
        /// <returns></returns>
        List<Pack> GetPack();
        /// <summary>
        /// 删除包装检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeletePack(int id);
        /// <summary>
        /// 根据ID获取包装检验信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pack GetPackByID(int id);
        /// <summary>
        /// 修改包装检验信息
        /// </summary>
        /// <param name="rawMilk"></param>
        /// <returns></returns>
        int UpdatePack(Pack pack);

        /// <summary>
        /// 修改包装任务状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ChangeStatePack(int id);

        /// <summary>
        /// 根据检验结果将质检任务ID添加到质检结果录入表中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int AddResultByPack(int id);
    }
}
