using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:sys_logs
	/// </summary>
	public partial class sys_logs:Isys_logs
	{
		public sys_logs()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_logs");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.sys_logs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_logs(");
			strSql.Append("Id,doctor_Id,LogsType,Entity,incident,IP,clientInfo,logmessage,orderId,createDate,createId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@doctor_Id,@LogsType,@Entity,@incident,@IP,@clientInfo,@logmessage,@orderId,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@LogsType", SqlDbType.Int),
					new SqlParameter("@Entity", SqlDbType.VarChar),
					new SqlParameter("@incident", SqlDbType.VarChar),
					new SqlParameter("@IP", SqlDbType.VarChar),
					new SqlParameter("@clientInfo", SqlDbType.VarChar),
					new SqlParameter("@logmessage", SqlDbType.VarChar),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.doctor_Id;
			parameters[2].Value = model.LogsType;
			parameters[3].Value = model.Entity;
			parameters[4].Value = model.incident;
			parameters[5].Value = model.IP;
			parameters[6].Value = model.clientInfo;
			parameters[7].Value = model.logmessage;
			parameters[8].Value = 1;
			parameters[9].Value = model.createId;
			parameters[10].Value = 1;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.sys_logs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_logs set ");
			strSql.Append("doctor_Id=@doctor_Id,");
			strSql.Append("LogsType=@LogsType,");
			strSql.Append("Entity=@Entity,");
			strSql.Append("incident=@incident,");
			strSql.Append("IP=@IP,");
			strSql.Append("clientInfo=@clientInfo,");
			strSql.Append("logmessage=@logmessage,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@LogsType", SqlDbType.Int,4),
					new SqlParameter("@Entity", SqlDbType.VarChar,100),
					new SqlParameter("@incident", SqlDbType.VarChar,255),
					new SqlParameter("@IP", SqlDbType.VarChar,50),
					new SqlParameter("@clientInfo", SqlDbType.VarChar,255),
					new SqlParameter("@logmessage", SqlDbType.VarChar,500),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.doctor_Id;
			parameters[1].Value = model.LogsType;
			parameters[2].Value = model.Entity;
			parameters[3].Value = model.incident;
			parameters[4].Value = model.IP;
			parameters[5].Value = model.clientInfo;
			parameters[6].Value = model.logmessage;
			parameters[7].Value = model.orderId;
			parameters[8].Value = model.createDate;
			parameters[9].Value = model.createId;
			parameters[10].Value = model.modifyDate;
			parameters[11].Value = model.modifyId;
			parameters[12].Value = model.flag;
			parameters[13].Value = model.Id;

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
		public bool Delete(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_logs ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_logs ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public DentalMedical.Model.sys_logs GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,doctor_Id,LogsType,Entity,incident,IP,clientInfo,logmessage,orderId,createDate,createId,modifyDate,modifyId,flag from sys_logs ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.sys_logs model=new DentalMedical.Model.sys_logs();
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
		public DentalMedical.Model.sys_logs DataRowToModel(DataRow row)
		{
			DentalMedical.Model.sys_logs model=new DentalMedical.Model.sys_logs();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["doctor_Id"]!=null && row["doctor_Id"].ToString()!="")
				{
					model.doctor_Id= new Guid(row["doctor_Id"].ToString());
				}
				if(row["LogsType"]!=null && row["LogsType"].ToString()!="")
				{
					model.LogsType=int.Parse(row["LogsType"].ToString());
				}
				if(row["Entity"]!=null)
				{
					model.Entity=row["Entity"].ToString();
				}
				if(row["incident"]!=null)
				{
					model.incident=row["incident"].ToString();
				}
				if(row["IP"]!=null)
				{
					model.IP=row["IP"].ToString();
				}
				if(row["clientInfo"]!=null)
				{
					model.clientInfo=row["clientInfo"].ToString();
				}
				if(row["logmessage"]!=null)
				{
					model.logmessage=row["logmessage"].ToString();
				}
				if(row["orderId"]!=null && row["orderId"].ToString()!="")
				{
					model.orderId=int.Parse(row["orderId"].ToString());
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
			strSql.Append("select Id,doctor_Id,LogsType,Entity,incident,IP,clientInfo,logmessage,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM sys_logs ");
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
			strSql.Append(" Id,doctor_Id,LogsType,Entity,incident,IP,clientInfo,logmessage,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM sys_logs ");
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
			strSql.Append("select count(1) FROM sys_logs ");
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
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from sys_logs T ");
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
			parameters[0].Value = "sys_logs";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

