using System;
using System.Data;
namespace DentalMedical.IDAL
{
    /// <summary>
    /// 接口层designers
    /// </summary>
    public interface Idesigners
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(Guid Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(DentalMedical.Model.designers model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DentalMedical.Model.designers model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(Guid Id);
        bool DeleteList(string Idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DentalMedical.Model.designers GetModel(Guid Id);
        DentalMedical.Model.designers DataRowToModel(DataRow row);
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
        /// 技师登录
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        DentalMedical.Model.designers Query_Code(string userCode, string pwd);

        /// <summary>
        ///  判断密码是否正确
        /// </summary>
        /// <param name="doctors"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        DentalMedical.Model.designers judge_Pwd(DentalMedical.Model.designers designers, string pwd);

          /// <summary>
        /// 更新设计组信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        bool update_designer_Info(string Id, string userName, int? sex = null, string email = null, string logo = null, string dId = null);
        #endregion  MethodEx
    }
}
