using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
using DentalMedical.Common;
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:factory
	/// </summary>
	public partial class factory:Ifactory
	{
		public factory()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("factoryCode", "factory"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string factoryCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from factory");
			strSql.Append(" where factoryCode=@factoryCode ");
			SqlParameter[] parameters = {					
					new SqlParameter("@factoryCode", SqlDbType.VarChar)			};
			parameters[0].Value = factoryCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据，注册
		/// </summary>
		public string Add(DentalMedical.Model.factory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into factory(");
            strSql.Append("Id,factoryCode,factoryTel,factoryPwd,factoryKey,invit_code,orderId,createDate,createId,flag)");
			strSql.Append(" values (");
            strSql.Append("@Id,@factoryCode,@factoryTel,@factoryPwd,@factoryKey,@invit_code,@orderId,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@factoryCode", SqlDbType.VarChar),
					new SqlParameter("@factoryTel", SqlDbType.VarChar),
					new SqlParameter("@factoryPwd", SqlDbType.VarChar),
					new SqlParameter("@factoryKey", SqlDbType.Int),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),                  
					new SqlParameter("@flag", SqlDbType.Int),  new SqlParameter("@invit_code", SqlDbType.VarChar)};
            Guid id = Guid.NewGuid();
			parameters[0].Value = id;
			parameters[1].Value = model.factoryCode;
			parameters[2].Value = model.factoryTel;
            parameters[3].Value = DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(model.factoryPwd);
			parameters[4].Value = model.factoryKey;
			parameters[5].Value = 1;
			parameters[6].Value = id;
			parameters[7].Value = 1;
            parameters[8].Value = model.invit_code;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
                return id.ToString();
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.factory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update factory set ");
			strSql.Append("factoryTel=@factoryTel,");
			strSql.Append("factoryPwd=@factoryPwd,");
			strSql.Append("factoryEmail=@factoryEmail,");
			strSql.Append("factoryKey=@factoryKey,");
			strSql.Append("factoryLogo=@factoryLogo,");
			strSql.Append("onlineStatus=@onlineStatus,");
			strSql.Append("factoryName=@factoryName,");
			strSql.Append("fee=@fee,");
			strSql.Append("invit_code=@invit_code,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("factoryRemark=@factoryRemark,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id and factoryCode=@factoryCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@factoryTel", SqlDbType.VarChar,20),
					new SqlParameter("@factoryPwd", SqlDbType.VarChar,20),
					new SqlParameter("@factoryEmail", SqlDbType.VarChar,50),
					new SqlParameter("@factoryKey", SqlDbType.Int,4),
					new SqlParameter("@factoryLogo", SqlDbType.VarChar,-1),
					new SqlParameter("@onlineStatus", SqlDbType.Int,4),
					new SqlParameter("@factoryName", SqlDbType.VarChar,50),
					new SqlParameter("@fee", SqlDbType.Decimal,9),
					new SqlParameter("@invit_code", SqlDbType.VarChar,6),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@factoryRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@factoryCode", SqlDbType.VarChar)};
			parameters[0].Value = model.factoryTel;
			parameters[1].Value = model.factoryPwd;
			parameters[2].Value = model.factoryEmail;
			parameters[3].Value = model.factoryKey;
			parameters[4].Value = model.factoryLogo;
			parameters[5].Value = model.onlineStatus;
			parameters[6].Value = model.factoryName;
			parameters[7].Value = model.fee;
			parameters[8].Value = model.invit_code;
			parameters[9].Value = model.orderId;
			parameters[10].Value = model.factoryRemark;
			parameters[11].Value = model.createDate;
			parameters[12].Value = model.createId;
			parameters[13].Value = model.modifyDate;
			parameters[14].Value = model.modifyId;
			parameters[15].Value = model.flag;
			parameters[16].Value = model.Id;
			parameters[17].Value = model.factoryCode;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid Id,string factoryCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from factory ");
			strSql.Append(" where Id=@Id and factoryCode=@factoryCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@factoryCode", SqlDbType.VarChar)			};
			parameters[0].Value = Id;
			parameters[1].Value = factoryCode;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DentalMedical.Model.factory GetModel(Guid Id,string factoryCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,factoryCode,factoryTel,factoryPwd,factoryEmail,factoryKey,factoryLogo,onlineStatus,factoryName,fee,invit_code,orderId,factoryRemark,createDate,createId,modifyDate,modifyId,flag from factory ");
			strSql.Append(" where Id=@Id and factoryCode=@factoryCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@factoryCode", SqlDbType.VarChar)			};
			parameters[0].Value = Id;
			parameters[1].Value = factoryCode;

			DentalMedical.Model.factory model=new DentalMedical.Model.factory();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DentalMedical.Model.factory DataRowToModel(DataRow row)
		{
			DentalMedical.Model.factory model=new DentalMedical.Model.factory();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["factoryCode"]!=null && row["factoryCode"].ToString()!="")
				{
					model.factoryCode=row["factoryCode"].ToString();
				}
				if(row["factoryTel"]!=null)
				{
					model.factoryTel=row["factoryTel"].ToString();
				}
				if(row["factoryPwd"]!=null)
				{
					model.factoryPwd=row["factoryPwd"].ToString();
				}
				if(row["factoryEmail"]!=null)
				{
					model.factoryEmail=row["factoryEmail"].ToString();
				}
				if(row["factoryKey"]!=null && row["factoryKey"].ToString()!="")
				{
					model.factoryKey=int.Parse(row["factoryKey"].ToString());
				}
				if(row["factoryLogo"]!=null)
				{
					model.factoryLogo=row["factoryLogo"].ToString();
				}
				if(row["onlineStatus"]!=null && row["onlineStatus"].ToString()!="")
				{
					model.onlineStatus=int.Parse(row["onlineStatus"].ToString());
				}
				if(row["factoryName"]!=null)
				{
					model.factoryName=row["factoryName"].ToString();
				}
				if(row["fee"]!=null && row["fee"].ToString()!="")
				{
					model.fee=decimal.Parse(row["fee"].ToString());
				}
				if(row["invit_code"]!=null)
				{
					model.invit_code=row["invit_code"].ToString();
				}
				if(row["orderId"]!=null && row["orderId"].ToString()!="")
				{
					model.orderId=int.Parse(row["orderId"].ToString());
				}
				if(row["factoryRemark"]!=null)
				{
					model.factoryRemark=row["factoryRemark"].ToString();
				}
				if(row["createDate"]!=null && row["createDate"].ToString()!="")
				{
					model.createDate=DateTime.Parse(row["createDate"].ToString());
				}
				if(row["createId"]!=null && row["createId"].ToString()!="")
				{
					model.createId= new Guid(row["createId"].ToString());
				}
				if(row["modifyDate"]!=null && row["modifyDate"].ToString()!="")
				{
					model.modifyDate=DateTime.Parse(row["modifyDate"].ToString());
				}
				if(row["modifyId"]!=null && row["modifyId"].ToString()!="")
				{
					model.modifyId= new Guid(row["modifyId"].ToString());
				}
				if(row["flag"]!=null && row["flag"].ToString()!="")
				{
					model.flag=int.Parse(row["flag"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,factoryCode,factoryTel,factoryPwd,factoryEmail,factoryKey,factoryLogo,onlineStatus,factoryName,fee,invit_code,orderId,factoryRemark,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM factory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,factoryCode,factoryTel,factoryPwd,factoryEmail,factoryKey,factoryLogo,onlineStatus,factoryName,fee,invit_code,orderId,factoryRemark,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM factory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM factory ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.factoryCode desc");
			}
			strSql.Append(")AS Row, T.*  from factory T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "factory";
			parameters[1].Value = "factoryCode";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod

		#region  ExtensionMethod
        /// <summary>
        /// 工厂端登录
        /// </summary>
        public DentalMedical.Model.factory Login_F(string factoryCode,string factoryPwd)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,factoryCode,factoryTel,factoryPwd,factoryEmail,factoryKey,factoryLogo,onlineStatus,factoryName,fee,invit_code,orderId,factoryRemark,createDate,createId,modifyDate,modifyId,flag from factory ");
            strSql.Append(" where factoryCode=@factoryCode and flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@factoryCode", SqlDbType.VarChar)			};
            parameters[0].Value = factoryCode;
            DentalMedical.Model.factory model = new DentalMedical.Model.factory();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 工厂端自动登录
        /// </summary>
        public DentalMedical.Model.factory Login_F_Auto(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,factoryCode,factoryTel,factoryPwd,factoryEmail,factoryKey,factoryLogo,onlineStatus,factoryName,fee,invit_code,orderId,factoryRemark,createDate,createId,modifyDate,modifyId,flag from factory ");
            strSql.Append(" where Id=@Id and flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier)			};
            parameters[0].Value = Id;
            DentalMedical.Model.factory model = new DentalMedical.Model.factory();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append(@"SELECT *
                              FROM [dbo].[factory_certification]");
                strSql2.Append("  WHERE flag=1 and factory_Id=@factory_Id and flag=1");
                SqlParameter[] parameters2 = {
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier)			};
                parameters2[0].Value = model.Id;
                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    model.certification = DataTableList.ToList<DentalMedical.Model.factory_certification>(ds2.Tables[0]);
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 验证密码正确
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DentalMedical.Model.factory judge_pwd(DentalMedical.Model.factory factory ,string pwd)
        {
            if (DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(pwd).Equals(factory.factoryPwd))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append(@"SELECT *
                              FROM [dbo].[factory_certification]");
                strSql2.Append("  WHERE flag=1 and factory_Id=@factory_Id and flag=1");
                SqlParameter[] parameters2 = {
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier)			};
                parameters2[0].Value = factory.Id;
                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    factory.certification = DataTableList.ToList<DentalMedical.Model.factory_certification>(ds2.Tables[0]);
                }
                return factory;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新工厂在线状态
        /// </summary>
        /// <param name="id">工厂Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        public bool update_F_status(Guid id, int status)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE dbo.factory SET onlineStatus=@status WHERE Id=@Id and flag=1");
            SqlParameter[] parameters ={
                                   new SqlParameter("@Id", SqlDbType.UniqueIdentifier),		
                                       new SqlParameter("@status", SqlDbType.Int)		};
            parameters[0].Value = id;
            parameters[1].Value = status;
            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// 更新工厂名字
        /// </summary>
        /// <param name="id">工厂Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        public bool update_F_name(Guid Id, string factoryName)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE dbo.factory SET factoryName=@factoryName WHERE Id=@Id and flag=1");
            SqlParameter[] parameters ={
                                   new SqlParameter("@Id", SqlDbType.UniqueIdentifier),		
                                       new SqlParameter("@factoryName", SqlDbType.VarChar)		};
            parameters[0].Value = Id;
            parameters[1].Value = factoryName;
            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// 获取当前注册的工厂数量
        /// </summary>
        /// <returns></returns>
        public int get_factory_num()
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(*) * 100+1 FROM    dbo.factory where  flag=1");
            result = (int)DbHelperSQL.GetSingle(strSql.ToString());
            return result;
        }

        /// <summary>
        /// 工厂端的交易记录
        /// </summary>
        /// <param name="factory_Id">工厂Id</param>
        /// <returns></returns>
        public DataTable get_D_F_num(Guid factory_Id)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT userRealName, COUNT(FD_relation.doctor_Id) AS num FROM dbo.FD_relation
LEFT JOIN dbo.HDE_relation ON HDE_relation.doctor_Id = FD_relation.doctor_Id AND HDE_relation.flag =1
LEFT JOIN dbo.doctors ON doctors.Id = HDE_relation.doctor_Id
 WHERE  factory_Id=@factory_Id AND FD_relation.flag=1
 GROUP BY FD_relation.doctor_Id,userRealName
 ORDER BY num");
            SqlParameter[] parameters2 = {
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier)			};
            parameters2[0].Value = factory_Id;
            DataSet ds2 = DbHelperSQL.Query(strSql.ToString(), parameters2);
            if (ds2.Tables[0].Rows.Count > 0)
                return ds2.Tables[0];
            else return null;
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
        public bool update_setInfo(string main_person,string main_Email,int sex,string logo,Guid id)
        {
            StringBuilder strSql = new StringBuilder();
            if (logo != null && logo != "")
            {
                strSql.Append("UPDATE dbo.factory SET factoryLogo=@factoryLogo WHERE Id=@Id and flag=1");
             
                SqlParameter[] parameters ={
                                   new SqlParameter("@Id", SqlDbType.UniqueIdentifier),		
                                       new SqlParameter("@factoryLogo", SqlDbType.VarChar)		};
                parameters[0].Value = id;
                parameters[1].Value = logo;
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);               
            }
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(@"UPDATE  dbo.factory_certification
SET     main_Person = @main_Person ,
        main_Sex = @main_Sex ,
        main_Email = @main_Email
WHERE   factory_Id = @factory_Id and flag=1");
            SqlParameter[] parameters2 ={
                                   new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier),		
                                       new SqlParameter("@main_Person", SqlDbType.VarChar)	,		
                                       new SqlParameter("@main_Sex", SqlDbType.Int),		
                                       new SqlParameter("@main_Email", SqlDbType.VarChar)	};
            parameters2[0].Value = id;
            parameters2[1].Value = main_person;
            parameters2[2].Value = sex;
            parameters2[3].Value = main_Email;
            int rows2 = DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters2);
            if (rows2 > 0)
                return true;
            else return false;
        }
		#endregion  ExtensionMethod
	}
}

