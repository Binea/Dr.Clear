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
	/// 数据访问类:area_BaseData
	/// </summary>
	public partial class area_BaseData:Iarea_BaseData
	{
		public area_BaseData()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.area_BaseData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into area_BaseData(");
			strSql.Append("codeid,parentid,cityName)");
			strSql.Append(" values (");
			strSql.Append("@codeid,@parentid,@cityName)");
			SqlParameter[] parameters = {
					new SqlParameter("@codeid", SqlDbType.Int,4),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@cityName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.codeid;
			parameters[1].Value = model.parentid;
			parameters[2].Value = model.cityName;

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
		public bool Update(DentalMedical.Model.area_BaseData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update area_BaseData set ");
			strSql.Append("codeid=@codeid,");
			strSql.Append("parentid=@parentid,");
			strSql.Append("cityName=@cityName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@codeid", SqlDbType.Int,4),
					new SqlParameter("@parentid", SqlDbType.Int,4),
					new SqlParameter("@cityName", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.codeid;
			parameters[1].Value = model.parentid;
			parameters[2].Value = model.cityName;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from area_BaseData ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		public DentalMedical.Model.area_BaseData GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 codeid,parentid,cityName from area_BaseData ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			DentalMedical.Model.area_BaseData model=new DentalMedical.Model.area_BaseData();
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
		public DentalMedical.Model.area_BaseData DataRowToModel(DataRow row)
		{
			DentalMedical.Model.area_BaseData model=new DentalMedical.Model.area_BaseData();
			if (row != null)
			{
				if(row["codeid"]!=null && row["codeid"].ToString()!="")
				{
					model.codeid=row["codeid"].ToString();
				}
				if(row["parentid"]!=null && row["parentid"].ToString()!="")
				{
					model.parentid=row["parentid"].ToString();
				}
				if(row["cityName"]!=null)
				{
					model.cityName=row["cityName"].ToString();
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
			strSql.Append("select codeid,parentid,cityName ");
			strSql.Append(" FROM area_BaseData ");
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
			strSql.Append(" codeid,parentid,cityName ");
			strSql.Append(" FROM area_BaseData ");
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
			strSql.Append("select count(1) FROM area_BaseData ");
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
			strSql.Append(")AS Row, T.*  from area_BaseData T ");
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
			parameters[0].Value = "area_BaseData";
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
        /// 获取省市地区数据列表
        /// </summary>
        /// <returns>list</returns>
        public List<DentalMedical.Model.area_BaseData> Get_Arealist()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT  CAST(id AS VARCHAR(40)) AS codeid ,
                            CAST(parentid AS VARCHAR(40)) AS parentid ,
                            areaname AS cityName ,
                            sort ,
                            level
                            FROM    dbo.areas
                            WHERE   level <> 4
                                      UNION
                                      SELECT    CAST(Id AS VARCHAR(40)) ,
                                                CAST(hospitalCode AS VARCHAR(40)) ,
                                                hospitalName ,
                                                99 ,
                                                99
                                      FROM      dbo.hospitals
                                      WHERE     flag = 1
                                      UNION
                                      SELECT    CAST(d.Id AS VARCHAR(40)) ,
                                                CAST(dr.hospital_Id AS VARCHAR(40)) ,
                                                d.deName ,
                                                100 ,
                                                100
                                      FROM      dbo.departments d
                                                LEFT JOIN dbo.DH_relation dr ON dr.department_Id = d.Id
                                                                                AND dr.flag = 1
                                      WHERE     d.flag = 1
                                    ) b
                            ORDER BY level,sort         

");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<DentalMedical.Model.area_BaseData> arealist = new List<Model.area_BaseData>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                arealist = DentalMedical.Common.DataTableList.ToList<DentalMedical.Model.area_BaseData>(ds.Tables[0]);
            }
            return arealist;
        }

        /// <summary>
        /// 获取省市地区数据列表
        /// </summary>
        /// <returns>list</returns>
        public List<DentalMedical.Model.area_BaseData> Get_Area()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  CAST(id AS VARCHAR(40)) AS codeid ,
                                    CAST(parentid AS VARCHAR(40)) AS parentid ,
                                    areaname AS cityName,*
                            FROM    dbo.areas
                            WHERE   level <> 4
                            ORDER BY id,level,sort
        
                        ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<DentalMedical.Model.area_BaseData> arealist = new List<Model.area_BaseData>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                arealist = DentalMedical.Common.DataTableList.ToList<DentalMedical.Model.area_BaseData>(ds.Tables[0]);
            }
            return arealist;
        }
		#endregion  ExtensionMethod
	}
}

