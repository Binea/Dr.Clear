using System;
using System.Data;
using System.Collections.Generic;
using DentalMedical.Common;
using DentalMedical.Model;
using DentalMedical.DALFactory;
using DentalMedical.IDAL;
namespace DentalMedical.BLL
{
    /// <summary>
    /// designers
    /// </summary>
    public partial class designers
    {
        private readonly Idesigners dal = DataAccess.Createdesigners();
        public designers()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DentalMedical.Model.designers model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DentalMedical.Model.designers model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(DentalMedical.Common.PageValidate.SafeLongFilter(Idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DentalMedical.Model.designers GetModel(Guid Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public DentalMedical.Model.designers GetModelByCache(Guid Id)
        {

            string CacheKey = "designersModel-" + Id;
            object objModel = DentalMedical.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = DentalMedical.Common.ConfigHelper.GetConfigInt("ModelCache");
                        DentalMedical.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (DentalMedical.Model.designers)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DentalMedical.Model.designers> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DentalMedical.Model.designers> DataTableToList(DataTable dt)
        {
            List<DentalMedical.Model.designers> modelList = new List<DentalMedical.Model.designers>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DentalMedical.Model.designers model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DentalMedical.Model.designers Login_Des(string DrCode, string DrPwd)
        {
            return dal.Query_Code(DrCode, DrPwd);
        }

        /// <summary>
        ///  判断密码是否正确
        /// </summary>
        /// <param name="doctors"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DentalMedical.Model.designers judge_Pwd(DentalMedical.Model.designers designers, string pwd)
        {
            return dal.judge_Pwd(designers, pwd);
        }

          /// <summary>
        /// 更新设计组信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        public bool update_designer_Info(string Id, string userName, int? sex = null, string email = null, string logo = null, string dId = null)
        {
            return dal.update_designer_Info(Id, userName, sex, email, logo, dId);
        }
        #endregion  ExtensionMethod
    }
}

