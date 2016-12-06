using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;
using System.Collections.Generic;//Please add references
using System.Collections;
using System.Collections.Specialized;
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:rootImage
	/// </summary>
	public partial class rootImage:IrootImage
	{
		public rootImage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from rootImage");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.rootImage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into rootImage(");
			strSql.Append("Id,EMR_Code,imagePath,orderId,createDate,createId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@EMR_Code,@imagePath,@orderId,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
					new SqlParameter("@imagePath", SqlDbType.VarChar),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.EMR_Code;
			parameters[2].Value = model.imagePath;
			parameters[3].Value = model.orderId;
			parameters[4].Value = model.createId;
			parameters[5].Value = 1;

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
		public bool Update(DentalMedical.Model.rootImage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update rootImage set ");
			strSql.Append("EMR_Code=@EMR_Code,");
			strSql.Append("imagePath=@imagePath,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25),
					new SqlParameter("@imagePath", SqlDbType.VarChar,-1),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.EMR_Code;
			parameters[1].Value = model.imagePath;
			parameters[2].Value = model.orderId;
			parameters[3].Value = model.createDate;
			parameters[4].Value = model.createId;
			parameters[5].Value = model.modifyDate;
			parameters[6].Value = model.modifyId;
			parameters[7].Value = model.flag;
			parameters[8].Value = model.Id;

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
			strSql.Append("delete from rootImage ");
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
			strSql.Append("delete from rootImage ");
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
		public DentalMedical.Model.rootImage GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,EMR_Code,imagePath,orderId,createDate,createId,modifyDate,modifyId,flag from rootImage ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.rootImage model=new DentalMedical.Model.rootImage();
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
		public DentalMedical.Model.rootImage DataRowToModel(DataRow row)
		{
			DentalMedical.Model.rootImage model=new DentalMedical.Model.rootImage();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["EMR_Code"]!=null)
				{
					model.EMR_Code=row["EMR_Code"].ToString();
				}
				if(row["imagePath"]!=null)
				{
					model.imagePath=row["imagePath"].ToString();
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
			strSql.Append("select Id,EMR_Code,imagePath,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM rootImage ");
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
			strSql.Append(" Id,EMR_Code,imagePath,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM rootImage ");
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
			strSql.Append("select count(1) FROM rootImage ");
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
			strSql.Append(")AS Row, T.*  from rootImage T ");
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
			parameters[0].Value = "rootImage";
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
        /// 根据病例号获取牙根照片
        /// </summary>
        /// <param name="emrCode"></param>
        /// <returns></returns>
        public List<DentalMedical.Model.rootImage> get_rootImage_List(string emrCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.rootImage WHERE EMR_Code=@EMR_Code ORDER BY orderId");
            SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)			};
            parameters[0].Value = emrCode;

            List<DentalMedical.Model.rootImage> List = new List<Model.rootImage>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    DentalMedical.Model.rootImage model = new DentalMedical.Model.rootImage();
                //    model=DataRowToModel(ds.Tables[0].Rows[i]);
                //    List.Add(model);
                //}

                List = DentalMedical.Common.DataTableList.ToList<DentalMedical.Model.rootImage>(ds.Tables[0]);
                return List;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public Hashtable Add_hash(DentalMedical.Model.rootImage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into rootImage(");
            strSql.Append("Id,EMR_Code,imagePath,orderId,createDate,createId,flag)");
            strSql.Append(" values (");
            strSql.Append("@Id,@EMR_Code,@imagePath,@orderId,GETDATE(),@createId,@flag)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
					new SqlParameter("@imagePath", SqlDbType.VarChar),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.EMR_Code;
            parameters[2].Value = model.imagePath;
            parameters[3].Value = model.orderId;
            parameters[4].Value = model.createId;
            parameters[5].Value = 1;

            Hashtable ht = new Hashtable();
            ht.Add(strSql, parameters);
            return ht;
        }
		#endregion  ExtensionMethod
	}
}

