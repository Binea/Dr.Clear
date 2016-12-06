using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:doctor_certification
	/// </summary>
	public partial class doctor_certification:Idoctor_certification
	{
		public doctor_certification()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from doctor_certification");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public string Add(DentalMedical.Model.doctor_certification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into doctor_certification(");
			strSql.Append("Id,doctor_Id,userHospital,userDepartment,userTitle,work_Card,status,dh_logo,isdefault,orderId,createDate,createId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@doctor_Id,@userHospital,@userDepartment,@userTitle,@work_Card,@status,@dh_logo,@isdefault,@orderId,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@userHospital", SqlDbType.UniqueIdentifier),
					new SqlParameter("@userDepartment", SqlDbType.UniqueIdentifier),
					new SqlParameter("@userTitle", SqlDbType.UniqueIdentifier),
					new SqlParameter("@work_Card", SqlDbType.VarChar),
					new SqlParameter("@status", SqlDbType.Int),
					new SqlParameter("@dh_logo", SqlDbType.VarChar),
					new SqlParameter("@isdefault", SqlDbType.Bit),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int)};
            Guid Id = Guid.NewGuid();
			parameters[0].Value = Id;
            parameters[1].Value = model.doctor_Id;
            parameters[2].Value = model.userHospital;
            parameters[3].Value = model.userDepartment;
            parameters[4].Value = model.userTitle;
			parameters[5].Value = model.work_Card;
			parameters[6].Value = model.status;
			parameters[7].Value = model.dh_logo;
			parameters[8].Value = model.isdefault;
			parameters[9].Value = model.orderId;
			parameters[10].Value = model.createId;
			parameters[11].Value = 1;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return Id.ToString();
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DentalMedical.Model.doctor_certification model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update doctor_certification set ");
			strSql.Append("doctor_Id=@doctor_Id,");
			strSql.Append("userHospital=@userHospital,");
			strSql.Append("userDepartment=@userDepartment,");
			strSql.Append("userTitle=@userTitle,");
			strSql.Append("work_Card=@work_Card,");
			strSql.Append("status=@status,");
			strSql.Append("dh_logo=@dh_logo,");
			strSql.Append("isdefault=@isdefault,");
			strSql.Append("orderId=@orderId,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userHospital", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userDepartment", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userTitle", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@work_Card", SqlDbType.VarChar,-1),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@dh_logo", SqlDbType.VarChar,-1),
					new SqlParameter("@isdefault", SqlDbType.Bit,1),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.doctor_Id;
			parameters[1].Value = model.userHospital;
			parameters[2].Value = model.userDepartment;
			parameters[3].Value = model.userTitle;
			parameters[4].Value = model.work_Card;
			parameters[5].Value = model.status;
			parameters[6].Value = model.dh_logo;
			parameters[7].Value = model.isdefault;
			parameters[8].Value = model.orderId;
			parameters[9].Value = model.createDate;
			parameters[10].Value = model.createId;
			parameters[11].Value = model.modifyDate;
			parameters[12].Value = model.modifyId;
			parameters[13].Value = model.flag;
			parameters[14].Value = model.Id;

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
			strSql.Append("delete from doctor_certification ");
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
			strSql.Append("delete from doctor_certification ");
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
		public DentalMedical.Model.doctor_certification GetModel(Guid Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,doctor_Id,userHospital,userDepartment,userTitle,work_Card,status,dh_logo,isdefault,orderId,createDate,createId,modifyDate,modifyId,flag from doctor_certification ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Id;

			DentalMedical.Model.doctor_certification model=new DentalMedical.Model.doctor_certification();
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
		public DentalMedical.Model.doctor_certification DataRowToModel(DataRow row)
		{
			DentalMedical.Model.doctor_certification model=new DentalMedical.Model.doctor_certification();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id= new Guid(row["Id"].ToString());
				}
				if(row["doctor_Id"]!=null && row["doctor_Id"].ToString()!="")
				{
					model.doctor_Id= new Guid(row["doctor_Id"].ToString());
				}
				if(row["userHospital"]!=null && row["userHospital"].ToString()!="")
				{
					model.userHospital= new Guid(row["userHospital"].ToString());
				}
				if(row["userDepartment"]!=null && row["userDepartment"].ToString()!="")
				{
					model.userDepartment= new Guid(row["userDepartment"].ToString());
				}
				if(row["userTitle"]!=null && row["userTitle"].ToString()!="")
				{
					model.userTitle= new Guid(row["userTitle"].ToString());
				}
				if(row["work_Card"]!=null)
				{
					model.work_Card=row["work_Card"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["dh_logo"]!=null)
				{
					model.dh_logo=row["dh_logo"].ToString();
				}
				if(row["isdefault"]!=null && row["isdefault"].ToString()!="")
				{
					if((row["isdefault"].ToString()=="1")||(row["isdefault"].ToString().ToLower()=="true"))
					{
						model.isdefault=true;
					}
					else
					{
						model.isdefault=false;
					}
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
			strSql.Append("select Id,doctor_Id,userHospital,userDepartment,userTitle,work_Card,status,dh_logo,isdefault,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM doctor_certification ");
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
			strSql.Append(" Id,doctor_Id,userHospital,userDepartment,userTitle,work_Card,status,dh_logo,isdefault,orderId,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM doctor_certification ");
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
			strSql.Append("select count(1) FROM doctor_certification ");
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
			strSql.Append(")AS Row, T.*  from doctor_certification T ");
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
			parameters[0].Value = "doctor_certification";
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
        /// 更新认证信息
        /// </summary>
        public bool Update_d_certification(DentalMedical.Model.doctor_certification model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update doctor_certification set ");
            strSql.Append("userHospital=@userHospital,");
            strSql.Append("userDepartment=@userDepartment,");
            strSql.Append("work_Card=@work_Card,");
            strSql.Append("userTitle=@userTitle,");
            strSql.Append("modifyDate=GETDATE(),");
            strSql.Append("modifyId=@modifyId");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@userHospital", SqlDbType.UniqueIdentifier),
					new SqlParameter("@userDepartment", SqlDbType.UniqueIdentifier),
					new SqlParameter("@userTitle", SqlDbType.UniqueIdentifier),
					new SqlParameter("@work_Card", SqlDbType.VarChar),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.userHospital;
            parameters[1].Value = model.userDepartment;
            parameters[2].Value = model.userTitle;
            parameters[3].Value = model.work_Card;
            parameters[4].Value = model.modifyId;
            parameters[5].Value = model.Id;
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
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool delete_d_certification(Guid Id,Guid doctorId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update doctor_certification set ");
            strSql.Append(" flag=0, ");
            strSql.Append("modifyDate=GETDATE(),");
            strSql.Append("modifyId=@modifyId ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),	new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = Id;
            parameters[1].Value = doctorId;
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

