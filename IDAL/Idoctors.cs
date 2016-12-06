using System;
using System.Collections.Generic;
using System.Data;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层doctors
	/// </summary>
	public interface Idoctors
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string userCode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		string Add(DentalMedical.Model.doctors model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.doctors model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id,string userCode);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.doctors GetModel(Guid Id,string userCode);
		DentalMedical.Model.doctors DataRowToModel(DataRow row);
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
       /// 医生登录
       /// </summary>
       /// <param name="userCode">用户账号</param>
       /// <param name="pwd">用户密码</param>
       /// <returns></returns>
        DentalMedical.Model.doctors Query_Code(string userCode, string pwd = null);

           /// <summary>
        ///  判断密码是否正确
        /// </summary>
        /// <param name="doctors"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
         DentalMedical.Model.doctors judge_Pwd(DentalMedical.Model.doctors doctors, string pwd);
         /// <summary>
        /// 更新医生在线状态
        /// </summary>
        /// <param name="id">医生Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        bool update_doctor_status(Guid id, int status);

         /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        bool update_doctor_Info(string Id, string userName, int? sex = null, string email = null, string logo = null, string dId = null, string fCode = null);

        /// <summary>
        /// 输入工厂邀请码
        /// </summary>
        /// <param name="Id">医生Id</param>
        /// <param name="fCode">邀请码</param>
        /// <returns></returns>
        int update_F_Code(string Id, string fCode);

          /// <summary>
        /// 医生端自动登录
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        DentalMedical.Model.doctors login_auto(Guid doctorId);

           /// <summary>
        /// 授权认证
        /// </summary>
        /// <param name="certId">认证Id</param>
        /// <param name="doctorId">技师Id</param>
        /// <param name="Pid">授权医生Id</param>
        /// <returns></returns>
        int authorize_technician(Guid certId, Guid doctorId, Guid Pid);

         /// <summary>
        /// 获取注册医生数量
        /// </summary>
        /// <returns></returns>
        int get_doctor_num();

          /// <summary>
        /// 更新认证授权状态
        /// </summary>
        /// <param name="dcId"></param>
        /// <returns></returns>
        int update_dcStatus(Guid dcId);

        /// <summary>
        /// 预约专家界面查找医生
        /// </summary>
        /// <param name="codeid">区号</param>
        /// <returns></returns>
        List<DentalMedical.Model.search_doctor> search_doctor(string codeid);


        
        /// <summary>
        /// 绑定PID
        /// </summary>
        /// <param name="id">医生Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        bool update_doctor_weixin(string userCode, string wenxin);

          /// <summary>
        /// 根据微信获取医生基本信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        DentalMedical.Model.doctors Query_Code_weixin(string openId);


          /// <summary>
        /// 重置医生密码
        /// </summary>
        /// <param name="usercode">医生账号</param>
        /// <returns></returns>
        bool reset_pwd(string usercode);

         /// <summary>
        /// 修改医生密码
        /// </summary>
        /// <param name="usercode">医生账号</param>
        /// <returns></returns>
        bool modify_pwd(string usercode, string userpwd);
		#endregion  MethodEx
	} 
}
