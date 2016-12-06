using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:invoice_open
	/// </summary>
	public partial class invoice_open:Iinvoice_open
	{
		public invoice_open()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from invoice_open");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.invoice_open model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into invoice_open(");
			strSql.Append("Id,factoryId,invoice_title,invoice_openType,invoice_type,isdefault,orderId,createDate,createId,modifyDate,modifyId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@factoryId,@invoice_title,@invoice_openType,@invoice_type,@isdefault,@orderId,@createDate,@createId,@modifyDate,@modifyId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@factoryId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@invoice_title", SqlDbType.VarChar,50),
					new SqlParameter("@invoice_openType", SqlDbType.VarChar,20),
					new SqlParameter("@invoice_type", SqlDbType.VarChar,20),
					new SqlParameter("@isdefault", SqlDbType.Bit,1),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.invoice_title;
			parameters[3].Value = model.invoice_openType;
			parameters[4].Value = model.invoice_type;
			parameters[5].Value = model.isdefault;
			parameters[6].Value = model.orderId;
			parameters[7].Value = model.createDate;
			parameters[8].Value = Guid.NewGuid();
			parameters[9].Value = model.modifyDate;
			parameters[10].Value = Guid.NewGuid();
			parameters[11].Value = model.flag;

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
		public bool Update(DentalMedical.Model.invoice_open model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update invoice_open set ");
			strSql.Append("factoryId=@factoryId,");
			strSql.Append("invoice_title=@invoice_title,");
			strSql.Append("invoice_openType=@invoice_openType,");
			strSql.Append("invoice_type=@invoice_type,");
			strSql.Append("isdefault=@isdefault,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@factoryId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@invoice_title", SqlDbType.VarChar,50),
					new SqlParameter("@invoice_openType", SqlDbType.VarChar,20),
					new SqlParameter("@invoice_type", SqlDbType.VarChar,20),
					new SqlParameter("@isdefault", SqlDbType.Bit,1),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.factoryId;
			parameters[1].Value = model.invoice_title;
			parameters[2].Value = model.invoice_openType;
			parameters[3].Value = model.invoice_type;
			parameters[4].Value = model.isdefault;
			parameters[5].Value = model.orderId;
			parameters[6].Value = model.createDate;
			parameters[7].Value = model.createId;
			parameters[8].Value = model.modifyDate;
			parameters[9].Value = model.modifyId;
			parameters[10].Value = model.flag;
			parameters[11].Value = model.Id;

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
			strSql.Append("delete from invoice_open ");
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
			strSql.Append("delete from invoice_open ");
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
		public DentalMedical.Model.invoice_open GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,factoryId,invoice_title,invoice_openType,invoice_type,isdefault,orderId,createDate,createId,modifyDate,modifyId,flag from invoice_open ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.invoice_open model=new DentalMedical.Model.invoice_open();
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
		public DentalMedical.Model.invoice_open DataRowToModel(DataRow row)
		{
			DentalMedical.Model.invoice_open model=new DentalMedical.Model.invoice_open();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["factoryId"]!=null && row["factoryId"].ToString()!="")
				{
					model.factoryId= new Guid(row["factoryId"].ToString());
				}
				if(row["invoice_title"]!=null)
				{
					model.invoice_title=row["invoice_title"].ToString();
				}
				if(row["invoice_openType"]!=null)
				{
					model.invoice_openType=row["invoice_openType"].ToString();
				}
				if(row["invoice_type"]!=null)
				{
					model.invoice_type=row["invoice_type"].ToString();
				}
				if(row["isdefault"]!=null && row["isdefault"].ToString()!="")
				{
					if((row["isdefault"].ToString()=="1")||(row["isdefault"].ToString().ToLower()=="true"))
					{
						model.isdefault=true;
					}
					else
					{
						model.isdefault=false;
					}
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
			strSql.Append("select Id,factoryId,invoice_title,invoice_openType,invoice_type,isdefault,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM invoice_open ");
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
			strSql.Append(" Id,factoryId,invoice_title,invoice_openType,invoice_type,isdefault,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM invoice_open ");
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
			strSql.Append("select count(1) FROM invoice_open ");
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
			strSql.Append(")AS Row, T.*  from invoice_open T ");
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
			parameters[0].Value = "invoice_open";
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

