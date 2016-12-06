using System;
using System.Data;
using System.Collections;
namespace DentalMedical.IDAL
{
    /// <summary>
    /// 接口层EMR_stream
    /// </summary>
    public interface IEMR_stream
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(Guid Id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(DentalMedical.Model.EMR_stream model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DentalMedical.Model.EMR_stream model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(Guid Id);
        bool DeleteList(string Idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DentalMedical.Model.EMR_stream GetModel(Guid Id);
        DentalMedical.Model.EMR_stream DataRowToModel(DataRow row);
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
        /// 增加一条数据
        /// </summary>
         Hashtable Add_hash(DentalMedical.Model.EMR_stream model);
        #endregion  MethodEx
    }
}
