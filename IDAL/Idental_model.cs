using System;
using System.Data;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层dental_model
	/// </summary>
	public interface Idental_model
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(Guid Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(DentalMedical.Model.dental_model model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.dental_model model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id);
		bool DeleteList(string Idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.dental_model GetModel(Guid Id);
		DentalMedical.Model.dental_model DataRowToModel(DataRow row);
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
        /// 根据病例号获取最新口腔模型
        /// </summary>
        DentalMedical.Model.dental_model GetModel(string emrCode);

          /// <summary>
        /// 将该病例空腔模型置为不可用
        /// </summary>
        /// <param name="emrcode"></param>
        /// <returns></returns>
        bool update_model_flag(string emrcode);
		#endregion  MethodEx
	} 
}
