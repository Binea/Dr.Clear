using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
namespace DentalMedical.IDAL
{
	/// <summary>
	/// 接口层simple_EMR
	/// </summary>
	public interface Isimple_EMR
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(Guid Id,string EMR_Code);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(DentalMedical.Model.simple_EMR model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DentalMedical.Model.simple_EMR model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(Guid Id,string EMR_Code);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DentalMedical.Model.simple_EMR GetModel(Guid Id,string EMR_Code);
		DentalMedical.Model.simple_EMR DataRowToModel(DataRow row);
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
        /// 根据医生登录的账号，选的执业地，病例状态获取emr列表
        /// </summary>
        /// <param name="dId">医生Id</param>
        /// <param name="hId">医院Id</param>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <returns></returns>
        List<DentalMedical.Model.simple_EMR> EMR_D_list(string dId, string hId, int treatmentStauts);

           /// <summary>
        /// 根据厂房登录的账号 和状态 获取到病例列表
        /// </summary>
        /// <param name="fId">厂家Id</param>
        /// <param name="Status">状态</param>
        /// <returns></returns>
         List<DentalMedical.Model.simple_EMR> EMR_F_list(string fId, int Status);

          /// <summary>
        /// 根据状态不同，更新状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="emrcode">病例号</param>
        /// <param name="Id">用户</param>
        /// <param name="processing_requirement">当为加工的时候，有加工要求</param>
        /// <returns></returns>
        int update_Emr_Status(int status, string emrcode, string Id, string processing_requirement = null,string treatmentstatus=null);


         /// <summary>
        /// 更新医生随笔
        /// </summary>
        /// <param name="emrCode">病例编号</param>
        /// <param name="remark">医生随笔</param>
        /// <returns></returns>
        int update_doctorRemark(string emrCode, string remark, string remarkdate, string doctorId);


         /// <summary>
        /// 根据病例号获取病例信息
        /// </summary>
        /// <param name="emrCode"></param>
        /// <returns></returns>
        DentalMedical.Model.simple_EMR get_emr_byCode(string emrCode);

          /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="emrCode">病例号</param>
        /// <returns></returns>
        List<DentalMedical.Model.EMR_stream> get_stream(string emrCode);

          /// <summary>
        /// 根据微信号 获取病人病例列表
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        List<DentalMedical.Model.WX_simple_emr> Get_list_by_weixin(string weixin);

          /// <summary>
        /// 根据医生登录的账号，选的执业地，病例状态,搜索条件获取emr列表
        /// </summary>
        /// <param name="dId">医生Id</param>
        /// <param name="hId">医院Id</param>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <param name="strwhere">搜索条件</param>
        /// <returns></returns>
        List<DentalMedical.Model.simple_EMR> find_Emr_d(string dId, string hId, int treatmentstatus, string strwhere);

        
         /// <summary>
         /// 根据工厂登录的账号，病例状态,搜索条件获取emr列表
         /// </summary>
         /// <param name="fId">工厂Id</param>
         /// <param name="status">状态</param>
         /// <param name="strwhere">条件</param>
         /// <returns></returns>
        List<DentalMedical.Model.simple_EMR> find_Emr_f(string fId, int status, string strwhere);

           /// <summary>
        /// 判断模型文件是否有更新
        /// </summary>
        /// <param name="EMR_Code"></param>
        /// <param name="fileId"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        bool isChangeFile(string EMR_Code, string fileId, int filetype);

          /// <summary>
        /// 获取病人病例
        /// </summary>
        /// <param name="tel">电话号</param>
        /// <returns></returns>
        List<DentalMedical.Model.simple_EMR> get_emrCode(string tel);
        
        /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="tel">电话号</param>
        /// <returns></returns>
        List<DentalMedical.Model.EMR_stream> get_stream_byTel(string tel);

           /// <summary>
        /// 增加一条数据 
        /// </summary>
        Hashtable Add_hash(DentalMedical.Model.simple_EMR model);

        
        /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="openId">微信openId</param>
        /// <returns></returns>
        List<DentalMedical.Model.EMR_stream> get_stream_byWeixin(string openId);

        
        /// <summary>
        /// 事务提交新增病例
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="emrCode"></param>
        /// <returns></returns>
        DentalMedical.Model.simple_EMR simple_add_hash(Hashtable ht, string emrCode);


        
        /// <summary>
        /// 根据设计者登录的账号，病例状态获取emr列表
        /// </summary>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <returns></returns>
        List<DentalMedical.Model.simple_EMR> EMR_design_list(int treatmentstatus);


        /// <summary>
        /// 设计者的账号，根据当前状态的搜索条件获取emr列表
        /// </summary>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <param name="strwhere">搜索条件</param>
        /// <returns></returns>
        List<DentalMedical.Model.simple_EMR> find_Emr_design(int treatmentstatus, string strwhere);

        /// <summary>
        /// 更新就诊状态
        /// </summary>
        /// <param name="traatment"></param>
        /// <param name="EMR_Code"></param>
        /// <returns></returns>
        int update_treatmentstatus(int traatment, string EMR_Code);
    
		#endregion  MethodEx
	} 
}
