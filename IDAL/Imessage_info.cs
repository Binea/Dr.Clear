using System;
using System.Data;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层message_info
	/// </summary>
	public interface Imessage_info
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(Guid Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(DentalMedical.Model.message_info model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.message_info model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id);
		bool DeleteList(string Idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.message_info GetModel(Guid Id);
		DentalMedical.Model.message_info DataRowToModel(DataRow row);
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
        /// 验证码是否正确
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        int validate_code(string tel, string code, string mtype);


          /// <summary>
        /// 判断是否在30秒内连续不断的发送短信
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        int senconds_message(string tel);

         /// <summary>
        /// 根据该电话 ip 获取到今天已发的短信验证码数
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        int count_tel_ip(string tel, string ip);
		#endregion  MethodEx
	} 
}
