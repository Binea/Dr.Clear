using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
using DentalMedical.Common;
using System.Collections.Generic;
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:doctors
	/// </summary>
	public partial class doctors:Idoctors
	{
		public doctors()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("userCode", "doctors"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from doctors");
			strSql.Append(" where userCode=@userCode ");
			SqlParameter[] parameters = {					
					new SqlParameter("@userCode", SqlDbType.VarChar)			};
		
			parameters[0].Value = userCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据，注册
		/// </summary>
		public string Add(DentalMedical.Model.doctors model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into doctors(");
            strSql.Append("Id,userCode,userTel,userPwd,userKey,orderId,doctor_Id,createDate,createId,flag,userSchool,f_invit_code)");
			strSql.Append(" values (");
            strSql.Append("@Id,@userCode,@userTel,@userPwd,@userKey,@orderId,@doctor_Id,GETDATE(),@createId,@flag,@school,@f_invit_code)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userCode", SqlDbType.VarChar),
					new SqlParameter("@userTel", SqlDbType.VarChar),
					new SqlParameter("@userPwd", SqlDbType.VarChar),
					new SqlParameter("@userKey", SqlDbType.Int),
					new SqlParameter("@orderId", SqlDbType.Int),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int),
                    new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@school", SqlDbType.Int),
                                        new SqlParameter("@f_invit_code", SqlDbType.VarChar)};
            Guid id = Guid.NewGuid();
			parameters[0].Value = id;
			parameters[1].Value = model.userCode;
			parameters[2].Value = model.userTel;
            parameters[3].Value = DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(model.userPwd); 
			parameters[4].Value = model.userKey;
			parameters[5].Value = 1;
			parameters[6].Value = id;
			parameters[7].Value = 1;
            parameters[8].Value = model.doctor_Id;
            parameters[9].Value = model.userSchool;
            parameters[10].Value = "LD1MR";
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
                DentalMedical.Model.FD_relation fd = new Model.FD_relation();
                fd.createId = id;
                fd.doctor_Id = id;
                fd.factory_Id = new Guid("60ACD3A9-D980-497C-BB01-65582D2F8CDC");
                fd.cRemark = "创建插入！";
                FD_relation fdr = new FD_relation();
                fdr.Add(fd);
				return id.ToString();
			}
			else
			{
				return string.Empty;
			}
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DentalMedical.Model.doctors model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update doctors set ");
            strSql.Append("userTel=@userTel,");
            strSql.Append("userPwd=@userPwd,");
            strSql.Append("userEmail=@userEmail,");
            strSql.Append("userKey=@userKey,");
            strSql.Append("userPetName=@userPetName,");
            strSql.Append("userLogo=@userLogo,");
            strSql.Append("userRealName=@userRealName,");
            strSql.Append("userSex=@userSex,");
            strSql.Append("userBirthday=@userBirthday,");
            strSql.Append("userAddress=@userAddress,");
            strSql.Append("userWorkYears=@userWorkYears,");
            strSql.Append("userSchool=@userSchool,");
            strSql.Append("userBlog=@userBlog,");
            strSql.Append("onlineStatus=@onlineStatus,");
            strSql.Append("f_invit_code=@f_invit_code,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("doctor_Id=@doctor_Id,");
            strSql.Append("userRemark=@userRemark,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createId=@createId,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("modifyId=@modifyId,");
            strSql.Append("flag=@flag");
            strSql.Append(" where Id=@Id and userCode=@userCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@userTel", SqlDbType.VarChar,20),
					new SqlParameter("@userPwd", SqlDbType.VarChar,20),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@userKey", SqlDbType.Int,4),
					new SqlParameter("@userPetName", SqlDbType.VarChar,50),
					new SqlParameter("@userLogo", SqlDbType.VarChar,-1),
					new SqlParameter("@userRealName", SqlDbType.VarChar,25),
					new SqlParameter("@userSex", SqlDbType.Int),
					new SqlParameter("@userBirthday", SqlDbType.DateTime),
					new SqlParameter("@userAddress", SqlDbType.VarChar,-1),
					new SqlParameter("@userWorkYears", SqlDbType.Int,4),
					new SqlParameter("@userSchool", SqlDbType.Int,4),
					new SqlParameter("@userBlog", SqlDbType.VarChar,-1),
					new SqlParameter("@onlineStatus", SqlDbType.Int,4),
					new SqlParameter("@f_invit_code", SqlDbType.VarChar,6),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@userRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userCode", SqlDbType.VarChar)};
            parameters[0].Value = model.userTel;
            parameters[1].Value = model.userPwd;
            parameters[2].Value = model.userEmail;
            parameters[3].Value = model.userKey;
            parameters[4].Value = model.userPetName;
            parameters[5].Value = model.userLogo;
            parameters[6].Value = model.userRealName;
            parameters[7].Value = model.userSex;
            parameters[8].Value = model.userBirthday;
            parameters[9].Value = model.userAddress;
            parameters[10].Value = model.userWorkYears;
            parameters[11].Value = model.userSchool;
            parameters[12].Value = model.userBlog;
            parameters[13].Value = model.onlineStatus;
            parameters[14].Value = model.f_invit_code;
            parameters[15].Value = model.orderId;
            parameters[16].Value = model.doctor_Id;
            parameters[17].Value = model.userRemark;
            parameters[18].Value = model.createDate;
            parameters[19].Value = model.createId;
            parameters[20].Value = model.modifyDate;
            parameters[21].Value = model.modifyId;
            parameters[22].Value = model.flag;
            parameters[23].Value = model.Id;
            parameters[24].Value = model.userCode;

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
        public bool Delete(Guid Id, string userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from doctors ");
            strSql.Append(" where Id=@Id and userCode=@userCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userCode", SqlDbType.VarChar)			};
            parameters[0].Value = Id;
            parameters[1].Value = userCode;

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
        /// 得到一个对象实体
        /// </summary>
        public DentalMedical.Model.doctors GetModel(Guid Id, string userCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,userCode,userTel,userPwd,userEmail,userKey,userPetName,userLogo,userRealName,userSex,userBirthday,userAddress,userWorkYears,userSchool,userBlog,onlineStatus,f_invit_code,orderId,doctor_Id,userRemark,createDate,createId,modifyDate,modifyId,flag from doctors ");
            strSql.Append(" where Id=@Id and userCode=@userCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userCode", SqlDbType.VarChar)			};
            parameters[0].Value = Id;
            parameters[1].Value = userCode;

            DentalMedical.Model.doctors model = new DentalMedical.Model.doctors();
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
        public DentalMedical.Model.doctors DataRowToModel(DataRow row)
        {
            DentalMedical.Model.doctors model = new DentalMedical.Model.doctors();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = new Guid(row["Id"].ToString());
                }
                if (row["userCode"] != null && row["userCode"].ToString() != "")
                {
                    model.userCode = row["userCode"].ToString();
                }
                if (row["userTel"] != null)
                {
                    model.userTel = row["userTel"].ToString();
                }
                if (row["userPwd"] != null)
                {
                    model.userPwd = row["userPwd"].ToString();
                }
                if (row["userEmail"] != null)
                {
                    model.userEmail = row["userEmail"].ToString();
                }
                if (row["userKey"] != null && row["userKey"].ToString() != "")
                {
                    model.userKey = int.Parse(row["userKey"].ToString());
                }
                if (row["userPetName"] != null)
                {
                    model.userPetName = row["userPetName"].ToString();
                }
                if (row["userLogo"] != null)
                {
                    model.userLogo = row["userLogo"].ToString();
                }
                if (row["userRealName"] != null)
                {
                    model.userRealName = row["userRealName"].ToString();
                }
                if (row["userSex"] != null && row["userSex"].ToString() != "")
                {
                    model.userSex = int.Parse(row["userSex"].ToString());
                }
                if (row["userBirthday"] != null && row["userBirthday"].ToString() != "")
                {
                    model.userBirthday = DateTime.Parse(row["userBirthday"].ToString());
                }
                if (row["userAddress"] != null)
                {
                    model.userAddress = row["userAddress"].ToString();
                }
                if (row["userWorkYears"] != null && row["userWorkYears"].ToString() != "")
                {
                    model.userWorkYears = int.Parse(row["userWorkYears"].ToString());
                }
                if (row["userSchool"] != null && row["userSchool"].ToString() != "")
                {
                    model.userSchool = int.Parse(row["userSchool"].ToString());
                }
                if (row["userBlog"] != null)
                {
                    model.userBlog = row["userBlog"].ToString();
                }
                if (row["onlineStatus"] != null && row["onlineStatus"].ToString() != "")
                {
                    model.onlineStatus = int.Parse(row["onlineStatus"].ToString());
                }
                if (row["f_invit_code"] != null)
                {
                    model.f_invit_code = row["f_invit_code"].ToString();
                }
                if (row["orderId"] != null && row["orderId"].ToString() != "")
                {
                    model.orderId = int.Parse(row["orderId"].ToString());
                }
                if (row["doctor_Id"] != null && row["doctor_Id"].ToString() != "")
                {
                    model.doctor_Id = new Guid(row["doctor_Id"].ToString());
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
            strSql.Append("select Id,userCode,userTel,userPwd,userEmail,userKey,userPetName,userLogo,userRealName,userSex,userBirthday,userAddress,userWorkYears,userSchool,userBlog,onlineStatus,f_invit_code,orderId,doctor_Id,userRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM doctors ");
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
            strSql.Append(" Id,userCode,userTel,userPwd,userEmail,userKey,userPetName,userLogo,userRealName,userSex,userBirthday,userAddress,userWorkYears,userSchool,userBlog,onlineStatus,f_invit_code,orderId,doctor_Id,userRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM doctors ");
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
            strSql.Append("select count(1) FROM doctors ");
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
                strSql.Append("order by T.userCode desc");
            }
            strSql.Append(")AS Row, T.*  from doctors T ");
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
            parameters[0].Value = "doctors";
            parameters[1].Value = "userCode";
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
       ///  根据账号查询信息是否存在
       /// </summary>
       /// <param name="userCode">用户账号</param>
       /// <param name="pwd">用户密码</param>
       /// <returns></returns>
        public DentalMedical.Model.doctors Query_Code(string userCode, string pwd=null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.doctors");
            strSql.Append(" WHERE userCode= @userCode and flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@userCode", SqlDbType.VarChar)			};
            parameters[0].Value = userCode;
            DentalMedical.Model.doctors model = new DentalMedical.Model.doctors();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            //string sql = "SELECT * FROM dbo.doctors WHERE userCode='"+userCode+"'  ";
            //DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///  判断密码是否正确
        /// </summary>
        /// <param name="doctors"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DentalMedical.Model.doctors judge_Pwd(DentalMedical.Model.doctors doctors ,string pwd)
        {
            if (DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(pwd).Equals(doctors.userPwd))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("SELECT * FROM dbo.doctor_hospital_View ");
                strSql2.Append("WHERE Id=@Id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier)			};
                parameters2[0].Value = doctors.Id;
                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    doctors.doctor_hospital_View = DataTableList.ToList<DentalMedical.Model.doctor_hospital_View>(ds2.Tables[0]);
                }
                return doctors;
            }
            else return null;
        }

        /// <summary>
        /// 医生端自动登录
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public DentalMedical.Model.doctors login_auto(Guid doctorId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.doctors WHERE Id=@Id and flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier)			};
            parameters[0].Value = doctorId;
            DentalMedical.Model.doctors model = new DentalMedical.Model.doctors();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            //string sql = "SELECT * FROM dbo.doctors WHERE userCode='"+userCode+"'  ";
            //DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);

                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("SELECT * FROM dbo.doctor_hospital_View ");
                strSql2.Append("WHERE Id=@Id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier)			};
                parameters2[0].Value = model.Id;
                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    model.doctor_hospital_View = DataTableList.ToList<DentalMedical.Model.doctor_hospital_View>(ds2.Tables[0]);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新医生在线状态
        /// </summary>
        /// <param name="id">医生Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        public bool update_doctor_status(Guid id, int status)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE  dbo.doctors SET  onlineStatus = @status,modifyDate=GETDATE() WHERE   Id = @Id and flag=1");
            SqlParameter[] parameters ={
                                   new SqlParameter("@Id", SqlDbType.UniqueIdentifier),		
                                       new SqlParameter("@status", SqlDbType.Int)		};
            parameters[0].Value = id;
            parameters[1].Value = status;
            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        public bool update_doctor_Info(string Id,string userName,int? sex=null,string email=null,string logo=null,string dId=null,string fCode=null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE dbo.doctors SET userRealName=@userName,modifyDate=GETDATE() ");
            if (sex !=null)
            {
                strSql.Append(" ,userSex=@sex");
            }
            if (email!=null)
            {
                strSql.Append(" ,userEmail=@email");
            }
            if (logo !=null)
            {
                strSql.Append(" ,userLogo=@logo");
            }
            strSql.Append(" WHERE Id=@Id and flag=1");
            SqlParameter[] parameters ={
                                   new SqlParameter("@userName", SqlDbType.VarChar),		
                                       new SqlParameter("@sex", SqlDbType.Int)	,		
                                       new SqlParameter("@email", SqlDbType.VarChar),		
                                       new SqlParameter("@logo", SqlDbType.VarChar),		
                                       new SqlParameter("@Id", SqlDbType.UniqueIdentifier)	};
            parameters[0].Value = userName;
            parameters[1].Value = sex;
            parameters[2].Value = email;
            parameters[3].Value = logo;
            parameters[4].Value = new Guid(Id);
            int result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// 输入工厂邀请码
        /// </summary>
        /// <param name="Id">医生Id</param>
        /// <param name="fCode">邀请码</param>
        /// <returns></returns>
        public int update_F_Code(string Id, string fCode)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.factory WHERE invit_code=@fCode and flag=1");
            SqlParameter[] parameters = { new SqlParameter("@fCode", SqlDbType.VarChar) };
            parameters[0].Value = fCode;
            DentalMedical.Model.factory model = new DentalMedical.Model.factory();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                factory factory = new factory();
                model = factory.DataRowToModel(ds.Tables[0].Rows[0]);
                if (model != null)
                {
                    DentalMedical.Model.FD_relation fd = new Model.FD_relation();
                    fd.doctor_Id = new Guid(Id);
                    fd.factory_Id = model.Id;
                    fd.createId = new Guid(Id);
                    fd.cRemark = "医生绑定工厂！";
                    FD_relation fd_dll = new FD_relation();
                    bool row= fd_dll.Add(fd);
                    if (row)
                    {
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("UPDATE dbo.doctors SET f_invit_code=@fCode,modifyDate=GETDATE() WHERE Id=@Id and flag=1");
                        SqlParameter[] parameters2 = { new SqlParameter("@Id", SqlDbType.UniqueIdentifier), new SqlParameter("@fCode", SqlDbType.VarChar) };
                        parameters2[0].Value = new Guid(Id);
                        parameters2[1].Value = fCode;
                        result = DbHelperSQL.ExecuteSql(strSql2.ToString(), parameters2);
                        if (result > 0)
                            return 1;//更新成功
                        else return 0;//更新失败
                    }
                    else return 0;//绑定失败

                }
            }
            
                return -1;//f码不存在
            
         
           
        }

        /// <summary>
        /// 授权认证
        /// </summary>
        /// <param name="certId">认证Id</param>
        /// <param name="doctorId">技师Id</param>
        /// <param name="Pid">授权医生Id</param>
        /// <returns></returns>
        public int authorize_technician(Guid certId, Guid doctorId,Guid Pid)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"INSERT  INTO dbo.doctor_certification
        ( Id ,
          doctor_Id ,
          userHospital ,
          userDepartment ,
          work_Card ,
          status ,
          dh_logo ,
          isdefault ,
          orderId ,
          createDate ,
          createId ,
          modifyDate ,
          modifyId ,
          flag
        )
        SELECT  NEWID() ,
                @doctor_Id ,
                userHospital ,
                userDepartment ,
                work_Card ,
                2 ,
                dh_logo ,
                isdefault ,
                orderId ,
                GETDATE() ,
                @PId ,
                GETDATE() ,
                @PId,1
        FROM    dbo.doctor_certification WHERE Id=@Id  

        UPDATE  dbo.doctor_certification
        SET     status = 3
        WHERE   Id = @Id");
            SqlParameter[] parameters = { new SqlParameter("@Id", SqlDbType.UniqueIdentifier), new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier), new SqlParameter("@PId", SqlDbType.UniqueIdentifier) };
            parameters[0].Value = certId;
            parameters[1].Value = doctorId;
            parameters[2].Value = Pid;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;
        }

        /// <summary>
        /// 获取注册医生数量
        /// </summary>
        /// <returns></returns>
        public int get_doctor_num()
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  COUNT(*) * 100 + 1+COUNT(*)  FROM    dbo.doctors where flag=1");
            result = (int)DbHelperSQL.GetSingle(strSql.ToString());
            return result;
        }

        /// <summary>
        /// 更新认证授权状态
        /// </summary>
        /// <param name="dcId"></param>
        /// <returns></returns>
        public int update_dcStatus(Guid dcId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"  UPDATE  dbo.doctor_certification
        SET     status = 3
        WHERE   Id = @Id");
            SqlParameter[] parameters = { new SqlParameter("@Id", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = dcId;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 预约专家界面查找医生
        /// </summary>
        /// <param name="codeid">区号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.search_doctor> search_doctor(string codeid)
        {
            StringBuilder strSql = new StringBuilder();
            List<DentalMedical.Model.search_doctor> searchdoctor = new List<Model.search_doctor>();
            strSql.Append(@"SELECT  h.Id AS hospitalId ,
                            h.hospitalName ,
                            h.hospitalAddress ,
                            h.hospitalTel ,
                            d.Id AS doctorId ,
                            d.userRealName ,
                            d.userTel ,
                            d.userLogo
                    FROM    dbo.hospitals h
                            RIGHT JOIN dbo.doctor_certification dc ON dc.userHospital = h.Id
                                                                      AND dc.flag = 1
                            RIGHT JOIN dbo.doctors d ON d.Id = dc.doctor_Id
                    WHERE   hospitalCode = @codeid");

            SqlParameter[] parameters = { new SqlParameter("@codeid", SqlDbType.VarChar) };
            parameters[0].Value = codeid;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                searchdoctor = DataTableList.ToList<DentalMedical.Model.search_doctor>(ds.Tables[0]);
            }
            return searchdoctor;
        }

        /// <summary>
        /// 绑定PID
        /// </summary>
        /// <param name="id">医生Id</param>
        /// <param name="status">在线状态</param>
        /// <returns></returns>
        public bool update_doctor_weixin(string userCode,string wenxin)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE  dbo.doctors
                            SET     doctor_Id = @wenxin
                            WHERE   userCode = @userCode");
            SqlParameter[] parameters ={
                                   new SqlParameter("@wenxin", SqlDbType.VarChar),		
                                       new SqlParameter("@userCode", SqlDbType.VarChar)		};
            parameters[0].Value = wenxin;
            parameters[1].Value = userCode;
            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// 根据微信获取医生基本信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public DentalMedical.Model.doctors Query_Code_weixin(string openId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.doctors");
            strSql.Append(" WHERE doctor_Id= @openId and flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@openId", SqlDbType.VarChar)			};
            parameters[0].Value = openId;
            DentalMedical.Model.doctors model = new DentalMedical.Model.doctors();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            //string sql = "SELECT * FROM dbo.doctors WHERE userCode='"+userCode+"'  ";
            //DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(ds.Tables[0].Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 重置医生密码
        /// </summary>
        /// <param name="usercode">医生账号</param>
        /// <returns></returns>
        public bool reset_pwd(string usercode)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE  dbo.doctors
                            SET     userPwd = @userPwd ,
                                    orderId = 2
                            WHERE   userCode = @userCode");
            SqlParameter[] parameters = {
					new SqlParameter("@userCode", SqlDbType.VarChar),
                                       new SqlParameter("@userPwd", SqlDbType.VarChar) };
            parameters[0].Value = usercode;
            parameters[0].Value = DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt("123456");
            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
                return true;
            else return false;
        }

        /// <summary>
        /// 修改医生密码
        /// </summary>
        /// <param name="usercode">医生账号</param>
        /// <returns></returns>
        public bool modify_pwd(string usercode,string userpwd)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE  dbo.doctors
                            SET     userPwd = @userPwd ,
                                    orderId = 1
                            WHERE   userCode = @userCode");
            SqlParameter[] parameters = {
					new SqlParameter("@userCode", SqlDbType.VarChar),
                                       new SqlParameter("@userPwd", SqlDbType.VarChar) };
            parameters[0].Value = usercode;
            parameters[1].Value = DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(userpwd);
            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (result > 0)
                return true;
            else return false;
        }
		#endregion  ExtensionMethod
	}
}

