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
	/// doctors
	/// </summary>
	public partial class doctors
	{
        private readonly Idoctors dal = DataAccess.Createdoctors();
        public doctors()
        {
            
        }
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
		public bool Exists(string userCode)
		{
			return dal.Exists(userCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(DentalMedical.Model.doctors model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.doctors model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Id,string userCode)
		{
			
			return dal.Delete(Id,userCode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DentalMedical.Model.doctors GetModel(Guid Id,string userCode)
		{
			
			return dal.GetModel(Id,userCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DentalMedical.Model.doctors GetModelByCache(Guid Id,string userCode)
		{
			
			string CacheKey = "doctorsModel-" + Id+userCode;
			object objModel = DentalMedical.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,userCode);
					if (objModel != null)
					{
						int ModelCache = DentalMedical.Common.ConfigHelper.GetConfigInt("ModelCache");
						DentalMedical.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DentalMedical.Model.doctors)objModel;
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
		public List<DentalMedical.Model.doctors> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DentalMedical.Model.doctors> DataTableToList(DataTable dt)
		{
			List<DentalMedical.Model.doctors> modelList = new List<DentalMedical.Model.doctors>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DentalMedical.Model.doctors model;
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
        public DentalMedical.Model.doctors Login_D(string DrCode, string DrPwd)
        {          
            return dal.Query_Code(DrCode, DrPwd);
        }

           /// <summary>
        ///  判断密码是否正确
        /// </summary>
        /// <param name="doctors"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DentalMedical.Model.doctors judge_Pwd(DentalMedical.Model.doctors doctors, string pwd)
        {
            return dal.judge_Pwd(doctors,pwd);
        }
         /// <summary>
        /// 更新医生在线状态
        /// </summary>
        /// <param name="id">医生Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        public bool update_doctor_status(Guid id, int status)
        {
            return dal.update_doctor_status(id,status);
        }

         /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        public bool update_doctor_Info(string Id, string userName, int? sex = null, string email = null, string logo = null, string dId = null, string fCode = null)
        {
            return dal.update_doctor_Info(Id,userName,sex,email,logo,dId,fCode);
        }

           /// <summary>
        /// 输入工厂邀请码
        /// </summary>
        /// <param name="Id">医生Id</param>
        /// <param name="fCode">邀请码</param>
        /// <returns></returns>
        public int update_F_Code(string Id, string fCode)
        {
            return dal.update_F_Code(Id,fCode);
        }

          /// <summary>
        /// 医生端自动登录
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public DentalMedical.Model.doctors login_auto(Guid doctorId)
        {
            return dal.login_auto(doctorId);
        }


           /// <summary>
        /// 授权认证
        /// </summary>
        /// <param name="certId">认证Id</param>
        /// <param name="doctorId">技师Id</param>
        /// <param name="Pid">授权医生Id</param>
        /// <returns></returns>
        public int authorize_technician(Guid certId, Guid doctorId, Guid Pid)
        {
            return dal.authorize_technician(certId,doctorId,Pid);
        }

         /// <summary>
        /// 获取注册医生数量
        /// </summary>
        /// <returns></returns>
        public int get_doctor_num()
        {
            return dal.get_doctor_num();
        }

          /// <summary>
        /// 更新认证授权状态
        /// </summary>
        /// <param name="dcId"></param>
        /// <returns></returns>
        public int update_dcStatus(Guid dcId)
        {
            return dal.update_dcStatus(dcId);
        }

        /// <summary>
        /// 预约专家界面查找医生
        /// </summary>
        /// <param name="codeid">区号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.search_doctor> search_doctor(string codeid)
        {
            return dal.search_doctor(codeid);
        }

        
        /// <summary>
        /// 绑定PID
        /// </summary>
        /// <param name="id">医生Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        public bool update_doctor_weixin(string userCode, string wenxin)
        {
            return dal.update_doctor_weixin(userCode, wenxin);

        }

          /// <summary>
        /// 根据微信获取医生基本信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public DentalMedical.Model.doctors Query_Code_weixin(string openId)
        {
            return dal.Query_Code_weixin(openId);
        }

         /// <summary>
        /// 重置医生密码
        /// </summary>
        /// <param name="usercode">医生账号</param>
        /// <returns></returns>
        public bool reset_pwd(string usercode)
        {
            return dal.reset_pwd(usercode);
        }

         /// <summary>
        /// 修改医生密码
        /// </summary>
        /// <param name="usercode">医生账号</param>
        /// <returns></returns>
        public bool modify_pwd(string usercode, string userpwd)
        {
            return dal.modify_pwd(usercode,userpwd);
        }
		#endregion  ExtensionMethod
	}
}

