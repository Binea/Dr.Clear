using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;//Please add references
namespace DentalMedical.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:patientInfo
    /// </summary>
    public partial class patientInfo : IpatientInfo
    {
        public patientInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string patientCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from patientInfo");
            strSql.Append(" WHERE patientCode=@patientCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@patientCode", SqlDbType.VarChar)			};
            parameters[0].Value = patientCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_weixin(string weixin)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from patientInfo");
            strSql.Append(" WHERE weixin=@weixin ");
            SqlParameter[] parameters = {
					new SqlParameter("@weixin", SqlDbType.VarChar)			};
            parameters[0].Value = weixin;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DentalMedical.Model.patientInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into patientInfo(");
            strSql.Append("Id,weixin,patientCode,patientPwd,createDate,createId,flag,patientTel)");
            strSql.Append(" values (");
            strSql.Append("@Id,@weixin,@patientCode,@patientPwd,GETDATE(),@createId,@flag,@patientTel)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@weixin", SqlDbType.VarChar),
					new SqlParameter("@patientCode", SqlDbType.VarChar),
                    new SqlParameter("@patientPwd", SqlDbType.VarChar),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@flag", SqlDbType.Int),
                                        new SqlParameter("@patientTel", SqlDbType.VarChar)};
            Guid id = Guid.NewGuid();
            parameters[0].Value = id;
            parameters[1].Value = model.weixin;
            parameters[2].Value = model.patientCode;
            if (string.IsNullOrEmpty(model.patientPwd))
            {
                parameters[3].Value = null;
            }
            else
            { parameters[3].Value = DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(model.patientPwd);  }
            parameters[4].Value = Guid.Empty;
            parameters[5].Value = 1;
            parameters[6].Value = model.patientCode;
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
        public bool Update(DentalMedical.Model.patientInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update patientInfo set ");
            strSql.Append("weixin=@weixin,");
            strSql.Append("patientName=@patientName,");
            strSql.Append("patientSex=@patientSex,");
            strSql.Append("patientTel=@patientTel,");
            strSql.Append("patientEmail=@patientEmail,");
            strSql.Append("patientBirthday=@patientBirthday,");
            strSql.Append("patientAddress=@patientAddress,");
            strSql.Append("cRemark=@cRemark,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("createId=@createId,");
            strSql.Append("modifyDate=@modifyDate,");
            strSql.Append("modifyId=@modifyId,");
            strSql.Append("flag=@flag");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@weixin", SqlDbType.VarChar,-1),
					new SqlParameter("@patientName", SqlDbType.VarChar,50),
					new SqlParameter("@patientSex", SqlDbType.Int),
					new SqlParameter("@patientTel", SqlDbType.VarChar,20),
					new SqlParameter("@patientEmail", SqlDbType.VarChar,50),
					new SqlParameter("@patientBirthday", SqlDbType.DateTime),
					new SqlParameter("@patientAddress", SqlDbType.VarChar,500),
					new SqlParameter("@cRemark", SqlDbType.VarChar,250),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@patientCode", SqlDbType.VarChar,25)};
            parameters[0].Value = model.weixin;
            parameters[1].Value = model.patientName;
            parameters[2].Value = model.patientSex;
            parameters[3].Value = model.patientTel;
            parameters[4].Value = model.patientEmail;
            parameters[5].Value = model.patientBirthday;
            parameters[6].Value = model.patientAddress;
            parameters[7].Value = model.cRemark;
            parameters[8].Value = model.createDate;
            parameters[9].Value = model.createId;
            parameters[10].Value = model.modifyDate;
            parameters[11].Value = model.modifyId;
            parameters[12].Value = model.flag;
            parameters[13].Value = model.Id;
            parameters[14].Value = model.patientCode;

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
            strSql.Append("delete from patientInfo ");
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
            strSql.Append("delete from patientInfo ");
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
        public DentalMedical.Model.patientInfo GetModel(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,weixin,patientCode,patientName,patientSex,patientTel,patientEmail,patientBirthday,patientAddress,cRemark,createDate,createId,modifyDate,modifyId,flag from patientInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = Id;

            DentalMedical.Model.patientInfo model = new DentalMedical.Model.patientInfo();
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
        public DentalMedical.Model.patientInfo DataRowToModel(DataRow row)
        {
            DentalMedical.Model.patientInfo model = new DentalMedical.Model.patientInfo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = new Guid(row["Id"].ToString());
                }
                if (row["weixin"] != null)
                {
                    model.weixin = row["weixin"].ToString();
                }
                if (row["patientCode"] != null)
                {
                    model.patientCode = row["patientCode"].ToString();
                }
                if (row["patientPwd"] != null)
                {
                    model.patientPwd = row["patientPwd"].ToString();
                }
                if (row["patientName"] != null)
                {
                    model.patientName = row["patientName"].ToString();
                }
                if (row["patientSex"] != null && row["patientSex"].ToString() != "")
                {
                    model.patientSex = int.Parse(row["patientSex"].ToString());
                }
                if (row["patientTel"] != null)
                {
                    model.patientTel = row["patientTel"].ToString();
                }
                if (row["patientEmail"] != null)
                {
                    model.patientEmail = row["patientEmail"].ToString();
                }
                if (row["patientBirthday"] != null && row["patientBirthday"].ToString() != "")
                {
                    model.patientBirthday = DateTime.Parse(row["patientBirthday"].ToString());
                }
                if (row["patientAddress"] != null)
                {
                    model.patientAddress = row["patientAddress"].ToString();
                }
                if (row["patientVocation"] != null)
                {
                    model.patientVocation = row["patientVocation"].ToString();
                }
                if (row["patientLogo"] != null)
                {
                    model.patientLogo = row["patientLogo"].ToString();
                }
                if (row["nickname"] != null)
                {
                    model.nickname = row["nickname"].ToString();
                }
                if (row["HeadImgUrl"] != null)
                {
                    model.HeadImgUrl = row["HeadImgUrl"].ToString();
                }
                if (row["onlineStatus"] != null && row["onlineStatus"].ToString() != "")
                {
                    model.onlineStatus = int.Parse(row["onlineStatus"].ToString());
                }
                if (row["cRemark"] != null)
                {
                    model.cRemark = row["cRemark"].ToString();
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
            strSql.Append("select Id,weixin,patientCode,patientName,patientSex,patientTel,patientEmail,patientBirthday,patientAddress,cRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM patientInfo ");
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
            strSql.Append(" Id,weixin,patientCode,patientName,patientSex,patientTel,patientEmail,patientBirthday,patientAddress,cRemark,createDate,createId,modifyDate,modifyId,flag ");
            strSql.Append(" FROM patientInfo ");
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
            strSql.Append("select count(1) FROM patientInfo ");
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
            strSql.Append(")AS Row, T.*  from patientInfo T ");
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
            parameters[0].Value = "patientInfo";
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
      /// 根据电话更新数据中的微信号
      /// </summary>
      /// <param name="weixin"></param>
      /// <param name="tel"></param>
      /// <returns></returns>
        public bool Update_weixin(string weixin,string tel)
        {
            
            string strSql = @"UPDATE  dbo.patientInfo
                        SET     weixin = '"+weixin+@"'
                        WHERE   patientCode = '"+tel+@"'
                                AND flag = 1";
            int rows = DbHelperSQL.ExecuteSql(strSql);
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
        ///  根据账号查询信息是否存在
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        public DentalMedical.Model.patientInfo Query_Code(string patientCode, string pwd=null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.patientInfo");
            strSql.Append(" WHERE patientCode=@patientCode AND flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@patientCode", SqlDbType.VarChar)			};
            parameters[0].Value = patientCode;
            DentalMedical.Model.patientInfo model = new DentalMedical.Model.patientInfo();
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
        /// <param name="patientInfo"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DentalMedical.Model.patientInfo judge_Pwd(DentalMedical.Model.patientInfo patientInfo, string pwd)
        {
            if (DentalMedical.Common.DEncrypt.DESEncrypt.Encrypt(pwd).Equals(patientInfo.patientPwd))
            {

                return patientInfo;
            }
            else return null;
        }


        /// <summary>
        /// 更新病人信息
        /// </summary>
        public bool Update_patientInfo(DentalMedical.Model.patientInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update patientInfo set ");
            strSql.Append("patientName=@patientName,");
            strSql.Append("patientSex=@patientSex,");
            strSql.Append("patientEmail=@patientEmail,");
            strSql.Append("patientBirthday=@patientBirthday,");
            strSql.Append("patientVocation=@patientVocation,");
            strSql.Append("modifyDate=GETDATE(),");
            strSql.Append("modifyId=@modifyId ");
            strSql.Append(" where Id=@Id and flag=1");
            SqlParameter[] parameters = {
					new SqlParameter("@patientName", SqlDbType.VarChar),
					new SqlParameter("@patientSex", SqlDbType.Int),
					new SqlParameter("@patientEmail", SqlDbType.VarChar),
					new SqlParameter("@patientBirthday", SqlDbType.DateTime),
					new SqlParameter("@patientVocation", SqlDbType.VarChar),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.patientName;
            parameters[1].Value = model.patientSex;
            parameters[2].Value = model.patientEmail;
            parameters[3].Value = model.patientBirthday;
            parameters[4].Value = model.patientVocation;
            parameters[5].Value = model.modifyId;
            parameters[6].Value = model.Id;

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
        ///  根据账号查询信息是否存在
        /// </summary>
        /// <param name="userCode">用户账号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        public  DentalMedical.Model.patientInfo Query_weixin(string weixin)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.patientInfo WHERE weixin=@weixin");
            SqlParameter[] parameters = {
					new SqlParameter("@weixin", SqlDbType.VarChar)			};
            parameters[0].Value = weixin;
            DentalMedical.Model.patientInfo model = new DentalMedical.Model.patientInfo();
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
        /// 绑定微信账号
        /// </summary>
        public bool Update_weixin(string openID,string nickName,string HeadImgUrl,string patientCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE  dbo.patientInfo
                            SET     weixin = @weixin ,
                                    nickname = @nickname ,
                                    HeadImgUrl = @HeadImgUrl
                            WHERE   patientCode = @patientCode");
         
            SqlParameter[] parameters = {
					new SqlParameter("@weixin", SqlDbType.VarChar),
					new SqlParameter("@nickname", SqlDbType.VarChar),
					new SqlParameter("@HeadImgUrl", SqlDbType.VarChar),new SqlParameter("@patientCode", SqlDbType.VarChar)};
            parameters[0].Value = openID;
            parameters[1].Value = nickName;
            parameters[2].Value = HeadImgUrl;
            parameters[3].Value = patientCode;

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

