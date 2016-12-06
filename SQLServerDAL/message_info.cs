using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:message_info
	/// </summary>
	public partial class message_info:Imessage_info
	{
		public message_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from message_info");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(DentalMedical.Model.message_info model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into message_info(");
                strSql.Append("Id,mobilePhone,mtype,validation_Code,orderId,createDate,createId,flag,message,smsstauts,smsIP,cRemark)");
                strSql.Append(" values (");
                strSql.Append("@Id,@mobilePhone,@mtype,@validation_Code,@orderId,GETDATE(),@createId,@flag,@message,@smsstauts,@smsIP,@cRemark)");
                SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@mobilePhone", SqlDbType.VarChar),
					new SqlParameter("@mtype", SqlDbType.Int),
					new SqlParameter("@validation_Code", SqlDbType.VarChar),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int),
                                            	new SqlParameter("@message", SqlDbType.VarChar),
                                            	new SqlParameter("@smsstauts", SqlDbType.VarChar),
                                            	new SqlParameter("@smsIP", SqlDbType.VarChar),
                                            	new SqlParameter("@cRemark", SqlDbType.VarChar),};
                Guid id = Guid.NewGuid();
                parameters[0].Value = id;
                parameters[1].Value = model.mobilePhone;
                parameters[2].Value = model.mtype;
                parameters[3].Value = model.validation_Code;
                parameters[4].Value = 1;
                parameters[5].Value = model.createId;
                parameters[6].Value = 1;
                parameters[7].Value = model.message;
                parameters[8].Value = model.smsstauts;
                parameters[9].Value = model.smsIP;
                parameters[10].Value = model.cRemark;

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
            catch (Exception)
            {

                throw;
            }
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.message_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update message_info set ");
			strSql.Append("mobilePhone=@mobilePhone,");
			strSql.Append("mtype=@mtype,");
			strSql.Append("validation_Code=@validation_Code,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@mobilePhone", SqlDbType.VarChar),
					new SqlParameter("@mtype", SqlDbType.Int,4),
					new SqlParameter("@validation_Code", SqlDbType.VarChar,6),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.mobilePhone;
			parameters[1].Value = model.mtype;
			parameters[2].Value = model.validation_Code;
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
			strSql.Append("delete from message_info ");
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
			strSql.Append("delete from message_info ");
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
		public DentalMedical.Model.message_info GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,mobilePhone,mtype,validation_Code,orderId,createDate,createId,modifyDate,modifyId,flag from message_info ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.message_info model=new DentalMedical.Model.message_info();
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
		public DentalMedical.Model.message_info DataRowToModel(DataRow row)
		{
			DentalMedical.Model.message_info model=new DentalMedical.Model.message_info();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["mobilePhone"]!=null && row["mobilePhone"].ToString()!="")
				{
					model.mobilePhone=row["mobilePhone"].ToString();
				}
				if(row["mtype"]!=null && row["mtype"].ToString()!="")
				{
					model.mtype=int.Parse(row["mtype"].ToString());
				}
				if(row["validation_Code"]!=null)
				{
					model.validation_Code=row["validation_Code"].ToString();
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
			strSql.Append("select Id,mobilePhone,mtype,validation_Code,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM message_info ");
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
			strSql.Append(" Id,mobilePhone,mtype,validation_Code,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM message_info ");
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
			strSql.Append("select count(1) FROM message_info ");
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
			strSql.Append(")AS Row, T.*  from message_info T ");
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
			parameters[0].Value = "message_info";
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
        /// 验证码是否正确
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int validate_code(string tel, string code,string mtype)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT TOP 1
        *
FROM    dbo.message_info
WHERE   mobilePhone = @mobilePhone AND mtype=@mtype
ORDER BY createDate DESC ");
            SqlParameter[] parameters = {
					new SqlParameter("@mobilePhone", SqlDbType.VarChar),new SqlParameter("@mtype", SqlDbType.VarChar)				};
            parameters[0].Value = tel;
            parameters[1].Value = mtype;
            DentalMedical.Model.message_info model = new DentalMedical.Model.message_info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);

                if (model.validation_Code.Equals(code))
                    return 1;//验证码正确
                else
                    return 2;//验证码错误

            }
            else
            {
                return 0;//没有验证码
            }
        }

        /// <summary>
        /// 判断是否在30秒内连续不断的发送短信
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public int senconds_message(string tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT COUNT(*)
                            FROM    [Dental].[dbo].[message_info]
                            WHERE   flag = 1
                                    AND DATEDIFF(ss, createDate, GETDATE()) < 30
		                            AND mobilePhone=@mobilePhone ");
            SqlParameter[] parameters = {
					new SqlParameter("@mobilePhone", SqlDbType.VarChar)};
            parameters[0].Value = tel;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 根据该电话 ip 获取到半小时内已发的短信验证码数
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int count_tel_ip(string tel, string ip)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  COUNT(1)
                            FROM    dbo.message_info
                            WHERE   ( mobilePhone = @mobilePhone
                                      OR smsIP = @smsip
                                    )
                                    AND DATEDIFF(MINUTE, createDate, GETDATE()) <= 30");
            SqlParameter[] parameters = {
					new SqlParameter("@mobilePhone", SqlDbType.VarChar),new SqlParameter("@smsip", SqlDbType.VarChar)};
            parameters[0].Value = tel;
            parameters[1].Value = ip;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
		#endregion  ExtensionMethod
	}
}

