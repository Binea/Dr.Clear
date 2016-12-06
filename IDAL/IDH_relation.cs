using System;
using System.Collections.Generic;
using System.Data;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层DH_relation
	/// </summary>
	public interface IDH_relation
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(Guid Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(DentalMedical.Model.DH_relation model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.DH_relation model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id);
		bool DeleteList(string Idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.DH_relation GetModel(Guid Id);
		DentalMedical.Model.DH_relation DataRowToModel(DataRow row);
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
        /// 获取医院科室列表
        /// </summary>
        /// <param name="cityCode">若提供城市编号则筛选该城市下的医院科室</param>
        /// <returns></returns>
        List<DentalMedical.Model.DH_relation> Get_HDList(string cityCode = null);
		#endregion  MethodEx
	} 
}
