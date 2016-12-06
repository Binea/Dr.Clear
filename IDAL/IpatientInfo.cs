using System;
using System.Data;
namespace DentalMedical.IDAL
{
    /// <summary>
    /// 接口层patientInfo
    /// </summary>
    public interface IpatientInfo
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string patientCode);

         /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists_weixin(string weixin);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        string Add(DentalMedical.Model.patientInfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DentalMedical.Model.patientInfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(Guid Id);
        bool DeleteList(string Idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DentalMedical.Model.patientInfo GetModel(Guid Id);
        DentalMedical.Model.patientInfo DataRowToModel(DataRow row);
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
      /// 根据电话更新数据中的微信号
      /// </summary>
      /// <param name="weixin"></param>
      /// <param name="tel"></param>
      /// <returns></returns>
        bool Update_weixin(string weixin, string tel);

          /// <summary>
        ///  根据账号查询信息是否存在
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        DentalMedical.Model.patientInfo Query_Code(string patientCode, string pwd=null);

         /// <summary>
        ///  判断密码是否正确
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        DentalMedical.Model.patientInfo judge_Pwd(DentalMedical.Model.patientInfo patientInfo, string pwd);

          /// <summary>
        /// 更新病人信息
        /// </summary>
        bool Update_patientInfo(DentalMedical.Model.patientInfo model);

         /// <summary>
        ///  根据账号查询信息是否存在
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        DentalMedical.Model.patientInfo Query_weixin(string weixin);
        

           /// <summary>
        /// 绑定微信账号
        /// </summary>
        bool Update_weixin(string openID, string nickName, string HeadImgUrl, string patientCode);
        #endregion  MethodEx
    }
}
