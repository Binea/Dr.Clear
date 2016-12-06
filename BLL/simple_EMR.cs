using System;
using System.Data;
using System.Collections.Generic;
using DentalMedical.Common;
using DentalMedical.Model;
using DentalMedical.DALFactory;
using DentalMedical.IDAL;
using System.Collections;
namespace DentalMedical.BLL
{
	/// <summary>
	/// simple_EMR
	/// </summary>
	public partial class simple_EMR
	{
		private readonly Isimple_EMR dal=DataAccess.Createsimple_EMR();
		public simple_EMR()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id,string EMR_Code)
		{
			return dal.Exists(Id,EMR_Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.simple_EMR model)
		{
            EMR_stream es = new EMR_stream();
            DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
            emr_stream.message = "病例："+model.EMR_Code+"创建！";
            emr_stream.EMR_Code = model.EMR_Code;
            emr_stream.createId = model.createId;
            es.Add(emr_stream);         
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.simple_EMR model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Id,string EMR_Code)
		{
			
			return dal.Delete(Id,EMR_Code);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DentalMedical.Model.simple_EMR GetModel(Guid Id,string EMR_Code)
		{
			
			return dal.GetModel(Id,EMR_Code);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DentalMedical.Model.simple_EMR GetModelByCache(Guid Id,string EMR_Code)
		{
			
			string CacheKey = "simple_EMRModel-" + Id+EMR_Code;
			object objModel = DentalMedical.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id,EMR_Code);
					if (objModel != null)
					{
						int ModelCache = DentalMedical.Common.ConfigHelper.GetConfigInt("ModelCache");
						DentalMedical.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DentalMedical.Model.simple_EMR)objModel;
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
		public List<DentalMedical.Model.simple_EMR> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DentalMedical.Model.simple_EMR> DataTableToList(DataTable dt)
		{
			List<DentalMedical.Model.simple_EMR> modelList = new List<DentalMedical.Model.simple_EMR>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DentalMedical.Model.simple_EMR model;
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
        /// 根据医生登录的账号，选的执业地，病例状态获取emr列表
        /// </summary>
        /// <param name="dId">医生Id</param>
        /// <param name="hId">医院Id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> EMR_D_list(string dId, string hId, int treatmentStauts)
        {
            //int minStatus=0, maxStatus = 0;
            //if (status.Equals("诊前"))
            //{
            //    minStatus = 0;
            //    maxStatus = 5;
            //}
            //else if (status.Equals("诊中"))
            //{
            //    minStatus = 5;
            //    maxStatus = 11;
            //}
            //else if (status.Equals("诊后"))
            //{
            //    minStatus = 11;
            //    maxStatus = 14;
            //}
            //else if (status.Equals("全部"))
            //{
            //    minStatus = -99;
            //    maxStatus = 100;
            //}
            //else
            //{
            //    return null;
            //}
            return dal.EMR_D_list(dId, hId, treatmentStauts);
        }


          /// <summary>
        /// 根据厂房登录的账号 和状态 获取到病例列表
        /// </summary>
        /// <param name="fId">厂家Id</param>
        /// <param name="Status">状态</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> EMR_F_list(string fId, int emrstatus)
        {
            //int emrstatus = 0;
            //if (Status.Equals("接单"))
            //{
            //    emrstatus = 6;
            //}
            //else if (Status.Equals("生产"))
            //{
            //    emrstatus = 8;
            //}
            //else if (Status.Equals("物流"))
            //{
            //    emrstatus = 9;
            //}
            //else if (Status.Equals("全部"))
            //{
            //    emrstatus = 99;
            //}
            return dal.EMR_F_list(fId,emrstatus);
        }

         /// <summary>
        /// 根据状态不同，更新状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="emrcode">病例号</param>
        /// <param name="Id">用户</param>
        /// <param name="processing_requirement">当为加工的时候，有加工要求</param>
        /// <returns></returns>
        public int update_Emr_Status(int status, string emrcode, string Id, string processing_requirement = null, string treatmentstatus = null)
        {
            int istatus = 0;
            if (status==9)
            {
                istatus = 9;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "已接单！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status==10)
            {
                istatus = 10;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "已排产！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status==11)
            {
                istatus = 11;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "发货！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status==6)
            {
                istatus = 6;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "确认！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status == 13)
            {
                istatus = 13;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "结束！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status==7)
            {
                istatus = 7;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "加工下单！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            //else if (status==13)
            //{
            //    istatus = 13;
            //    EMR_stream es = new EMR_stream();
            //    DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
            //    emr_stream.message = "病例：" + emrcode + "结束！";
            //    emr_stream.EMR_Code = emrcode;
            //    es.Add(emr_stream);
            //}
            //else if (status==11)
            //{
            //    istatus = 11;
            //    EMR_stream es = new EMR_stream();
            //    DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
            //    emr_stream.message = "病例：" + emrcode + "归档！";
            //    emr_stream.EMR_Code = emrcode;
            //    emr_stream.createId = new Guid(Id);
            //    es.Add(emr_stream);
            //}
            else if (status==0)
            {
                istatus = 0;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "重启！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status==1)
            {
                istatus = 1;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "提交模型！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status==2)
            {
                istatus = 2;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "口腔模型完成！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else if (status == 4)
            {
                istatus = 4;
                EMR_stream es = new EMR_stream();
                DentalMedical.Model.EMR_stream emr_stream = new Model.EMR_stream();
                emr_stream.message = "病例：" + emrcode + "设计模型完成！";
                emr_stream.EMR_Code = emrcode;
                emr_stream.createId = new Guid(Id);
                es.Add(emr_stream);
            }
            else
            {
                return -1;
            }
            return dal.update_Emr_Status(istatus, emrcode, Id, processing_requirement);
        }
           /// <summary>
        /// 更新医生随笔
        /// </summary>
        /// <param name="emrCode">病例编号</param>
        /// <param name="remark">医生随笔</param>
        /// <returns></returns>
        public int update_doctorRemark(string emrCode, string remark, string remarkdate, string doctorId)
        {
            return dal.update_doctorRemark(emrCode, remark, remarkdate, doctorId);
        }


         /// <summary>
        /// 根据病例号获取病例信息
        /// </summary>
        /// <param name="emrCode"></param>
        /// <returns></returns>
        public DentalMedical.Model.simple_EMR get_emr_byCode(string emrCode)
        {
            return dal.get_emr_byCode(emrCode);
        }

          /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="emrCode">病例号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.EMR_stream> get_stream(string emrCode)
        {
            return dal.get_stream(emrCode);
        }

          /// <summary>
        /// 根据微信号 获取病人病例列表
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        public List<DentalMedical.Model.WX_simple_emr> Get_list_by_weixin(string weixin)
        {
            return dal.Get_list_by_weixin(weixin);
        }

        /// <summary>
        /// 根据医生登录的账号，选的执业地，病例状态,搜索条件获取emr列表
        /// </summary>
        /// <param name="dId">医生Id</param>
        /// <param name="hId">医院Id</param>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <param name="strwhere">搜索条件</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> find_Emr_d(string dId, string hId, int treatmentstatus, string strwhere)
        {
            //int minStatus = 0, maxStatus = 0;
            //if (status.Equals("诊前"))
            //{
            //    minStatus = 0;
            //    maxStatus = 4;
            //}
            //else if (status.Equals("诊中"))
            //{
            //    minStatus = 5;
            //    maxStatus = 10;
            //}
            //else if (status.Equals("诊后"))
            //{
            //    minStatus = 11;
            //    maxStatus = 12;
            //}
            //else if (status.Equals("全部"))
            //{
            //    minStatus = -99;
            //    maxStatus = 100;
            //}
            //else
            //{
            //    return null;
            //}
            return dal.find_Emr_d(dId, hId, treatmentstatus, strwhere);
        }

        
         /// <summary>
         /// 根据工厂登录的账号，病例状态,搜索条件获取emr列表
         /// </summary>
         /// <param name="fId">工厂Id</param>
         /// <param name="status">状态</param>
         /// <param name="strwhere">条件</param>
         /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> find_Emr_f(string fId, int Status, string strwhere)
        {
            //int emrstatus = 0;
            //if (Status.Equals("接单"))
            //{
            //    emrstatus = 6;
            //}
            //else if (Status.Equals("生产"))
            //{
            //    emrstatus = 8;
            //}
            //else if (Status.Equals("物流"))
            //{
            //    emrstatus = 9;
            //}
            //else if (Status.Equals("全部"))
            //{
            //    emrstatus = 99;
            //}
            return dal.find_Emr_f(fId, Status, strwhere);
        }

           /// <summary>
        /// 判断模型文件是否有更新
        /// </summary>
        /// <param name="EMR_Code"></param>
        /// <param name="fileId"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        public bool isChangeFile(string EMR_Code, string fileId, int filetype)
        {
            return dal.isChangeFile(EMR_Code,fileId,filetype);
        }


           /// <summary>
        /// 获取病人病例
        /// </summary>
        /// <param name="tel">电话号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> get_emrCode(string tel)
        {
            return dal.get_emrCode(tel);
        }

        
        /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="tel">电话号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.EMR_stream> get_stream_byTel(string tel)
        {
            return dal.get_stream_byTel(tel);
        }

           /// <summary>
        /// 增加一条数据
        /// </summary>
        public Hashtable Add_hash(DentalMedical.Model.simple_EMR model)
        {
            return dal.Add_hash(model);
        }

        
        /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="openId">微信openId</param>
        /// <returns></returns>
        public List<DentalMedical.Model.EMR_stream> get_stream_byWeixin(string openId)
        {
            return dal.get_stream_byWeixin(openId);

        }

        
        /// <summary>
        /// 事务提交新增病例
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="emrCode"></param>
        /// <returns></returns>
        public DentalMedical.Model.simple_EMR simple_add_hash(Hashtable ht, string emrCode)
        {           
            return dal.simple_add_hash(ht,emrCode);
        }


           /// <summary>
        /// 设计者的账号，根据当前状态的搜索条件获取emr列表
        /// </summary>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <param name="strwhere">搜索条件</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> find_Emr_design(int treatmentstatus, string strwhere)
        {
            return dal.find_Emr_design(treatmentstatus, strwhere);
        }

        
        /// <summary>
        /// 根据设计者登录的账号，病例状态获取emr列表
        /// </summary>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> EMR_design_list( int treatmentstatus)
        {
            return dal.EMR_design_list(treatmentstatus);
        }

        /// <summary>
        /// 更新就诊状态
        /// </summary>
        /// <param name="traatment"></param>
        /// <param name="EMR_Code"></param>
        /// <returns></returns>
        public int update_treatmentstatus(int traatment, string EMR_Code)
        {
            return dal.update_treatmentstatus(traatment,EMR_Code);
        }
		#endregion  ExtensionMethod
	}
}

