using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;
using System.Collections.Generic;//Please add references
using DentalMedical.Common;
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:hospitals
	/// </summary>
	public partial class hospitals:Ihospitals
	{
		public hospitals()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from hospitals");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.hospitals model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into hospitals(");
			strSql.Append("Id,hospitalName,hospitalEName,hospitalCode,hospitalAddress,hospitalTel,hospitalWeb,hospitalIntroduction,orderId,createDate,createId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@hospitalName,@hospitalEName,@hospitalCode,@hospitalAddress,@hospitalTel,@hospitalWeb,@hospitalIntroduction,@orderId,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@hospitalName", SqlDbType.VarChar),
					new SqlParameter("@hospitalEName", SqlDbType.VarChar),
					new SqlParameter("@hospitalCode", SqlDbType.VarChar),
					new SqlParameter("@hospitalAddress", SqlDbType.VarChar),
					new SqlParameter("@hospitalTel", SqlDbType.VarChar),
					new SqlParameter("@hospitalWeb", SqlDbType.VarChar),
					new SqlParameter("@hospitalIntroduction", SqlDbType.VarChar),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.hospitalName;
			parameters[2].Value = model.hospitalEName;
			parameters[3].Value = model.hospitalCode;
			parameters[4].Value = model.hospitalAddress;
			parameters[5].Value = model.hospitalTel;
			parameters[6].Value = model.hospitalWeb;
			parameters[7].Value = model.hospitalIntroduction;
			parameters[8].Value = model.orderId;
			parameters[9].Value = model.createDate;
			parameters[10].Value =model.createId;
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
		public bool Update(DentalMedical.Model.hospitals model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update hospitals set ");
			strSql.Append("hospitalName=@hospitalName,");
			strSql.Append("hospitalEName=@hospitalEName,");
			strSql.Append("hospitalCode=@hospitalCode,");
			strSql.Append("hospitalAddress=@hospitalAddress,");
			strSql.Append("hospitalTel=@hospitalTel,");
			strSql.Append("hospitalWeb=@hospitalWeb,");
			strSql.Append("hospitalIntroduction=@hospitalIntroduction,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@hospitalName", SqlDbType.VarChar,50),
					new SqlParameter("@hospitalEName", SqlDbType.VarChar,50),
					new SqlParameter("@hospitalCode", SqlDbType.VarChar,50),
					new SqlParameter("@hospitalAddress", SqlDbType.VarChar,500),
					new SqlParameter("@hospitalTel", SqlDbType.VarChar,20),
					new SqlParameter("@hospitalWeb", SqlDbType.VarChar,50),
					new SqlParameter("@hospitalIntroduction", SqlDbType.VarChar,-1),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.hospitalName;
			parameters[1].Value = model.hospitalEName;
			parameters[2].Value = model.hospitalCode;
			parameters[3].Value = model.hospitalAddress;
			parameters[4].Value = model.hospitalTel;
			parameters[5].Value = model.hospitalWeb;
			parameters[6].Value = model.hospitalIntroduction;
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
			strSql.Append("delete from hospitals ");
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
			strSql.Append("delete from hospitals ");
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
		public DentalMedical.Model.hospitals GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,hospitalName,hospitalEName,hospitalCode,hospitalAddress,hospitalTel,hospitalWeb,hospitalIntroduction,orderId,createDate,createId,modifyDate,modifyId,flag from hospitals ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.hospitals model=new DentalMedical.Model.hospitals();
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
		public DentalMedical.Model.hospitals DataRowToModel(DataRow row)
		{
			DentalMedical.Model.hospitals model=new DentalMedical.Model.hospitals();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["hospitalName"]!=null)
				{
					model.hospitalName=row["hospitalName"].ToString();
				}
				if(row["hospitalEName"]!=null)
				{
					model.hospitalEName=row["hospitalEName"].ToString();
				}
				if(row["hospitalCode"]!=null)
				{
					model.hospitalCode=row["hospitalCode"].ToString();
				}
				if(row["hospitalAddress"]!=null)
				{
					model.hospitalAddress=row["hospitalAddress"].ToString();
				}
				if(row["hospitalTel"]!=null)
				{
					model.hospitalTel=row["hospitalTel"].ToString();
				}
				if(row["hospitalWeb"]!=null)
				{
					model.hospitalWeb=row["hospitalWeb"].ToString();
				}
				if(row["hospitalIntroduction"]!=null)
				{
					model.hospitalIntroduction=row["hospitalIntroduction"].ToString();
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
			strSql.Append("select Id,hospitalName,hospitalEName,hospitalCode,hospitalAddress,hospitalTel,hospitalWeb,hospitalIntroduction,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM hospitals ");
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
			strSql.Append(" Id,hospitalName,hospitalEName,hospitalCode,hospitalAddress,hospitalTel,hospitalWeb,hospitalIntroduction,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM hospitals ");
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
			strSql.Append("select count(1) FROM hospitals ");
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
			strSql.Append(")AS Row, T.*  from hospitals T ");
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
			parameters[0].Value = "hospitals";
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
        /// <summary>
        /// 通过区域码获取到该区域内的医生
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<DentalMedical.Model.hospitals> gethospital_code(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    dbo.hospitals
                            WHERE   hospitalCode = @code");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.VarChar)			};
            parameters[0].Value = code;

            DentalMedical.Model.hospitals model = new DentalMedical.Model.hospitals();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<DentalMedical.Model.hospitals> lh = new List<DentalMedical.Model.hospitals>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lh = DataTableList.ToList<DentalMedical.Model.hospitals>(ds.Tables[0]);
                return lh;
            }
            else
            {
                return null;
            }
        }
		#endregion  ExtensionMethod
	}
}

