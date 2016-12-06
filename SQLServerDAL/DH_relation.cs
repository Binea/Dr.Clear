using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;
using System.Collections.Generic;//Please add references
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:DH_relation
	/// </summary>
	public partial class DH_relation:IDH_relation
	{
		public DH_relation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DH_relation");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.DH_relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DH_relation(");
			strSql.Append("Id,hospital_Id,department_Id,orderId,cRemark,createDate,createId,modifyDate,modifyId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@hospital_Id,@department_Id,@orderId,@cRemark,@createDate,@createId,@modifyDate,@modifyId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@hospital_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@department_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@cRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = Guid.NewGuid();
			parameters[3].Value = model.orderId;
			parameters[4].Value = model.cRemark;
			parameters[5].Value = model.createDate;
			parameters[6].Value = Guid.NewGuid();
			parameters[7].Value = model.modifyDate;
			parameters[8].Value = Guid.NewGuid();
			parameters[9].Value = model.flag;

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
		public bool Update(DentalMedical.Model.DH_relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DH_relation set ");
			strSql.Append("hospital_Id=@hospital_Id,");
			strSql.Append("department_Id=@department_Id,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("cRemark=@cRemark,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@hospital_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@department_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@cRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.hospital_Id;
			parameters[1].Value = model.department_Id;
			parameters[2].Value = model.orderId;
			parameters[3].Value = model.cRemark;
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
			strSql.Append("delete from DH_relation ");
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
			strSql.Append("delete from DH_relation ");
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
		public DentalMedical.Model.DH_relation GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,hospital_Id,department_Id,orderId,cRemark,createDate,createId,modifyDate,modifyId,flag from DH_relation ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.DH_relation model=new DentalMedical.Model.DH_relation();
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
		public DentalMedical.Model.DH_relation DataRowToModel(DataRow row)
		{
			DentalMedical.Model.DH_relation model=new DentalMedical.Model.DH_relation();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["hospital_Id"]!=null && row["hospital_Id"].ToString()!="")
				{
					model.hospital_Id= new Guid(row["hospital_Id"].ToString());
				}
				if(row["department_Id"]!=null && row["department_Id"].ToString()!="")
				{
					model.department_Id= new Guid(row["department_Id"].ToString());
				}
				if(row["orderId"]!=null && row["orderId"].ToString()!="")
				{
					model.orderId=int.Parse(row["orderId"].ToString());
				}
				if(row["cRemark"]!=null)
				{
					model.cRemark=row["cRemark"].ToString();
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
			strSql.Append("select Id,hospital_Id,department_Id,orderId,cRemark,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM DH_relation ");
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
			strSql.Append(" Id,hospital_Id,department_Id,orderId,cRemark,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM DH_relation ");
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
			strSql.Append("select count(1) FROM DH_relation ");
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
			strSql.Append(")AS Row, T.*  from DH_relation T ");
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
			parameters[0].Value = "DH_relation";
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
        /// 获取医院科室列表
        /// </summary>
        /// <param name="cityCode">若提供城市编号则筛选该城市下的医院科室</param>
        /// <returns></returns>
        public List<DentalMedical.Model.DH_relation> Get_HDList(string cityCode=null)
        {
            string strsql = @"select dh.id,dh.hospital_Id,h.hospitalName,dh.department_Id,d.deName,h.hospitalCode from DH_relation dh
                                left join hospitals h on dh.hospital_Id=h.Id and h.flag=1
                                left join departments d on dh.department_Id=d.Id and d.flag=1
                                where dh.flag=1 ";
           
            if (cityCode != null)
            {
                strsql+=" and h.hospitalCode='"+cityCode+"'  ";
            }
            strsql+=" order by dh.orderId asc  ";

            DataSet ds = DbHelperSQL.Query(strsql);
            List<DentalMedical.Model.DH_relation> dhlist = new List<Model.DH_relation>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dhlist = DentalMedical.Common.DataTableList.ToList<DentalMedical.Model.DH_relation>(ds.Tables[0]);
            }
            return dhlist;
        }
		#endregion  ExtensionMethod
	}
}

