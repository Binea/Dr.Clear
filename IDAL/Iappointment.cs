using System;
using System.Collections.Generic;
using System.Data;
namespace DentalMedical.IDAL
{
    /// <summary>
    /// 接口层appointment
    /// </summary>
    public interface Iappointment
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(Guid Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        string Add(DentalMedical.Model.appointment model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DentalMedical.Model.appointment model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(Guid Id);
        bool DeleteList(string Idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DentalMedical.Model.appointment GetModel(Guid Id);
        DentalMedical.Model.appointment DataRowToModel(DataRow row);
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
        /// 获取病人预约列表
        /// </summary>
        /// <param name="mainId">用户Id</param>
        /// <returns></returns>
        List<DentalMedical.Model.appointment> get_appointmentList(Guid mainId);

          /// <summary>
        /// 获取病人预约列表
        /// </summary>
        /// <param name="mainId">用户Id</param>
        /// <returns></returns>
        List<DentalMedical.Model.appointment> get_appointmentList_byweixin(string weixin);
        #endregion  MethodEx
    }
}
