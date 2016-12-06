using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:verification_code
    /// </summary>
    public partial class verification_code : Iverification_code
    {
        public verification_code()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from verification_code");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DentalMedical.Model.verification_code model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into verification_code(");
            strSql.Append("id,v_code,code_type,orderId,createDate,createId)");
            strSql.Append(" values (");
            strSql.Append("@id,@verification_code,@code_type,@orderId,GETDATE(),@createId)");
            SqlParameter[] parameters = {					new SqlParameter("@id", SqlDbType.UniqueIdentifier),					new SqlParameter("@verification_code", SqlDbType.VarChar),					new SqlParameter("@code_type", SqlDbType.Int),					new SqlParameter("@orderId", SqlDbType.Int),					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),					new SqlParameter("@flag", SqlDbType.Int)};
            Guid id = Guid.NewGuid();
            parameters[0].Value = id;
            parameters[1].Value = model.v_code;
            parameters[2].Value = model.code_type;
            parameters[3].Value = model.orderId;
            parameters[4].Value = model.createId;
            parameters[5].Value = model.flag;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(DentalMedical.Model.verification_code model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update verification_code set ");
            strSql.Append("v_code=@v_code,");
            strSql.Append("code_type=@code_type,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createId=@createId,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("modifyId=@modifyId,");
            strSql.Append("flag=@flag");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@v_code", SqlDbType.VarChar,10),
					new SqlParameter("@code_type", SqlDbType.Int,4),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.v_code;
            parameters[1].Value = model.code_type;
            parameters[2].Value = model.orderId;
            parameters[3].Value = model.createDate;
            parameters[4].Value = model.createId;
            parameters[5].Value = model.modifyDate;
            parameters[6].Value = model.modifyId;
            parameters[7].Value = model.flag;
            parameters[8].Value = model.id;

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
        public bool Delete(Guid id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from verification_code ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from verification_code ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public DentalMedical.Model.verification_code GetModel(Guid id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,v_code,code_type,orderId,createDate,createId,modifyDate,modifyId,flag from verification_code ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = id;

            DentalMedical.Model.verification_code model = new DentalMedical.Model.verification_code();
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
        public DentalMedical.Model.verification_code DataRowToModel(DataRow row)
        {
            DentalMedical.Model.verification_code model = new DentalMedical.Model.verification_code();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = new Guid(row["id"].ToString());
                }
                if (row["v_code"] != null)
                {
                    model.v_code = row["v_code"].ToString();
                }
                if (row["code_type"] != null && row["code_type"].ToString() != "")
                {
                    model.code_type = int.Parse(row["code_type"].ToString());
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
            strSql.Append("select id,v_code,code_type,orderId,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM verification_code ");
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
            strSql.Append(" id,v_code,code_type,orderId,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM verification_code ");
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
            strSql.Append("select count(1) FROM verification_code ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from verification_code T ");
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
            parameters[0].Value = "verification_code";
            parameters[1].Value = "id";
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

