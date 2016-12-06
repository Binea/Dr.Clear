using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:authorize_technician
    /// </summary>
    public partial class authorize_technician : Iauthorize_technician
    {
        public authorize_technician()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from authorize_technician");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DentalMedical.Model.authorize_technician model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into authorize_technician(");
            strSql.Append("Id,doctorId,dcId,mechanicId,orderId,userRemark,createDate,createId,flag)");
            strSql.Append(" values (");
            strSql.Append("@Id,@doctorId,@dcId,@mechanicId,@orderId,@userRemark,GETDATE(),@createId,1)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@doctorId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@dcId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@mechanicId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@userRemark", SqlDbType.VarChar),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier)};
            Guid id = Guid.NewGuid();
            parameters[0].Value = id;
            parameters[1].Value = model.doctorId;
            parameters[2].Value = model.dcId;
            parameters[3].Value = model.mechanicId;
            parameters[4].Value = model.orderId;
            parameters[5].Value = model.userRemark;
            parameters[6].Value = model.doctorId;
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
        public bool Update(DentalMedical.Model.authorize_technician model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update authorize_technician set ");
            strSql.Append("doctorId=@doctorId,");
            strSql.Append("dcId=@dcId,");
            strSql.Append("mechanicId=@mechanicId,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("userRemark=@userRemark,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createId=@createId,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("modifyId=@modifyId,");
            strSql.Append("flag=@flag");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@doctorId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@dcId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@mechanicId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@userRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.doctorId;
            parameters[1].Value = model.dcId;
            parameters[2].Value = model.mechanicId;
            parameters[3].Value = model.orderId;
            parameters[4].Value = model.userRemark;
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
            strSql.Append("delete from authorize_technician ");
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
            strSql.Append("delete from authorize_technician ");
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
        public DentalMedical.Model.authorize_technician GetModel(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,doctorId,dcId,mechanicId,orderId,userRemark,createDate,createId,modifyDate,modifyId,flag from authorize_technician ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            DentalMedical.Model.authorize_technician model = new DentalMedical.Model.authorize_technician();
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
        public DentalMedical.Model.authorize_technician DataRowToModel(DataRow row)
        {
            DentalMedical.Model.authorize_technician model = new DentalMedical.Model.authorize_technician();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = new Guid(row["Id"].ToString());
                }
                if (row["doctorId"] != null && row["doctorId"].ToString() != "")
                {
                    model.doctorId = new Guid(row["doctorId"].ToString());
                }
                if (row["dcId"] != null && row["dcId"].ToString() != "")
                {
                    model.dcId = new Guid(row["dcId"].ToString());
                }
                if (row["mechanicId"] != null && row["mechanicId"].ToString() != "")
                {
                    model.mechanicId = new Guid(row["mechanicId"].ToString());
                }
                if (row["orderId"] != null && row["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(row["orderId"].ToString());
                }
                if (row["userRemark"] != null)
                {
                    model.userRemark = row["userRemark"].ToString();
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
            strSql.Append("select Id,doctorId,dcId,mechanicId,orderId,userRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM authorize_technician ");
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
            strSql.Append(" Id,doctorId,dcId,mechanicId,orderId,userRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM authorize_technician ");
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
            strSql.Append("select count(1) FROM authorize_technician ");
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
            strSql.Append(")AS Row, T.*  from authorize_technician T ");
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
            parameters[0].Value = "authorize_technician";
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
        /// 将之前授权技师置为不可用
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="dcId"></param>
        /// <returns></returns>
        public bool delete_exauthorize(Guid doctorId, Guid dcId)
        {
            if (Exists(doctorId, dcId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"UPDATE  dbo.authorize_technician
                            SET     flag = 0
                            WHERE   doctorId = @doctorId
                                    AND dcId = @dcId and flag=1");
                SqlParameter[] parameters = {
					new SqlParameter("@doctorId", SqlDbType.UniqueIdentifier),	new SqlParameter("@dcId", SqlDbType.UniqueIdentifier)			};
                parameters[0].Value = doctorId;
                parameters[1].Value = dcId;
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
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid doctorId, Guid dcId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from authorize_technician");
            strSql.Append(" where doctorId=@doctorId  AND dcId = @dcId AND flag=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@doctorId", SqlDbType.UniqueIdentifier),		new SqlParameter("@dcId", SqlDbType.UniqueIdentifier)	};
            parameters[0].Value = doctorId;
            parameters[1].Value = dcId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid doctorId, Guid dcId,Guid mechanicId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from authorize_technician");
            strSql.Append(" where Id=@doctorId  AND dcId = @dcId AND mechanicId=@mechanicId AND flag=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@doctorId", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@dcId", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@mechanicId", SqlDbType.UniqueIdentifier)	};
            parameters[0].Value = doctorId;
            parameters[1].Value = dcId;
            parameters[2].Value = mechanicId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

