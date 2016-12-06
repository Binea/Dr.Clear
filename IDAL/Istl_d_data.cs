using System;
using System.Data;
namespace DentalMedical.IDAL
{
    /// <summary>
    /// 接口层stl_d_data
    /// </summary>
    public interface Istl_d_data
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(Guid Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        string Add(DentalMedical.Model.stl_d_data model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DentalMedical.Model.stl_d_data model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(Guid Id);
        bool DeleteList(string Idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DentalMedical.Model.stl_d_data GetModel(Guid Id);
        DentalMedical.Model.stl_d_data DataRowToModel(DataRow row);
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
        /// 根据emrcode获取stl文件的最新情况
        /// </summary>
        /// <param name="emr_code"></param>
        /// <returns></returns>
        DentalMedical.Model.stl_d_data get_stl(string emr_code);

        
        /// <summary>
        /// stl文件状态更新；0：废弃
        /// </summary>
        /// <param name="emrcode"></param>
        /// <returns></returns>
        bool update_status(string emrcode);
        #endregion  MethodEx
    }
}
