using System;
using System.Data;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层factory
	/// </summary>
	public interface Ifactory
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string factoryCode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
        string Add(DentalMedical.Model.factory model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.factory model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id,string factoryCode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.factory GetModel(Guid Id,string factoryCode);
		DentalMedical.Model.factory DataRowToModel(DataRow row);
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
        DentalMedical.Model.factory Login_F(string factoryCode, string factoryPwd);

          /// <summary>
        /// 更新工厂名字
        /// </summary>
        /// <param name="id">工厂Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        bool update_F_name(Guid Id, string factoryName);

          /// <summary>
        /// 更新工厂在线状态
        /// </summary>
        /// <param name="id">工厂Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        bool update_F_status(Guid id, int status);


           /// <summary>
        /// 验证密码正确
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        DentalMedical.Model.factory judge_pwd(DentalMedical.Model.factory factory, string pwd);


         /// <summary>
        /// 获取当前注册的工厂数量
        /// </summary>
        /// <returns></returns>
        int get_factory_num();

         /// <summary>
        /// 工厂端自动登录
        /// </summary>
         DentalMedical.Model.factory Login_F_Auto(Guid Id);

          /// <summary>
        /// 工厂端的交易记录
        /// </summary>
        /// <param name="factory_Id">工厂Id</param>
        /// <returns></returns>
         DataTable get_D_F_num(Guid factory_Id);
            /// <summary>
        /// 更新
        /// </summary>
        /// <param name="main_person">主要联系人</param>
        /// <param name="main_Email">联系人邮箱</param>
        /// <param name="sex">性别</param>
        /// <param name="logo">公司头像</param>
        /// <param name="id">公司Id</param>
        /// <returns></returns>
         bool update_setInfo(string main_person, string main_Email, int sex, string logo, Guid id);
		#endregion  MethodEx
	} 
}
