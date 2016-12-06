﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层DCImage
	/// </summary>
	public interface IDCImage
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(Guid Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(DentalMedical.Model.DCImage model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.DCImage model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id);
		bool DeleteList(string Idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.DCImage GetModel(Guid Id);
		DentalMedical.Model.DCImage DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx
         /// <summary>
        /// 增加一条数据
        /// </summary>
        Hashtable Add_hash(DentalMedical.Model.DCImage model);
		#endregion  MethodEx
	} 
}
