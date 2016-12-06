using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
using DentalMedical.Common;
namespace DentalMedical.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:designers
    /// </summary>
    public partial class designers : Idesigners
    {
        public designers()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from designers");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DentalMedical.Model.designers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into designers(");
            strSql.Append("Id,userCode,userTel,userPwd,userEmail,userKey,userPetName,userLogo,userRealName,userSex,userBirthday,userAddress,userWorkYears,userSchool,userBlog,onlineStatus,f_invit_code,doctor_Id,orderId,userRemark,createDate,createId,modifyDate,modifyId,flag)");
            strSql.Append(" values (");
            strSql.Append("@Id,@userCode,@userTel,@userPwd,@userEmail,@userKey,@userPetName,@userLogo,@userRealName,@userSex,@userBirthday,@userAddress,@userWorkYears,@userSchool,@userBlog,@onlineStatus,@f_invit_code,@doctor_Id,@orderId,@userRemark,@createDate,@createId,@modifyDate,@modifyId,@flag)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userCode", SqlDbType.VarChar,20),
					new SqlParameter("@userTel", SqlDbType.VarChar,20),
					new SqlParameter("@userPwd", SqlDbType.VarChar,500),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@userKey", SqlDbType.Int,4),
					new SqlParameter("@userPetName", SqlDbType.VarChar,50),
					new SqlParameter("@userLogo", SqlDbType.VarChar,-1),
					new SqlParameter("@userRealName", SqlDbType.VarChar,25),
					new SqlParameter("@userSex", SqlDbType.Int,4),
					new SqlParameter("@userBirthday", SqlDbType.DateTime),
					new SqlParameter("@userAddress", SqlDbType.VarChar,-1),
					new SqlParameter("@userWorkYears", SqlDbType.Int,4),
					new SqlParameter("@userSchool", SqlDbType.Int,4),
					new SqlParameter("@userBlog", SqlDbType.VarChar,-1),
					new SqlParameter("@onlineStatus", SqlDbType.Int,4),
					new SqlParameter("@f_invit_code", SqlDbType.VarChar,6),
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@userRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.userCode;
            parameters[2].Value = model.userTel;
            parameters[3].Value = model.userPwd;
            parameters[4].Value = model.userEmail;
            parameters[5].Value = model.userKey;
            parameters[6].Value = model.userPetName;
            parameters[7].Value = model.userLogo;
            parameters[8].Value = model.userRealName;
            parameters[9].Value = model.userSex;
            parameters[10].Value = model.userBirthday;
            parameters[11].Value = model.userAddress;
            parameters[12].Value = model.userWorkYears;
            parameters[13].Value = model.userSchool;
            parameters[14].Value = model.userBlog;
            parameters[15].Value = model.onlineStatus;
            parameters[16].Value = model.f_invit_code;
            parameters[17].Value = Guid.NewGuid();
            parameters[18].Value = model.orderId;
            parameters[19].Value = model.userRemark;
            parameters[20].Value = model.createDate;
            parameters[21].Value = Guid.NewGuid();
            parameters[22].Value = model.modifyDate;
            parameters[23].Value = Guid.NewGuid();
            parameters[24].Value = model.flag;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(DentalMedical.Model.designers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update designers set ");
            strSql.Append("userCode=@userCode,");
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
            strSql.Append("doctor_Id=@doctor_Id,");
            strSql.Append("orderId=@orderId,");
            strSql.Append("userRemark=@userRemark,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createId=@createId,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("modifyId=@modifyId,");
            strSql.Append("flag=@flag");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@userCode", SqlDbType.VarChar,20),
					new SqlParameter("@userTel", SqlDbType.VarChar,20),
					new SqlParameter("@userPwd", SqlDbType.VarChar,500),
					new SqlParameter("@userEmail", SqlDbType.VarChar,50),
					new SqlParameter("@userKey", SqlDbType.Int,4),
					new SqlParameter("@userPetName", SqlDbType.VarChar,50),
					new SqlParameter("@userLogo", SqlDbType.VarChar,-1),
					new SqlParameter("@userRealName", SqlDbType.VarChar,25),
					new SqlParameter("@userSex", SqlDbType.Int,4),
					new SqlParameter("@userBirthday", SqlDbType.DateTime),
					new SqlParameter("@userAddress", SqlDbType.VarChar,-1),
					new SqlParameter("@userWorkYears", SqlDbType.Int,4),
					new SqlParameter("@userSchool", SqlDbType.Int,4),
					new SqlParameter("@userBlog", SqlDbType.VarChar,-1),
					new SqlParameter("@onlineStatus", SqlDbType.Int,4),
					new SqlParameter("@f_invit_code", SqlDbType.VarChar,6),
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderId", SqlDbType.Int,4),
					new SqlParameter("@userRemark", SqlDbType.VarChar,200),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.userCode;
            parameters[1].Value = model.userTel;
            parameters[2].Value = model.userPwd;
            parameters[3].Value = model.userEmail;
            parameters[4].Value = model.userKey;
            parameters[5].Value = model.userPetName;
            parameters[6].Value = model.userLogo;
            parameters[7].Value = model.userRealName;
            parameters[8].Value = model.userSex;
            parameters[9].Value = model.userBirthday;
            parameters[10].Value = model.userAddress;
            parameters[11].Value = model.userWorkYears;
            parameters[12].Value = model.userSchool;
            parameters[13].Value = model.userBlog;
            parameters[14].Value = model.onlineStatus;
            parameters[15].Value = model.f_invit_code;
            parameters[16].Value = model.doctor_Id;
            parameters[17].Value = model.orderId;
            parameters[18].Value = model.userRemark;
            parameters[19].Value = model.createDate;
            parameters[20].Value = model.createId;
            parameters[21].Value = model.modifyDate;
            parameters[22].Value = model.modifyId;
            parameters[23].Value = model.flag;
            parameters[24].Value = model.Id;

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
            strSql.Append("delete from designers ");
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
            strSql.Append("delete from designers ");
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
        public DentalMedical.Model.designers GetModel(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,userCode,userTel,userPwd,userEmail,userKey,userPetName,userLogo,userRealName,userSex,userBirthday,userAddress,userWorkYears,userSchool,userBlog,onlineStatus,f_invit_code,doctor_Id,orderId,userRemark,createDate,createId,modifyDate,modifyId,flag from designers ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            DentalMedical.Model.designers model = new DentalMedical.Model.designers();
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
        public DentalMedical.Model.designers DataRowToModel(DataRow row)
        {
            DentalMedical.Model.designers model = new DentalMedical.Model.designers();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = new Guid(row["Id"].ToString());
                }
                if (row["userCode"] != null)
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
                if (row["doctor_Id"] != null && row["doctor_Id"].ToString() != "")
                {
                    model.doctor_Id = new Guid(row["doctor_Id"].ToString());
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
            strSql.Append("select Id,userCode,userTel,userPwd,userEmail,userKey,userPetName,userLogo,userRealName,userSex,userBirthday,userAddress,userWorkYears,userSchool,userBlog,onlineStatus,f_invit_code,doctor_Id,orderId,userRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM designers ");
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
            strSql.Append(" Id,userCode,userTel,userPwd,userEmail,userKey,userPetName,userLogo,userRealName,userSex,userBirthday,userAddress,userWorkYears,userSchool,userBlog,onlineStatus,f_invit_code,doctor_Id,orderId,userRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM designers ");
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
            strSql.Append("select count(1) FROM designers ");
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
            strSql.Append(")AS Row, T.*  from designers T ");
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
            parameters[0].Value = "designers";
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
        ///  根据账号查询信息是否存在
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        public DentalMedical.Model.designers Query_Code(string userCode, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.designers");
            strSql.Append(" WHERE userCode= @userCode and flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@userCode", SqlDbType.VarChar)			};
            parameters[0].Value = userCode;
            DentalMedical.Model.designers model = new DentalMedical.Model.designers();
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
        public DentalMedical.Model.designers judge_Pwd(DentalMedical.Model.designers designers, string pwd)
        {
            if (DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(pwd).Equals(designers.userPwd))
            {

                return designers;
            }
            else return null;
        }


        /// <summary>
        /// 更新设计组信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        public bool update_designer_Info(string Id, string userName, int? sex = null, string email = null, string logo = null, string dId = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE dbo.designers SET userRealName=@userName,modifyDate=GETDATE() ");
            if (sex != null)
            {
                strSql.Append(" ,userSex=@sex");
            }
            if (email != null)
            {
                strSql.Append(" ,userEmail=@email");
            }
            if (logo != null)
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
        #endregion  ExtensionMethod
    }
}

