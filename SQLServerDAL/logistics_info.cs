using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:logistics_info
	/// </summary>
	public partial class logistics_info:Ilogistics_info
	{
		public logistics_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from logistics_info");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 厂家发货，增加一条物流信息
		/// </summary>
		public bool Add(DentalMedical.Model.logistics_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into logistics_info(");
			strSql.Append("Id,factory_Id,EMR_Code,dsId,expressName,express_billCode,cRemark,orderId,createDate,createId,flag)");
			strSql.Append(" values (");
            strSql.Append("@Id,@factory_Id,@EMR_Code,@dsId,@expressName,@express_billCode,@cRemark,@orderId,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25),
					new SqlParameter("@dsId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@expressName", SqlDbType.VarChar,25),
					new SqlParameter("@express_billCode", SqlDbType.VarChar,25),
					new SqlParameter("@cRemark", SqlDbType.VarChar,500),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int)};
            Guid id = Guid.NewGuid();
			parameters[0].Value = id;
			parameters[1].Value = model.factory_Id;
			parameters[2].Value = model.EMR_Code;
            parameters[3].Value = model.dsId;
			parameters[4].Value = model.expressName;
			parameters[5].Value = model.express_billCode;
			parameters[6].Value = model.cRemark;
			parameters[7].Value = 1;
            parameters[8].Value = model.createId;
			parameters[9].Value = 1;

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
		public bool Update(DentalMedical.Model.logistics_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update logistics_info set ");
			strSql.Append("factory_Id=@factory_Id,");
			strSql.Append("EMR_Code=@EMR_Code,");
			strSql.Append("dsId=@dsId,");
			strSql.Append("expressName=@expressName,");
			strSql.Append("express_billCode=@express_billCode,");
			strSql.Append("cRemark=@cRemark,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25),
					new SqlParameter("@dsId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@expressName", SqlDbType.VarChar,25),
					new SqlParameter("@express_billCode", SqlDbType.VarChar,25),
					new SqlParameter("@cRemark", SqlDbType.VarChar,500),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.factory_Id;
			parameters[1].Value = model.EMR_Code;
			parameters[2].Value = model.dsId;
			parameters[3].Value = model.expressName;
			parameters[4].Value = model.express_billCode;
			parameters[5].Value = model.cRemark;
			parameters[6].Value = model.orderId;
			parameters[7].Value = model.createDate;
			parameters[8].Value = model.createId;
			parameters[9].Value = model.modifyDate;
			parameters[10].Value = model.modifyId;
			parameters[11].Value = model.flag;
			parameters[12].Value = model.Id;

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
			strSql.Append("delete from logistics_info ");
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
			strSql.Append("delete from logistics_info ");
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
		public DentalMedical.Model.logistics_info GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,factory_Id,EMR_Code,dsId,expressName,express_billCode,cRemark,orderId,createDate,createId,modifyDate,modifyId,flag from logistics_info ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.logistics_info model=new DentalMedical.Model.logistics_info();
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
		public DentalMedical.Model.logistics_info DataRowToModel(DataRow row)
		{
			DentalMedical.Model.logistics_info model=new DentalMedical.Model.logistics_info();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["factory_Id"]!=null && row["factory_Id"].ToString()!="")
				{
					model.factory_Id= new Guid(row["factory_Id"].ToString());
				}
				if(row["EMR_Code"]!=null)
				{
					model.EMR_Code=row["EMR_Code"].ToString();
				}
				if(row["dsId"]!=null && row["dsId"].ToString()!="")
				{
					model.dsId= new Guid(row["dsId"].ToString());
				}
				if(row["expressName"]!=null)
				{
					model.expressName=row["expressName"].ToString();
				}
				if(row["express_billCode"]!=null)
				{
					model.express_billCode=row["express_billCode"].ToString();
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
			strSql.Append("select Id,factory_Id,EMR_Code,dsId,expressName,express_billCode,cRemark,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM logistics_info ");
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
			strSql.Append(" Id,factory_Id,EMR_Code,dsId,expressName,express_billCode,cRemark,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM logistics_info ");
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
			strSql.Append("select count(1) FROM logistics_info ");
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
			strSql.Append(")AS Row, T.*  from logistics_info T ");
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
			parameters[0].Value = "logistics_info";
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

