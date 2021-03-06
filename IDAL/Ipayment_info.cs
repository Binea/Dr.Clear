﻿using System;
using System.Collections.Generic;
using System.Data;
namespace DentalMedical.IDAL
{
    /// <summary>
    /// 接口层payment_info
    /// </summary>
    public interface Ipayment_info
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(Guid Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(DentalMedical.Model.payment_info model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DentalMedical.Model.payment_info model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(Guid Id);
        bool DeleteList(string Idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DentalMedical.Model.payment_info GetModel(Guid Id);
        DentalMedical.Model.payment_info DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx
         /// <summary>
        /// 获取付款信息List
        /// </summary>
        /// <returns>付款信息集合</returns>
        List<DentalMedical.Model.payment_info> Get_payment_List(Guid factoryId);

        /// <summary>
        /// 开票
        /// </summary>
        /// <param name="payId">付款信息ID</param>
        /// <returns></returns>
        bool open_Invoice(Guid payId);
        #endregion  MethodEx
    }
}
