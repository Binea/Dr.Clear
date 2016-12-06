using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;
using System.Collections.Generic;
using DentalMedical.Common;//Please add references
namespace DentalMedical.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:appointment
    /// </summary>
    public partial class appointment : Iappointment
    {
        public appointment()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from appointment");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DentalMedical.Model.appointment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into appointment(");
            strSql.Append("Id,patientName,patientTel,appointment_Add,appointment_demand,appointment_Date,orderId,createDate,createId,flag)");
            strSql.Append(" values (");
            strSql.Append("@Id,@patientName,@patientTel,@appointment_Add,@appointment_demand,@appointment_Date,1,GETDATE(),@createId,1)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@patientName", SqlDbType.VarChar),
					new SqlParameter("@patientTel", SqlDbType.VarChar),
					new SqlParameter("@appointment_Add", SqlDbType.VarChar),
					new SqlParameter("@appointment_demand", SqlDbType.VarChar),                    
					new SqlParameter("@appointment_Date", SqlDbType.VarChar),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier)};
            Guid id = Guid.NewGuid();
            parameters[0].Value = id;
            parameters[1].Value = model.patientName;
            parameters[2].Value = model.patientTel;
            parameters[3].Value = model.appointment_Add;
            parameters[4].Value = model.appointment_demand;
            parameters[5].Value = model.appointment_Date;
            parameters[6].Value = model.createId;

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
        public bool Update(DentalMedical.Model.appointment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update appointment set ");
            strSql.Append("patientName=@patientName,");
            strSql.Append("patientTel=@patientTel,");
            strSql.Append("appointment_Add=@appointment_Add,");
            strSql.Append("appointment_demand=@appointment_demand,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createId=@createId,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("modifyId=@modifyId,");
            strSql.Append("flag=@flag");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@patientName", SqlDbType.VarChar,50),
					new SqlParameter("@patientTel", SqlDbType.VarChar,20),
					new SqlParameter("@appointment_Add", SqlDbType.VarChar,500),
					new SqlParameter("@appointment_demand", SqlDbType.VarChar,-1),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.patientName;
            parameters[1].Value = model.patientTel;
            parameters[2].Value = model.appointment_Add;
            parameters[3].Value = model.appointment_demand;
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
            strSql.Append("delete from appointment ");
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
            strSql.Append("delete from appointment ");
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
        public DentalMedical.Model.appointment GetModel(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,patientName,patientTel,appointment_Add,appointment_demand,orderId,createDate,createId,modifyDate,modifyId,flag from appointment ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            DentalMedical.Model.appointment model = new DentalMedical.Model.appointment();
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
        public DentalMedical.Model.appointment DataRowToModel(DataRow row)
        {
            DentalMedical.Model.appointment model = new DentalMedical.Model.appointment();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = new Guid(row["Id"].ToString());
                }
                if (row["patientName"] != null)
                {
                    model.patientName = row["patientName"].ToString();
                }
                if (row["patientTel"] != null)
                {
                    model.patientTel = row["patientTel"].ToString();
                }
                if (row["appointment_Add"] != null)
                {
                    model.appointment_Add = row["appointment_Add"].ToString();
                }
                if (row["appointment_demand"] != null)
                {
                    model.appointment_demand = row["appointment_demand"].ToString();
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
            strSql.Append("select Id,patientName,patientTel,appointment_Add,appointment_demand,orderId,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM appointment ");
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
            strSql.Append(" Id,patientName,patientTel,appointment_Add,appointment_demand,orderId,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM appointment ");
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
            strSql.Append("select count(1) FROM appointment ");
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
            strSql.Append(")AS Row, T.*  from appointment T ");
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
            parameters[0].Value = "appointment";
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
        /// 获取病人预约列表
        /// </summary>
        /// <param name="mainId">用户Id</param>
        /// <returns></returns>
        public List<DentalMedical.Model.appointment> get_appointmentList(Guid mainId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [Id]
                              ,[patientName]
                              ,[patientTel]
                              ,[appointment_Add]
                              ,[appointment_demand]
                              ,[appointment_Date]
                              ,[orderId]
                              ,[createDate]
                              ,[createId]
                              ,[modifyDate]
                              ,[modifyId]
                              ,[flag]
                          FROM [dbo].[appointment]  WHERE createId=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier)			};
            parameters[0].Value = mainId;
            List<DentalMedical.Model.appointment> stream = new List<Model.appointment>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    DentalMedical.Model.EMR_stream emrstrem = new Model.EMR_stream();
                //    emrstrem = es.DataRowToModel(ds.Tables[0].Rows[i]);
                //    stream.Add(emrstrem);
                //}
                stream = DataTableList.ToList<DentalMedical.Model.appointment>(ds.Tables[0]);
            }
            return stream;
        }
        /// <summary>
        /// 获取病人预约列表
        /// </summary>
        /// <param name="mainId">用户Id</param>
        /// <returns></returns>
        public List<DentalMedical.Model.appointment> get_appointmentList_byweixin(string weixin)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  a.*
FROM    [dbo].[appointment] a
        LEFT JOIN dbo.patientInfo pin ON pin.Id = a.createId
WHERE   pin.weixin = @weixin");
            SqlParameter[] parameters = {
					new SqlParameter("@weixin", SqlDbType.VarChar)			};
            parameters[0].Value = weixin;
            List<DentalMedical.Model.appointment> stream = new List<Model.appointment>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    DentalMedical.Model.EMR_stream emrstrem = new Model.EMR_stream();
                //    emrstrem = es.DataRowToModel(ds.Tables[0].Rows[i]);
                //    stream.Add(emrstrem);
                //}
                stream = DataTableList.ToList<DentalMedical.Model.appointment>(ds.Tables[0]);
            }
            return stream;
        }
        #endregion  ExtensionMethod
    }
}

