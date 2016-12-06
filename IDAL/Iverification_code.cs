using System;
using System.Data;
namespace DentalMedical.IDAL
{
    /// <summary>
    /// 接口层verification_code
    /// </summary>
    public interface Iverification_code
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(Guid id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        string Add(DentalMedical.Model.verification_code model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(DentalMedical.Model.verification_code model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(Guid id);
        bool DeleteList(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        DentalMedical.Model.verification_code GetModel(Guid id);
        DentalMedical.Model.verification_code DataRowToModel(DataRow row);
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

        #endregion  MethodEx
    }
}
