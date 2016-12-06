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
	/// 数据访问类:payment_info
	/// </summary>
	public partial class payment_info:Ipayment_info
	{
		public payment_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from payment_info");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据，付款信息
		/// </summary>
		public bool Add(DentalMedical.Model.payment_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into payment_info(");
			strSql.Append("Id,EMR_Code,factory_Id,channel,type,money,bill_code,isInvoice,cRemark,createDate,createId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@EMR_Code,@factory_Id,@channel,@type,@money,@bill_code,@isInvoice,@cRemark,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@channel", SqlDbType.VarChar),
					new SqlParameter("@type", SqlDbType.VarChar),
					new SqlParameter("@money", SqlDbType.Decimal),
					new SqlParameter("@bill_code", SqlDbType.VarChar),
					new SqlParameter("@isInvoice", SqlDbType.Bit),
					new SqlParameter("@cRemark", SqlDbType.VarChar),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int)};
            Guid id = Guid.NewGuid();
			parameters[0].Value = id;
			parameters[1].Value = model.EMR_Code;
			parameters[2].Value = model.factory_Id;
			parameters[3].Value = model.channel;
			parameters[4].Value = model.type;
			parameters[5].Value = model.money;
			parameters[6].Value = model.bill_code;
			parameters[7].Value = 0;
			parameters[8].Value = model.cRemark;
            parameters[9].Value = model.createId;
			parameters[10].Value = 1;

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
		public bool Update(DentalMedical.Model.payment_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update payment_info set ");
			strSql.Append("EMR_Code=@EMR_Code,");
			strSql.Append("factory_Id=@factory_Id,");
			strSql.Append("channel=@channel,");
			strSql.Append("type=@type,");
			strSql.Append("money=@money,");
			strSql.Append("bill_code=@bill_code,");
			strSql.Append("isInvoice=@isInvoice,");
			strSql.Append("cRemark=@cRemark,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25),
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@channel", SqlDbType.VarChar,25),
					new SqlParameter("@type", SqlDbType.VarChar,25),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@bill_code", SqlDbType.VarChar,25),
					new SqlParameter("@isInvoice", SqlDbType.Bit,1),
					new SqlParameter("@cRemark", SqlDbType.VarChar,500),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.EMR_Code;
			parameters[1].Value = model.factory_Id;
			parameters[2].Value = model.channel;
			parameters[3].Value = model.type;
			parameters[4].Value = model.money;
			parameters[5].Value = model.bill_code;
			parameters[6].Value = model.isInvoice;
			parameters[7].Value = model.cRemark;
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
			strSql.Append("delete from payment_info ");
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
			strSql.Append("delete from payment_info ");
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
		public DentalMedical.Model.payment_info GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,EMR_Code,factory_Id,channel,type,money,bill_code,isInvoice,cRemark,createDate,createId,modifyDate,modifyId,flag from payment_info ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.payment_info model=new DentalMedical.Model.payment_info();
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
		public DentalMedical.Model.payment_info DataRowToModel(DataRow row)
		{
			DentalMedical.Model.payment_info model=new DentalMedical.Model.payment_info();
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
				if(row["factory_Id"]!=null && row["factory_Id"].ToString()!="")
				{
					model.factory_Id= new Guid(row["factory_Id"].ToString());
				}
				if(row["channel"]!=null)
				{
					model.channel=row["channel"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["money"]!=null && row["money"].ToString()!="")
				{
					model.money=decimal.Parse(row["money"].ToString());
				}
				if(row["bill_code"]!=null)
				{
					model.bill_code=row["bill_code"].ToString();
				}
				if(row["isInvoice"]!=null && row["isInvoice"].ToString()!="")
				{
					if((row["isInvoice"].ToString()=="1")||(row["isInvoice"].ToString().ToLower()=="true"))
					{
						model.isInvoice=true;
					}
					else
					{
						model.isInvoice=false;
					}
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
			strSql.Append("select Id,EMR_Code,factory_Id,channel,type,money,bill_code,isInvoice,cRemark,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM payment_info ");
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
			strSql.Append(" Id,EMR_Code,factory_Id,channel,type,money,bill_code,isInvoice,cRemark,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM payment_info ");
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
			strSql.Append("select count(1) FROM payment_info ");
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
			strSql.Append(")AS Row, T.*  from payment_info T ");
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
			parameters[0].Value = "payment_info";
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
        /// 获取付款信息List
        /// </summary>
        /// <returns>付款信息集合</returns>
        public List<DentalMedical.Model.payment_info> Get_payment_List(Guid factoryId)
        {
            string sql = @"SELECT  pa.[Id] ,
        pa.[EMR_Code] ,
        se.patient_Name ,
        [factory_Id] ,
        [channel] ,
        [type] ,
        [money] ,
        [bill_code] ,
        [isInvoice] ,
        pa.[createDate]
FROM    [dbo].[payment_info] pa
        LEFT JOIN dbo.simple_EMR se ON se.EMR_Code = pa.EMR_Code
                                       AND se.flag = 1
WHERE   pa.flag = 1
        AND pa.factory_Id = @factory_Id";
            DataSet ds = DbHelperSQL.Query(sql);
            List<DentalMedical.Model.payment_info> list = new List<Model.payment_info>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ////用于反射类无法使用时使用
                //for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                //{
                //    DentalMedical.Model.payment_info pi = DataRowToModel(ds.Tables[0].Rows[i]);
                //    list.Add(pi);
                //}
                list = DataTableList.ToList<DentalMedical.Model.payment_info>(ds.Tables[0]);
                return list;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 开票
        /// </summary>
        /// <param name="payId">付款信息ID</param>
        /// <returns></returns>
        public bool open_Invoice(Guid payId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE  dbo.payment_info
SET     isInvoice = 1
WHERE   flag = 1
        AND Id = @Id");
            SqlParameter[] parameters = { 
                                        new SqlParameter("@Id",SqlDbType.UniqueIdentifier)
                                        };
            parameters[0].Value = payId;
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

