
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
	/// patientInfo
	/// </summary>
	public partial class patientInfo
	{
		private readonly IpatientInfo dal=DataAccess.CreatepatientInfo();
		public patientInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string patientCode)
		{
            return dal.Exists(patientCode);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_weixin(string weixin)
        {
            return dal.Exists_weixin(weixin);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(DentalMedical.Model.patientInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.patientInfo model)
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
		public bool DeleteList(string Idlist )
		{
            return dal.DeleteList(DentalMedical.Common.PageValidate.SafeLongFilter(Idlist, 0));
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DentalMedical.Model.patientInfo GetModel(Guid Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DentalMedical.Model.patientInfo GetModelByCache(Guid Id)
		{
			
			string CacheKey = "patientInfoModel-" + Id;
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
				catch{}
			}
			return (DentalMedical.Model.patientInfo)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DentalMedical.Model.patientInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DentalMedical.Model.patientInfo> DataTableToList(DataTable dt)
		{
			List<DentalMedical.Model.patientInfo> modelList = new List<DentalMedical.Model.patientInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DentalMedical.Model.patientInfo model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
      /// 根据电话更新数据中的微信号
      /// </summary>
      /// <param name="weixin"></param>
      /// <param name="tel"></param>
      /// <returns></returns>
        public bool Update_weixin(string weixin, string tel)
        {
            return dal.Update_weixin(weixin,tel);
        }

          /// <summary>
        ///  根据账号查询信息是否存在
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        public DentalMedical.Model.patientInfo Query_Code(string patientCode, string pwd=null)
        {
            return dal.Query_Code(patientCode,pwd);
        }

         /// <summary>
        ///  判断密码是否正确
        /// </summary>
        /// <param name="patientInfo"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DentalMedical.Model.patientInfo judge_Pwd(DentalMedical.Model.patientInfo patientInfo, string pwd)
        {
            return dal.judge_Pwd(patientInfo,pwd);
        }


          /// <summary>
        /// 更新病人信息
        /// </summary>
        public bool Update_patientInfo(DentalMedical.Model.patientInfo model)
        {
            return dal.Update_patientInfo(model);
        }
        /// <summary>
        ///  根据账号查询信息是否存在
        /// </summary>
        /// <param name="weixin">weixinhao</param>
        /// <returns></returns>
        public DentalMedical.Model.patientInfo Query_weixin(string weixin)
        {
            return dal.Query_weixin(weixin);
        }

           /// <summary>
        /// 绑定微信账号
        /// </summary>
        public bool Update_weixin_patientinfo(string openID, string nickName, string HeadImgUrl, string patientCode)
        {
            return dal.Update_weixin(openID,nickName,HeadImgUrl,patientCode);
        }
		#endregion  ExtensionMethod
	}
}

