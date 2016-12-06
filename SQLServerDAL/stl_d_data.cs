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
    /// 数据访问类:stl_d_data
    /// </summary>
    public partial class stl_d_data : Istl_d_data
    {
        public stl_d_data()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from stl_d_data");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DentalMedical.Model.stl_d_data model)
        {
            string id = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into stl_d_data(");
            strSql.Append("Id,EMR_Code,filePath,model_type,status,orderId,createId)");
            strSql.Append(" values (");
            strSql.Append("@Id,@EMR_Code,@filePath,@model_type,@status,@orderId,@createId)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
					new SqlParameter("@filePath", SqlDbType.VarChar),
					new SqlParameter("@model_type", SqlDbType.Int),
					new SqlParameter("@status", SqlDbType.Int),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier)};
            id = Guid.NewGuid().ToString();
            parameters[0].Value = new Guid(id);
            parameters[1].Value = model.EMR_Code;
            parameters[2].Value = model.filePath;
            parameters[3].Value = model.model_type;
            parameters[4].Value = model.status;
            parameters[5].Value = model.orderId;
            parameters[6].Value = model.createId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return id;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DentalMedical.Model.stl_d_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update stl_d_data set ");
            strSql.Append("EMR_Code=@EMR_Code,");
            strSql.Append("filePath=@filePath,");
            strSql.Append("model_type=@model_type,");
            strSql.Append("status=@status,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createId=@createId,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("modifyId=@modifyId,");
            strSql.Append("flag=@flag");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25),
					new SqlParameter("@filePath", SqlDbType.VarChar,-1),
					new SqlParameter("@model_type", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.EMR_Code;
            parameters[1].Value = model.filePath;
            parameters[2].Value = model.model_type;
            parameters[3].Value = model.status;
            parameters[4].Value = model.orderId;
            parameters[5].Value = model.createDate;
            parameters[6].Value = model.createId;
            parameters[7].Value = model.modifyDate;
            parameters[8].Value = model.modifyId;
            parameters[9].Value = model.flag;
            parameters[10].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stl_d_data ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stl_d_data ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public DentalMedical.Model.stl_d_data GetModel(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,EMR_Code,filePath,model_type,status,orderId,createDate,createId,modifyDate,modifyId,flag from stl_d_data ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            DentalMedical.Model.stl_d_data model = new DentalMedical.Model.stl_d_data();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public DentalMedical.Model.stl_d_data DataRowToModel(DataRow row)
        {
            DentalMedical.Model.stl_d_data model = new DentalMedical.Model.stl_d_data();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = new Guid(row["Id"].ToString());
                }
                if (row["EMR_Code"] != null)
                {
                    model.EMR_Code = row["EMR_Code"].ToString();
                }
                if (row["filePath"] != null)
                {
                    model.filePath = row["filePath"].ToString();
                }
                if (row["model_type"] != null && row["model_type"].ToString() != "")
                {
                    model.model_type = int.Parse(row["model_type"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["orderId"] != null && row["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(row["orderId"].ToString());
                }
                if (row["createDate"] != null && row["createDate"].ToString() != "")
                {
                    model.createDate = DateTime.Parse(row["createDate"].ToString());
                }
                if (row["createId"] != null && row["createId"].ToString() != "")
                {
                    model.createId = new Guid(row["createId"].ToString());
                }
                if (row["modifyDate"] != null && row["modifyDate"].ToString() != "")
                {
                    model.modifyDate = DateTime.Parse(row["modifyDate"].ToString());
                }
                if (row["modifyId"] != null && row["modifyId"].ToString() != "")
                {
                    model.modifyId = new Guid(row["modifyId"].ToString());
                }
                if (row["flag"] != null && row["flag"].ToString() != "")
                {
                    model.flag = int.Parse(row["flag"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,EMR_Code,filePath,model_type,status,orderId,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM stl_d_data ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,EMR_Code,filePath,model_type,status,orderId,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM stl_d_data ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM stl_d_data ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from stl_d_data T ");
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
            parameters[0].Value = "stl_d_data";
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
        /// 根据emrcode获取stl文件的最新情况
        /// </summary>
        /// <param name="emr_code"></param>
        /// <returns></returns>
        public DentalMedical.Model.stl_d_data get_stl(string emr_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TOP 1
                                    *
                            FROM    dbo.stl_d_data
                            WHERE   EMR_Code = @emr_code
                                    AND status = 1   AND flag = 1
                            ORDER BY createDate DESC
                            ");
            SqlParameter[] parameters = {
                    new SqlParameter("@emr_code", SqlDbType.VarChar)};
            parameters[0].Value = emr_code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            DentalMedical.Model.stl_d_data stl = new Model.stl_d_data();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return stl;
            }
        }

        /// <summary>
        /// stl文件状态更新；0：废弃
        /// </summary>
        /// <param name="emrcode"></param>
        /// <returns></returns>
        public bool update_status(string emrcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE  dbo.stl_d_data
                            SET     status = 0
                            WHERE   EMR_Code = @EMR_Code ");
          
            SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)
				};
            parameters[0].Value = emrcode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}

