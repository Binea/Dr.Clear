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
	/// factory
	/// </summary>
	public partial class factory
	{
		private readonly Ifactory dal=DataAccess.Createfactory();
		public factory()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string factoryCode)
		{
			return dal.Exists(factoryCode);
		}

		/// <summary>
		/// 工厂端注册
		/// </summary>
        public string Add(DentalMedical.Model.factory model)
		{

			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.factory model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Id,string factoryCode)
		{
			
			return dal.Delete(Id,factoryCode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DentalMedical.Model.factory GetModel(Guid Id,string factoryCode)
		{
			
			return dal.GetModel(Id,factoryCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DentalMedical.Model.factory GetModelByCache(Guid Id,string factoryCode)
		{
			
			string CacheKey = "factoryModel-" + Id+factoryCode;
			object objModel = DentalMedical.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,factoryCode);
					if (objModel != null)
					{
						int ModelCache = DentalMedical.Common.ConfigHelper.GetConfigInt("ModelCache");
						DentalMedical.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DentalMedical.Model.factory)objModel;
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
		public List<DentalMedical.Model.factory> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DentalMedical.Model.factory> DataTableToList(DataTable dt)
		{
			List<DentalMedical.Model.factory> modelList = new List<DentalMedical.Model.factory>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DentalMedical.Model.factory model;
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
        public DentalMedical.Model.factory Login_F(string factoryCode, string factoryPwd)
        {
            return dal.Login_F(factoryCode,factoryPwd);
        }

           /// <summary>
        /// 验证密码正确
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DentalMedical.Model.factory judge_pwd(DentalMedical.Model.factory factory, string pwd)
        {
            return dal.judge_pwd(factory,pwd);
        }

          /// <summary>
        /// 更新工厂在线状态
        /// </summary>
        /// <param name="id">工厂Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        public bool update_F_status(Guid id, int status)
        {
            return dal.update_F_status(id, status);
        }


        /// <summary>
        /// 更新工厂名字
        /// </summary>
        /// <param name="id">工厂Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
       public  bool update_F_name(Guid Id, string factoryName)
        {
            return dal.update_F_name(Id,factoryName);
        }
         /// <summary>
        /// 获取当前注册的工厂数量
        /// </summary>
        /// <returns></returns>
       public int get_factory_num()
       {
           return dal.get_factory_num();
       }

         /// <summary>
        /// 工厂端自动登录
        /// </summary>
       public DentalMedical.Model.factory Login_F_Auto(Guid Id)
       {
           return dal.Login_F_Auto(Id);
       }

       /// <summary>
       /// 工厂端的交易记录
       /// </summary>
       /// <param name="factory_Id">工厂Id</param>
       /// <returns></returns>
       public DataTable get_D_F_num(Guid factory_Id)
       {
           return dal.get_D_F_num(factory_Id);
       }

            /// <summary>
        /// 更新
        /// </summary>
        /// <param name="main_person">主要联系人</param>
        /// <param name="main_Email">联系人邮箱</param>
        /// <param name="sex">性别</param>
        /// <param name="logo">公司头像</param>
        /// <param name="id">公司Id</param>
        /// <returns></returns>
       public bool update_setInfo(string main_person, string main_Email, int sex, string logo, Guid id)
       {
           return dal.update_setInfo(main_person,main_Email,sex,logo,id);
       }
		#endregion  ExtensionMethod
	}
}

