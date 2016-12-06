using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:PI_relation
	/// </summary>
	public partial class PI_relation:IPI_relation
	{
		public PI_relation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PI_relation");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.PI_relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PI_relation(");
			strSql.Append("Id,paymentId,invoiceId,orderId,createDate,createId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@paymentId,@invoiceId,@orderId,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@paymentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@invoiceId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value =model.paymentId;
			parameters[2].Value = model.invoiceId;
			parameters[4].Value = 1;
			parameters[6].Value = model.createId;
			parameters[9].Value =1;
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
		public bool Update(DentalMedical.Model.PI_relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PI_relation set ");
			strSql.Append("paymentId=@paymentId,");
			strSql.Append("invoiceId=@invoiceId,");
			strSql.Append("cRemark=@cRemark,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@paymentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@invoiceId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cRemark", SqlDbType.VarChar,500),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.paymentId;
			parameters[1].Value = model.invoiceId;
			parameters[2].Value = model.cRemark;
			parameters[3].Value = model.orderId;
			parameters[4].Value = model.createDate;
			parameters[5].Value = model.createId;
			parameters[6].Value = model.modifyDate;
			parameters[7].Value = model.modifyId;
			parameters[8].Value = model.flag;
			parameters[9].Value = model.Id;

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
			strSql.Append("delete from PI_relation ");
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
			strSql.Append("delete from PI_relation ");
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
		public DentalMedical.Model.PI_relation GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,paymentId,invoiceId,cRemark,orderId,createDate,createId,modifyDate,modifyId,flag from PI_relation ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.PI_relation model=new DentalMedical.Model.PI_relation();
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
		public DentalMedical.Model.PI_relation DataRowToModel(DataRow row)
		{
			DentalMedical.Model.PI_relation model=new DentalMedical.Model.PI_relation();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["paymentId"]!=null && row["paymentId"].ToString()!="")
				{
					model.paymentId= new Guid(row["paymentId"].ToString());
				}
				if(row["invoiceId"]!=null && row["invoiceId"].ToString()!="")
				{
					model.invoiceId= new Guid(row["invoiceId"].ToString());
				}
				if(row["cRemark"]!=null)
				{
					model.cRemark=row["cRemark"].ToString();
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
			strSql.Append("select Id,paymentId,invoiceId,cRemark,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM PI_relation ");
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
			strSql.Append(" Id,paymentId,invoiceId,cRemark,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM PI_relation ");
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
			strSql.Append("select count(1) FROM PI_relation ");
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
			strSql.Append(")AS Row, T.*  from PI_relation T ");
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
			parameters[0].Value = "PI_relation";
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

