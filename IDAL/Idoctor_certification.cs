using System;
using System.Data;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层doctor_certification
	/// </summary>
	public interface Idoctor_certification
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(Guid Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
        string Add(DentalMedical.Model.doctor_certification model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.doctor_certification model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id);
		bool DeleteList(string Idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.doctor_certification GetModel(Guid Id);
		DentalMedical.Model.doctor_certification DataRowToModel(DataRow row);
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
        /// 更新认证信息
        /// </summary>
        bool Update_d_certification(DentalMedical.Model.doctor_certification model);

         /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool delete_d_certification(Guid Id,Guid doctorId);
		#endregion  MethodEx
	} 
}
