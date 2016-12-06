using System;
using System.Collections.Generic;
using System.Data;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层area_BaseData
	/// </summary>
	public interface Iarea_BaseData
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(DentalMedical.Model.area_BaseData model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.area_BaseData model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.area_BaseData GetModel();
		DentalMedical.Model.area_BaseData DataRowToModel(DataRow row);
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
        /// 获取省市地区医院部门数据列表
        /// </summary>
        /// <returns>list</returns>
        List<DentalMedical.Model.area_BaseData> Get_Arealist();

        
        /// <summary>
        /// 获取省市地区数据列表
        /// </summary>
        /// <returns>list</returns>
        List<DentalMedical.Model.area_BaseData> Get_Area();
		#endregion  MethodEx
	} 
}
