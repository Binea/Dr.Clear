﻿using System;
using System.Data;
using System.Collections.Generic;
using DentalMedical.Common;
using DentalMedical.Model;
using DentalMedical.DALFactory;
using DentalMedical.IDAL;
namespace DentalMedical.BLL
{
    /// <summary>
    /// authorize_technician
    /// </summary>
    public partial class authorize_technician
    {
        private readonly Iauthorize_technician dal = DataAccess.Createauthorize_technician();
        public authorize_technician()
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
        public string Add(DentalMedical.Model.authorize_technician model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DentalMedical.Model.authorize_technician model)
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
        public DentalMedical.Model.authorize_technician GetModel(Guid Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public DentalMedical.Model.authorize_technician GetModelByCache(Guid Id)
        {

            string CacheKey = "authorize_technicianModel-" + Id;
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
            return (DentalMedical.Model.authorize_technician)objModel;
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
        public List<DentalMedical.Model.authorize_technician> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DentalMedical.Model.authorize_technician> DataTableToList(DataTable dt)
        {
            List<DentalMedical.Model.authorize_technician> modelList = new List<DentalMedical.Model.authorize_technician>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DentalMedical.Model.authorize_technician model;
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
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid doctorId, Guid dcId)
        {
            return dal.Exists(doctorId, dcId);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid doctorId, Guid dcId, Guid mechanicId)
        {
            return dal.Exists(doctorId,dcId,mechanicId);
        }

           /// <summary>
        /// 将之前授权技师置为不可用
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="dcId"></param>
        /// <returns></returns>
        public bool delete_exauthorize(Guid doctorId, Guid dcId)
        {
            return dal.delete_exauthorize(doctorId,dcId);
        }
        #endregion  ExtensionMethod
    }
}

