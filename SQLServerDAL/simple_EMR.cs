using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DentalMedical.IDAL;
using DentalMedical.DBUtility;
using System.Collections.Generic;//Please add references
using DentalMedical.Common;
using DentalMedical.DentalEnumeration;
using System.Collections;
namespace DentalMedical.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:simple_EMR
	/// </summary>
	public partial class simple_EMR:Isimple_EMR
	{
		public simple_EMR()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Id,string EMR_Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from simple_EMR");
			strSql.Append(" where Id=@Id and EMR_Code=@EMR_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25)			};
			parameters[0].Value = Id;
			parameters[1].Value = EMR_Code;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DentalMedical.Model.simple_EMR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into simple_EMR(");
			strSql.Append("Id,EMR_Code,patient_Name,patient_Age,patient_Sex,patient_Tel,patient_WeChatCode,main_suit,allergy_history,Medical_history,therapeutic_schedule,doctorRemark,cRemark,emr_status,confirm_time,processing_time,processing_requirement,order_time,pay_time,production_time,delivery_time,end_time,createDate,createId,flag)");
			strSql.Append(" values (");
			strSql.Append("@Id,@EMR_Code,@patient_Name,@patient_Age,@patient_Sex,@patient_Tel,@patient_WeChatCode,@main_suit,@allergy_history,@Medical_history,@therapeutic_schedule,@doctorRemark,@cRemark,@emr_status,@confirm_time,@processing_time,@processing_requirement,@order_time,@pay_time,@production_time,@delivery_time,@end_time,GETDATE(),@createId,@flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
					new SqlParameter("@patient_Name", SqlDbType.VarChar),
					new SqlParameter("@patient_Age", SqlDbType.VarChar),
					new SqlParameter("@patient_Sex", SqlDbType.Int),
					new SqlParameter("@patient_Tel", SqlDbType.VarChar),
					new SqlParameter("@patient_WeChatCode", SqlDbType.VarChar),
					new SqlParameter("@main_suit", SqlDbType.VarChar),
					new SqlParameter("@allergy_history", SqlDbType.VarChar),
					new SqlParameter("@Medical_history", SqlDbType.VarChar),
					new SqlParameter("@therapeutic_schedule", SqlDbType.VarChar),
					new SqlParameter("@doctorRemark", SqlDbType.VarChar),
					new SqlParameter("@cRemark", SqlDbType.VarChar),
					new SqlParameter("@emr_status", SqlDbType.Int),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@processing_time", SqlDbType.DateTime),
					new SqlParameter("@processing_requirement", SqlDbType.VarChar),
					new SqlParameter("@order_time", SqlDbType.DateTime),
					new SqlParameter("@pay_time", SqlDbType.DateTime),
					new SqlParameter("@production_time", SqlDbType.DateTime),
					new SqlParameter("@delivery_time", SqlDbType.DateTime),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.EMR_Code;
			parameters[2].Value = model.patient_Name;
			parameters[3].Value = model.patient_Age;
			parameters[4].Value = model.patient_Sex;
			parameters[5].Value = model.patient_Tel;
			parameters[6].Value = model.patient_WeChatCode;
			parameters[7].Value = model.main_suit;
			parameters[8].Value = model.allergy_history;
			parameters[9].Value = model.Medical_history;
			parameters[10].Value = model.therapeutic_schedule;
			parameters[11].Value = model.doctorRemark;
			parameters[12].Value = model.cRemark;
			parameters[13].Value = model.emr_status;
			parameters[14].Value = model.confirm_time;
			parameters[15].Value = model.processing_time;
			parameters[16].Value = model.processing_requirement;
			parameters[17].Value = model.order_time;
			parameters[18].Value = model.pay_time;
			parameters[19].Value = model.production_time;
			parameters[20].Value = model.delivery_time;
			parameters[21].Value = model.end_time;
			parameters[22].Value = model.createId;
			parameters[23].Value = model.flag;

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
		public bool Update(DentalMedical.Model.simple_EMR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update simple_EMR set ");
			strSql.Append("patient_Name=@patient_Name,");
			strSql.Append("patient_Age=@patient_Age,");
			strSql.Append("patient_Sex=@patient_Sex,");
			strSql.Append("patient_Tel=@patient_Tel,");
			strSql.Append("patient_WeChatCode=@patient_WeChatCode,");
			strSql.Append("main_suit=@main_suit,");
			strSql.Append("allergy_history=@allergy_history,");
			strSql.Append("Medical_history=@Medical_history,");
			strSql.Append("therapeutic_schedule=@therapeutic_schedule,");
			strSql.Append("doctorRemark=@doctorRemark,");
			strSql.Append("cRemark=@cRemark,");
			strSql.Append("emr_status=@emr_status,");
			strSql.Append("confirm_time=@confirm_time,");
			strSql.Append("processing_time=@processing_time,");
			strSql.Append("processing_requirement=@processing_requirement,");
			strSql.Append("order_time=@order_time,");
			strSql.Append("pay_time=@pay_time,");
			strSql.Append("production_time=@production_time,");
			strSql.Append("delivery_time=@delivery_time,");
			strSql.Append("end_time=@end_time,");
			strSql.Append("createDate=@createDate,");
			strSql.Append("createId=@createId,");
			strSql.Append("modifyDate=@modifyDate,");
			strSql.Append("modifyId=@modifyId,");
			strSql.Append("flag=@flag");
			strSql.Append(" where Id=@Id and EMR_Code=@EMR_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@patient_Name", SqlDbType.VarChar,25),
					new SqlParameter("@patient_Age", SqlDbType.VarChar,25),
					new SqlParameter("@patient_Sex", SqlDbType.Int,4),
					new SqlParameter("@patient_Tel", SqlDbType.VarChar,25),
					new SqlParameter("@patient_WeChatCode", SqlDbType.VarChar,25),
					new SqlParameter("@main_suit", SqlDbType.VarChar,-1),
					new SqlParameter("@allergy_history", SqlDbType.VarChar,-1),
					new SqlParameter("@Medical_history", SqlDbType.VarChar,-1),
					new SqlParameter("@therapeutic_schedule", SqlDbType.VarChar,-1),
					new SqlParameter("@doctorRemark", SqlDbType.VarChar,-1),
					new SqlParameter("@cRemark", SqlDbType.VarChar,500),
					new SqlParameter("@emr_status", SqlDbType.Int,4),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@processing_time", SqlDbType.DateTime),
					new SqlParameter("@processing_requirement", SqlDbType.VarChar,-1),
					new SqlParameter("@order_time", SqlDbType.DateTime),
					new SqlParameter("@pay_time", SqlDbType.DateTime),
					new SqlParameter("@production_time", SqlDbType.DateTime),
					new SqlParameter("@delivery_time", SqlDbType.DateTime),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@createDate", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@modifyDate", SqlDbType.DateTime),
					new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25)};
			parameters[0].Value = model.patient_Name;
			parameters[1].Value = model.patient_Age;
			parameters[2].Value = model.patient_Sex;
			parameters[3].Value = model.patient_Tel;
			parameters[4].Value = model.patient_WeChatCode;
			parameters[5].Value = model.main_suit;
			parameters[6].Value = model.allergy_history;
			parameters[7].Value = model.Medical_history;
			parameters[8].Value = model.therapeutic_schedule;
			parameters[9].Value = model.doctorRemark;
			parameters[10].Value = model.cRemark;
			parameters[11].Value = model.emr_status;
			parameters[12].Value = model.confirm_time;
			parameters[13].Value = model.processing_time;
			parameters[14].Value = model.processing_requirement;
			parameters[15].Value = model.order_time;
			parameters[16].Value = model.pay_time;
			parameters[17].Value = model.production_time;
			parameters[18].Value = model.delivery_time;
			parameters[19].Value = model.end_time;
			parameters[20].Value = model.createDate;
			parameters[21].Value = model.createId;
			parameters[22].Value = model.modifyDate;
			parameters[23].Value = model.modifyId;
			parameters[24].Value = model.flag;
			parameters[25].Value = model.Id;
			parameters[26].Value = model.EMR_Code;

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
		public bool Delete(Guid Id,string EMR_Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from simple_EMR ");
			strSql.Append(" where Id=@Id and EMR_Code=@EMR_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25)			};
			parameters[0].Value = Id;
			parameters[1].Value = EMR_Code;

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
		/// 得到一个对象实体
		/// </summary>
		public DentalMedical.Model.simple_EMR GetModel(Guid Id,string EMR_Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,EMR_Code,patient_Name,patient_Age,patient_Sex,patient_Tel,patient_WeChatCode,main_suit,allergy_history,Medical_history,therapeutic_schedule,doctorRemark,cRemark,emr_status,confirm_time,processing_time,processing_requirement,order_time,pay_time,production_time,delivery_time,end_time,createDate,createId,modifyDate,modifyId,flag from simple_EMR ");
			strSql.Append(" where Id=@Id and EMR_Code=@EMR_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar,25)			};
			parameters[0].Value = Id;
			parameters[1].Value = EMR_Code;

			DentalMedical.Model.simple_EMR model=new DentalMedical.Model.simple_EMR();
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
		public DentalMedical.Model.simple_EMR DataRowToModel(DataRow row)
		{
			DentalMedical.Model.simple_EMR model=new DentalMedical.Model.simple_EMR();
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
				if(row["patient_Name"]!=null)
				{
					model.patient_Name=row["patient_Name"].ToString();
				}
				if(row["patient_Age"]!=null)
				{
					model.patient_Age=row["patient_Age"].ToString();
				}
				if(row["patient_Sex"]!=null && row["patient_Sex"].ToString()!="")
				{
					model.patient_Sex=int.Parse(row["patient_Sex"].ToString());
				}
				if(row["patient_Tel"]!=null)
				{
					model.patient_Tel=row["patient_Tel"].ToString();
				}
				if(row["patient_WeChatCode"]!=null)
				{
					model.patient_WeChatCode=row["patient_WeChatCode"].ToString();
				}
				if(row["main_suit"]!=null)
				{
					model.main_suit=row["main_suit"].ToString();
				}
				if(row["allergy_history"]!=null)
				{
					model.allergy_history=row["allergy_history"].ToString();
				}
				if(row["Medical_history"]!=null)
				{
					model.Medical_history=row["Medical_history"].ToString();
				}
				if(row["therapeutic_schedule"]!=null)
				{
					model.therapeutic_schedule=row["therapeutic_schedule"].ToString();
				}
				if(row["doctorRemark"]!=null)
				{
					model.doctorRemark=row["doctorRemark"].ToString();
				}
				if(row["cRemark"]!=null)
				{
					model.cRemark=row["cRemark"].ToString();
				}
				if(row["emr_status"]!=null && row["emr_status"].ToString()!="")
				{
					model.emr_status=int.Parse(row["emr_status"].ToString());
				}
                if (row["treatment_status"] != null && row["treatment_status"].ToString() != "")
                {
                    model.treatment_status = int.Parse(row["treatment_status"].ToString());
                }
				if(row["confirm_time"]!=null && row["confirm_time"].ToString()!="")
				{
					model.confirm_time=DateTime.Parse(row["confirm_time"].ToString());
				}
				if(row["processing_time"]!=null && row["processing_time"].ToString()!="")
				{
					model.processing_time=DateTime.Parse(row["processing_time"].ToString());
				}
				if(row["processing_requirement"]!=null)
				{
					model.processing_requirement=row["processing_requirement"].ToString();
				}
				if(row["order_time"]!=null && row["order_time"].ToString()!="")
				{
					model.order_time=DateTime.Parse(row["order_time"].ToString());
				}
				if(row["pay_time"]!=null && row["pay_time"].ToString()!="")
				{
					model.pay_time=DateTime.Parse(row["pay_time"].ToString());
				}
				if(row["production_time"]!=null && row["production_time"].ToString()!="")
				{
					model.production_time=DateTime.Parse(row["production_time"].ToString());
				}
				if(row["delivery_time"]!=null && row["delivery_time"].ToString()!="")
				{
					model.delivery_time=DateTime.Parse(row["delivery_time"].ToString());
				}
				if(row["end_time"]!=null && row["end_time"].ToString()!="")
				{
					model.end_time=DateTime.Parse(row["end_time"].ToString());
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
                if (row["doctor_Id"] != null && row["doctor_Id"].ToString() != "")
                {
                    model.doctor_Id = new Guid(row["doctor_Id"].ToString());
                }
                if (row["hospital_Id"] != null && row["hospital_Id"].ToString() != "")
                {
                    model.hospital_Id = new Guid(row["hospital_Id"].ToString());
                }
                if (row["de_Id"] != null && row["de_Id"].ToString() != "")
                {
                    model.de_Id = new Guid(row["de_Id"].ToString());
                }
                if (row["doctor_Name"] != null)
                {
                    model.doctor_Name = row["doctor_Name"].ToString();
                }
                if (row["doctor_tel"] != null)
                {
                    model.doctor_tel = row["doctor_tel"].ToString();
                }
                if (row["hospital_Name"] != null)
                {
                    model.hospital_Name = row["hospital_Name"].ToString();
                }
                if (row["de_Name"] != null)
                {
                    model.de_Name = row["de_Name"].ToString();
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
			strSql.Append("select Id,EMR_Code,patient_Name,patient_Age,patient_Sex,patient_Tel,patient_WeChatCode,main_suit,allergy_history,Medical_history,therapeutic_schedule,doctorRemark,cRemark,emr_status,confirm_time,processing_time,processing_requirement,order_time,pay_time,production_time,delivery_time,end_time,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM simple_EMR ");
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
			strSql.Append(" Id,EMR_Code,patient_Name,patient_Age,patient_Sex,patient_Tel,patient_WeChatCode,main_suit,allergy_history,Medical_history,therapeutic_schedule,doctorRemark,cRemark,emr_status,confirm_time,processing_time,processing_requirement,order_time,pay_time,production_time,delivery_time,end_time,createDate,createId,modifyDate,modifyId,flag ");
			strSql.Append(" FROM simple_EMR ");
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
			strSql.Append("select count(1) FROM simple_EMR ");
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
				strSql.Append("order by T.EMR_Code desc");
			}
			strSql.Append(")AS Row, T.*  from simple_EMR T ");
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
			parameters[0].Value = "simple_EMR";
			parameters[1].Value = "EMR_Code";
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
        /// 根据医生登录的账号，选的执业地，就诊状态获取emr列表
        /// </summary>
        /// <param name="dId">医生Id</param>
        /// <param name="hId">医院Id</param>
        /// <param name="treatmentStauts">状态</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> EMR_D_list(string dId, string hId, int treatmentStauts)
        {
            List<DentalMedical.Model.simple_EMR> List = new List<Model.simple_EMR>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  emr.Id ,
                            emr.EMR_Code ,
                            patient_Name ,
                            patient_Age ,
                            patient_Sex ,
                            patient_Tel ,
                            patient_WeChatCode ,
                            main_suit ,
                            allergy_history ,
                            Medical_history ,
                            therapeutic_schedule ,
                            doctorRemarkDate,
                            doctorRemark ,
                            emr.cRemark ,
                            emr_status ,
                            treatment_status,
                            confirm_time ,
                            processing_time ,
                            processing_requirement ,
                            order_time ,
                            pay_time ,
                            production_time ,
                            delivery_time ,
                            end_time ,
                            emr.createDate ,
                            emr.createId ,
                            emr.modifyDate ,
                            emr.modifyId ,
                            emr.flag ");
            strSql.Append(@" FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1 ");
            if (treatmentStauts == 4)
            {
                strSql.Append(@" WHERE   emr.flag = 1
                                AND hde.hospital_Id = @hospital_Id
                                AND hde.doctor_Id = @doctor_Id  ORDER BY emr.createDate DESC ");
            }
            else
            {
                strSql.Append(@" WHERE   emr.flag = 1
                                AND treatment_status=@treatment_status
                                AND hde.hospital_Id = @hospital_Id
                                AND hde.doctor_Id = @doctor_Id  ORDER BY emr.createDate DESC ");
            }      
            SqlParameter[] parameters = {
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier),
                                        new SqlParameter("@treatment_status", SqlDbType.Int),
                                        new SqlParameter("@hospital_Id", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = new Guid(dId);
            parameters[1].Value = treatmentStauts;
            parameters[2].Value = new Guid(hId); ;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                List = DataTableList.ToList<DentalMedical.Model.simple_EMR>(ds.Tables[0]);
                foreach (var l in List)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append(@"SELECT TOP 1
                                    [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[dental_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC

                            SELECT TOP 1
                                    ds.[Id] ,
                                    ds.[EMR_Code] ,
                                    ds.[imagePath] ,
                                    ds.[orderId] ,
                                    ds.[createDate] ,
                                    ds.[createId] ,
                                    ds.[modifyDate] ,
                                    ds.[modifyId] ,
                                    ds.[flag] ,
                                    li.express_billCode ,
                                    li.expressName
                            FROM    [dbo].[design_scheme] ds
                                    LEFT JOIN dbo.logistics_info li ON li.EMR_Code = ds.EMR_Code
                                                                       AND li.dsId = ds.Id
                                                                       AND li.flag = 1
                            WHERE   ds.EMR_Code = @EMR_Code
                                    AND ds.flag = 1
                            ORDER BY ds.createDate DESC

                            SELECT  *
                            FROM    dbo.FaceImage
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY orderId

                            SELECT  TOP 1 *
                            FROM    dbo.doctor_essays
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC

                            SELECT TOP 1
                                    [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[archiving_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC

                            SELECT TOP 1
                                    *
                            FROM    dbo.stl_d_data
                            WHERE   EMR_Code = @EMR_Code
                                    AND status = 1   AND flag = 1
                            ORDER BY createDate DESC
                    ");
                    SqlParameter[] parameters2 = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
                    parameters2[0].Value = l.EMR_Code;
                    DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        l.dental_model = DataTableList.ToList<DentalMedical.Model.dental_model>(ds2.Tables[0]);
                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        l.design_scheme = DataTableList.ToList<DentalMedical.Model.design_scheme>(ds2.Tables[1]);
                    }
                    if (ds2.Tables[2].Rows.Count > 0)
                    {
                        l.FaceImage = DataTableList.ToList<DentalMedical.Model.FaceImage>(ds2.Tables[2]);
                    }
                    if (ds2.Tables[3].Rows.Count > 0)
                    {
                        l.doctor_essays = DataTableList.ToList<DentalMedical.Model.doctor_essays>(ds2.Tables[3]);

                    }
                    if (ds2.Tables[4].Rows.Count > 0)
                    {
                        l.archiving_model = DataTableList.ToList<DentalMedical.Model.archiving_model>(ds2.Tables[4]);

                    }
                    if (ds2.Tables[5].Rows.Count > 0)
                    {
                        l.stl_d_data = DataTableList.ToList<DentalMedical.Model.stl_d_data>(ds2.Tables[5]);

                    }
                }

            }


            return List;
        }

        /// <summary>
        /// 根据厂房登录的账号 和状态 获取到病例列表
        /// </summary>
        /// <param name="fId">厂家Id</param>
        /// <param name="Status">状态</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> EMR_F_list(string fId, int Status)
        {
            StringBuilder strSql = new StringBuilder();
            if (Status != 99)
            {
                strSql.Append(@"SELECT  emr.Id ,
        emr.EMR_Code ,
        patient_Name ,
        patient_Age ,
        patient_Sex ,
        patient_Tel ,
        patient_WeChatCode ,
        main_suit ,
        allergy_history ,
        Medical_history ,
        therapeutic_schedule ,
        doctorRemarkDate,
        doctorRemark ,
        emr.cRemark ,
        emr_status ,
        confirm_time ,
        processing_time ,
        processing_requirement ,
        order_time ,
        pay_time ,
        production_time ,
        delivery_time ,
        end_time ,
        emr.createDate ,
        emr.createId ,
        emr.modifyDate ,
        emr.modifyId ,
        emr.flag,
        d.Id AS doctor_Id ,
        d.userRealName AS doctor_Name ,
        h.Id AS hospital_Id ,
        h.hospitalName AS hospital_Name");
                strSql.Append(@" FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1
        LEFT  JOIN dbo.FD_relation fe ON fe.doctor_Id = hde.doctor_Id
                                         AND fe.flag = 1 
        LEFT JOIN dbo.doctors d ON d.Id = fe.doctor_Id
                                   AND d.flag = 1
        LEFT JOIN dbo.hospitals h ON h.Id = hde.hospital_Id


        ");
                strSql.Append(@" WHERE   emr.flag = 1
        AND emr.emr_status = @emr_status
        AND fe.factory_Id = @factory_Id ORDER BY emr.createDate DESC 
 ");


            }
            else
            {
                strSql.Append(@"SELECT  emr.Id ,
        emr.EMR_Code ,
        patient_Name ,
        patient_Age ,
        patient_Sex ,
        patient_Tel ,
        patient_WeChatCode ,
        main_suit ,
        allergy_history ,
        Medical_history ,
        therapeutic_schedule ,
        doctorRemarkDate,
        doctorRemark ,
        emr.cRemark ,
        emr_status ,
        confirm_time ,
        processing_time ,
        processing_requirement ,
        order_time ,
        pay_time ,
        production_time ,
        delivery_time ,
        end_time ,
        emr.createDate ,
        emr.createId ,
        emr.modifyDate ,
        emr.modifyId ,
        emr.flag,
        d.Id AS doctor_Id ,
        d.userRealName AS doctor_Name ,
        h.Id AS hospital_Id ,
        h.hospitalName AS hospital_Name");
                strSql.Append(@" FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1
        LEFT  JOIN dbo.FD_relation fe ON fe.doctor_Id = hde.doctor_Id
                                         AND fe.flag = 1
        LEFT JOIN dbo.doctors d ON d.Id = fe.doctor_Id
                                   AND d.flag = 1
        LEFT JOIN dbo.hospitals h ON h.Id = hde.hospital_Id

 ");
                strSql.Append(@" WHERE   emr.flag = 1
          AND (emr.emr_status = 7 OR emr.emr_status = 9 OR emr.emr_status = 10 OR emr.emr_status = 11)
        AND fe.factory_Id = @factory_Id  ORDER BY emr.createDate DESC 
 ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier),
        new SqlParameter("@emr_status", SqlDbType.Int)};
            parameters[0].Value =new Guid(fId);
            parameters[1].Value = Status;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            List<DentalMedical.Model.simple_EMR> List = new List<Model.simple_EMR>(); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                List = DataTableList.ToList<DentalMedical.Model.simple_EMR>(ds.Tables[0]);
                foreach (var l in List)
                {
                    StringBuilder strsql2 = new StringBuilder();
                    strsql2.Append(@"  SELECT TOP 1
                                                ds.[Id] ,
                                                ds.[EMR_Code] ,
                                                ds.[imagePath] ,
                                                ds.[orderId] ,
                                                ds.[createDate] ,
                                                ds.[createId] ,
                                                ds.[modifyDate] ,
                                                ds.[modifyId] ,
                                                ds.[flag] ,
                                                li.express_billCode ,
                                                li.expressName
                                        FROM    [dbo].[design_scheme] ds
                                                LEFT JOIN dbo.logistics_info li ON li.EMR_Code = ds.EMR_Code
                                                                                   AND li.dsId = ds.Id
                                                                                   AND li.flag = 1
                                        WHERE   ds.EMR_Code = @EMR_Code
                                                AND ds.flag = 1
                                        ORDER BY ds.createDate DESC

                                  SELECT  *
                            FROM    dbo.FaceImage
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                                ORDER BY orderId

                            SELECT TOP 1
                                    [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[dental_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC
                                ");
                    SqlParameter[] parameters2 = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
                    parameters2[0].Value = l.EMR_Code;
                    DataSet ds2 = DbHelperSQL.Query(strsql2.ToString(),parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                       l.design_scheme= DataTableList.ToList<DentalMedical.Model.design_scheme>(ds2.Tables[0]);
                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        l.FaceImage = DataTableList.ToList<DentalMedical.Model.FaceImage>(ds2.Tables[1]);
                    }
                    if (ds2.Tables[2].Rows.Count > 0)
                    {
                        l.dental_model = DataTableList.ToList<DentalMedical.Model.dental_model>(ds2.Tables[2]);
                    }   
                }
            }
            return List;
        }

        /// <summary>
        /// 根据状态不同，更新状态
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="emrcode">病例号</param>
        /// <param name="Id">当前操作人Id</param>
        /// <param name="processing_requirement">当为加工的时候，有加工要求</param>
        /// <returns></returns>
        public int update_Emr_Status(int status, string emrcode,string Id, string processing_requirement=null,string treatmentStatus=null)
        {
            StringBuilder strSql = new StringBuilder();
            if (status == (int)EMRStatusEnum.病例已确认)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId,
                                        confirm_time = GETDATE()
                                WHERE   EMR_Code = @EMR_Code and flag=1");
               int num=  update_treatmentstatus(1,emrcode);
               if (num <= 0)
               {
                   return 0;
               }
            }
            else if (status == (int)EMRStatusEnum.加工下单)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId,
                                        processing_time = GETDATE() ,
                                        processing_requirement = @processing_requirement
                                WHERE   EMR_Code = @EMR_Code and flag=1");
            }
            else if (status == (int)EMRStatusEnum.已接单)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId,
                                        order_time = GETDATE()
                                WHERE   EMR_Code = @EMR_Code and flag=1");
            }
            else if (status == (int)EMRStatusEnum.已付款)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId,
                                        pay_time=GETDATE()
                                WHERE   EMR_Code = @EMR_Code and flag=1");
            }
            else if (status == (int)EMRStatusEnum.已排产)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId,
                                        production_time = GETDATE()
                                WHERE   EMR_Code = @EMR_Code and flag=1");
            }
            else if (status == (int)EMRStatusEnum.已发货)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId,
                                        delivery_time = GETDATE()
                                WHERE   EMR_Code = @EMR_Code and flag=1
                                
                                ");
            }
            else if (status == (int)EMRStatusEnum.病例结束 || status == (int)EMRStatusEnum.放弃)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId
                                WHERE   EMR_Code = @EMR_Code and flag=1");
                int num = update_treatmentstatus(2, emrcode);
                if (num <= 0)
                {
                    return 0;
                }
            }
            else if (status == (int)EMRStatusEnum.新建)
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId
                                WHERE   EMR_Code = @EMR_Code and flag=1
                                
                                UPDATE  dbo.dental_model
                                SET     flag = 0
                                WHERE   EMR_Code = @EMR_Code    
                                
                                UPDATE  dbo.design_scheme
                                SET     flag = 0
                                WHERE   EMR_Code = @EMR_Code

                                UPDATE  dbo.stl_d_data
                                SET     flag = 0
                                WHERE   EMR_Code = @EMR_Code
                            ");
                int num = update_treatmentstatus(0, emrcode);             
                if (num <= 0)
                {
                    return 0;
                }
            }
            else
            {
                strSql.Append(@"UPDATE  dbo.simple_EMR
                                SET     emr_status = @emr_status ,
                                        modifyDate=GETDATE(),
                                        modifyId=@modifyId
                                WHERE   EMR_Code = @EMR_Code and flag=1");
            }
            DataSet ds = new DataSet();
            int result = 0;
            if (processing_requirement != null)
            {
                SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
                                           new SqlParameter("@emr_status", SqlDbType.Int), 
                                             new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier), 
                                               new SqlParameter("@processing_requirement", SqlDbType.VarChar)
                                            };
                parameters[0].Value = emrcode;
                parameters[1].Value = status;
                parameters[2].Value = new Guid(Id);
                parameters[3].Value = processing_requirement;
                result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            else
            {
                    SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
                                           new SqlParameter("@emr_status", SqlDbType.Int), 
                                             new SqlParameter("@modifyId", SqlDbType.UniqueIdentifier)
                                            };
                parameters[0].Value = emrcode;
                parameters[1].Value = status;
                parameters[2].Value = new Guid(Id);
                result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }


            return result;
        }

        /// <summary>
        /// 更新医生随笔
        /// </summary>
        /// <param name="emrCode">病例编号</param>
        /// <param name="remark">医生随笔</param>
        /// <returns></returns>
        public int update_doctorRemark(string emrCode, string remark, string remarkdate, string doctorId)
        {
            string strSql = @"INSERT  INTO dbo.doctor_essays
                            ( Id ,
                              EMR_Code ,
                              doctorRemarkDate ,
                              doctorRemark ,
                              createDate ,
                              createId ,
                              flag
                            )
                    VALUES  ( NEWID() , -- Id - uniqueidentifier
                              '"+emrCode+@"' , -- EMR_Code - varchar(25)
                              '" + remarkdate + @"' , -- doctorRemarkDate - varchar(50)
                              '"+remark+@"' , -- doctorRemark - varchar(max)
                              GETDATE() , -- createDate - datetime
                              '"+doctorId+@"' , -- createId - uniqueidentifier        
                              1  -- flag - int
                            )";
            int result = DbHelperSQL.ExecuteSql(strSql);
            return result;
        }

        /// <summary>
        /// 根据医生登录的账号，选的执业地，病例状态,搜索条件获取emr列表
        /// </summary>
        /// <param name="dId">医生Id</param>
        /// <param name="hId">医院Id</param>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <param name="strwhere">搜索条件</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> find_Emr_d(string dId, string hId, int treatmentstatus, string strwhere)
        {
            List<DentalMedical.Model.simple_EMR> List = new List<Model.simple_EMR>();


            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  emr.Id ,
        emr.EMR_Code ,
        patient_Name ,
        patient_Age ,
        patient_Sex ,
        patient_Tel ,
        patient_WeChatCode ,
        main_suit ,
        allergy_history ,
        Medical_history ,
        therapeutic_schedule ,
        doctorRemarkDate,
        doctorRemark ,
        emr.cRemark ,
        emr_status ,
        treatment_status,
        confirm_time ,
        processing_time ,
        processing_requirement ,
        order_time ,
        pay_time ,
        production_time ,
        delivery_time ,
        end_time ,
        emr.createDate ,
        emr.createId ,
        emr.modifyDate ,
        emr.modifyId ,
        emr.flag ");
            strSql.Append(@" FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1 ");
            if (treatmentstatus == 4)
            {
                strSql.Append(@" WHERE   emr.flag = 1                               
                                AND hde.hospital_Id = @hospital_Id
                                AND hde.doctor_Id = @doctor_Id 
                                 AND ( CHARINDEX(@strWhere, emr.patient_Name) > 0
                                      OR CHARINDEX(@strWhere, emr.EMR_Code) > 0
                                      OR CHARINDEX(@strWhere, emr.main_suit) > 0
                                      OR CHARINDEX(@strWhere, emr.therapeutic_schedule) > 0
                                      OR CHARINDEX(@strWhere, emr.doctorRemark) > 0
                                    ) ORDER BY emr.createDate DESC 
                            ");
            }
            else
            {
                strSql.Append(@" WHERE   emr.flag = 1
                                AND hde.hospital_Id = @hospital_Id
                                AND hde.doctor_Id = @doctor_Id 
                                AND  treatment_status=@treatment_status
                                 AND ( CHARINDEX(@strWhere, emr.patient_Name) > 0
                                      OR CHARINDEX(@strWhere, emr.EMR_Code) > 0
                                      OR CHARINDEX(@strWhere, emr.main_suit) > 0
                                      OR CHARINDEX(@strWhere, emr.therapeutic_schedule) > 0
                                      OR CHARINDEX(@strWhere, emr.doctorRemark) > 0
                                    ) ORDER BY emr.createDate DESC 
                            ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@doctor_Id", SqlDbType.UniqueIdentifier),
					new SqlParameter("@hospital_Id", SqlDbType.UniqueIdentifier),		
                                        new SqlParameter("@treatment_status", SqlDbType.Int),
         new SqlParameter("@strWhere", SqlDbType.VarChar)                               
                                        };
            parameters[0].Value = new Guid(dId);
            parameters[1].Value = new Guid(hId);
            parameters[2].Value = treatmentstatus;       
            parameters[3].Value = strwhere;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ////用于反射类无法使用时使用
                //for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                //{
                //    DentalMedical.Model.simple_EMR se = DataRowToModel(ds.Tables[0].Rows[i]);
                //    List.Add(se);
                //}
                List = DataTableList.ToList<DentalMedical.Model.simple_EMR>(ds.Tables[0]);
                foreach (var l in List)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append(@"SELECT TOP 1
                                            [Id] ,
                                            [EMR_Code] ,
                                            [imagePath] ,
                                            [model_status] ,
                                            [orderId] ,
                                            [createDate] ,
                                            [createId] ,
                                            [modifyDate] ,
                                            [modifyId] ,
                                            [flag]
                                    FROM    [dbo].[dental_model]
                                    WHERE   EMR_Code = @EMR_Code
                                            AND flag = 1
                                    ORDER BY createDate DESC

                        
                       SELECT TOP 1
                                ds.[Id] ,
                                ds.[EMR_Code] ,
                                ds.[imagePath] ,
                                ds.[orderId] ,
                                ds.[createDate] ,
                                ds.[createId] ,
                                ds.[modifyDate] ,
                                ds.[modifyId] ,
                                ds.[flag] ,
                                li.express_billCode ,
                                li.expressName
                        FROM    [dbo].[design_scheme] ds
                                LEFT JOIN dbo.logistics_info li ON li.EMR_Code = ds.EMR_Code
                                                                   AND li.dsId = ds.Id
                                                                   AND li.flag = 1
                        WHERE   ds.EMR_Code = @EMR_Code
                                AND ds.flag = 1
                        ORDER BY ds.createDate DESC

                              SELECT  *
                            FROM    dbo.FaceImage
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY orderId

                           SELECT  TOP 1 *
                            FROM    dbo.doctor_essays
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC

                            SELECT TOP 1  [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[archiving_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC
                        
                                 SELECT TOP 1
                                    *
                            FROM    dbo.stl_d_data
                            WHERE   EMR_Code = @EMR_Code
                                    AND status = 1   AND flag = 1
                            ORDER BY createDate DESC
                            ");
                    SqlParameter[] parameters2 = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
                    parameters2[0].Value = l.EMR_Code;
                    DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {

                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.dental_model> dm = new List<Model.dental_model>();
                        //for (int i = 0; i < ds2.Tables[0].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.dental_model dmm = DataRowToModel(ds2.Tables[0].Rows[i]);
                        //    dm.Add(se);
                        //}
                        //l.dental_model = dm;
                        l.dental_model = DataTableList.ToList<DentalMedical.Model.dental_model>(ds2.Tables[0]);
                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.design_scheme = DataTableList.ToList<DentalMedical.Model.design_scheme>(ds2.Tables[1]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[2].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.FaceImage = DataTableList.ToList<DentalMedical.Model.FaceImage>(ds2.Tables[2]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[3].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.doctor_essays = DataTableList.ToList<DentalMedical.Model.doctor_essays>(ds2.Tables[3]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[4].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.archiving_model = DataTableList.ToList<DentalMedical.Model.archiving_model>(ds2.Tables[4]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[5].Rows.Count > 0)
                    {
                        l.stl_d_data = DataTableList.ToList<DentalMedical.Model.stl_d_data>(ds2.Tables[5]);

                    }
                }

            }
            return List;
        }

         /// <summary>
         /// 根据工厂登录的账号，病例状态,搜索条件获取emr列表
         /// </summary>
         /// <param name="fId">工厂Id</param>
         /// <param name="status">状态</param>
         /// <param name="strwhere">条件</param>
         /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> find_Emr_f(string fId, int status, string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            if (status != 99)
            {
                strSql.Append(@"SELECT  emr.Id ,
        emr.EMR_Code ,
        patient_Name ,
        patient_Age ,
        patient_Sex ,
        patient_Tel ,
        patient_WeChatCode ,
        main_suit ,
        allergy_history ,
        Medical_history ,
        therapeutic_schedule ,
        doctorRemarkDate,
        doctorRemark ,
        emr.cRemark ,
        emr_status ,
        confirm_time ,
        processing_time ,
        processing_requirement ,
        order_time ,
        pay_time ,
        production_time ,
        delivery_time ,
        end_time ,
        emr.createDate ,
        emr.createId ,
        emr.modifyDate ,
        emr.modifyId ,
        emr.flag ");
                strSql.Append(@" FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1
        LEFT  JOIN dbo.FD_relation fe ON fe.doctor_Id = hde.doctor_Id
                                         AND fe.flag = 1 
        LEFT JOIN dbo.doctors d ON d.Id = fe.doctor_Id
                                   AND d.flag = 1
        LEFT JOIN dbo.hospitals h ON h.Id = hde.hospital_Id ");
                strSql.Append(@" WHERE   emr.flag = 1       
         AND ( CHARINDEX(@strWhere, emr.patient_Name) > 0
              OR CHARINDEX(@strWhere, emr.EMR_Code) > 0
              OR CHARINDEX(@strWhere, emr.processing_requirement) > 0
            )
          AND emr.emr_status = @status
         AND fe.factory_Id = @factory_Id ORDER BY emr.createDate DESC 
        ");
            }
            else
            {
                strSql.Append(@"SELECT  emr.Id ,
        emr.EMR_Code ,
        patient_Name ,
        patient_Age ,
        patient_Sex ,
        patient_Tel ,
        patient_WeChatCode ,
        main_suit ,
        allergy_history ,
        Medical_history ,
        therapeutic_schedule ,
        doctorRemarkDate,
        doctorRemark ,
        emr.cRemark ,
        emr_status ,
        confirm_time ,
        processing_time ,
        processing_requirement ,
        order_time ,
        pay_time ,
        production_time ,
        delivery_time ,
        end_time ,
        emr.createDate ,
        emr.createId ,
        emr.modifyDate ,
        emr.modifyId ,
        emr.flag ");
                strSql.Append(@"FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1
        LEFT  JOIN dbo.FD_relation fe ON fe.doctor_Id = hde.doctor_Id
                                         AND fe.flag = 1 
        LEFT JOIN dbo.doctors d ON d.Id = fe.doctor_Id
                                   AND d.flag = 1
        LEFT JOIN dbo.hospitals h ON h.Id = hde.hospital_Id ");
                strSql.Append(@" WHERE   emr.flag = 1       
         AND ( CHARINDEX(@strWhere, emr.patient_Name) > 0
              OR CHARINDEX(@strWhere, emr.EMR_Code) > 0
              OR CHARINDEX(@strWhere, emr.processing_requirement) > 0
            )
         AND (emr.emr_status = 6 OR emr.emr_status = 8 OR emr.emr_status = 9)
         AND fe.factory_Id = @factory_Id ORDER BY emr.createDate DESC 
        ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@factory_Id", SqlDbType.UniqueIdentifier),	
                                        new SqlParameter("@status", SqlDbType.Int),
         new SqlParameter("@strWhere", SqlDbType.VarChar)                               
                                        };
            parameters[0].Value = new Guid(fId);
            parameters[1].Value = status;
            parameters[2].Value = strwhere;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<DentalMedical.Model.simple_EMR> List = new List<Model.simple_EMR>(); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                ////用于反射类无法使用时使用
                //for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                //{
                //    DentalMedical.Model.simple_EMR se = DataRowToModel(ds.Tables[0].Rows[i]);
                //    List.Add(se);
                //}
                List = DataTableList.ToList<DentalMedical.Model.simple_EMR>(ds.Tables[0]);
                foreach (var l in List)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append(@"
                                    SELECT TOP 1
                                            ds.[Id] ,
                                            ds.[EMR_Code] ,
                                            ds.[imagePath] ,
                                            ds.[orderId] ,
                                            ds.[createDate] ,
                                            ds.[createId] ,
                                            ds.[modifyDate] ,
                                            ds.[modifyId] ,
                                            ds.[flag] ,
                                            li.express_billCode ,
                                            li.expressName
                                    FROM    [dbo].[design_scheme] ds
                                            LEFT JOIN dbo.logistics_info li ON li.EMR_Code = ds.EMR_Code
                                                                               AND li.dsId = ds.Id
                                                                               AND li.flag = 1
                                    WHERE   ds.EMR_Code = @EMR_Code
                                            AND ds.flag = 1
                                    ORDER BY ds.createDate DESC

                             SELECT  *
                            FROM    dbo.FaceImage
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY orderId

                            SELECT TOP 1
                                            [Id] ,
                                            [EMR_Code] ,
                                            [imagePath] ,
                                            [model_status] ,
                                            [orderId] ,
                                            [createDate] ,
                                            [createId] ,
                                            [modifyDate] ,
                                            [modifyId] ,
                                            [flag]
                                    FROM    [dbo].[dental_model]
                                    WHERE   EMR_Code = @EMR_Code
                                            AND flag = 1
                                    ORDER BY createDate DESC
                            ");

                    
                            //SELECT  *
                            //FROM    dbo.doctor_essays
                            //WHERE   EMR_Code = @EMR_Code
                            //        AND flag = 1

                    SqlParameter[] parameters2 = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
                    parameters2[0].Value = l.EMR_Code;
                    DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {

                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.dental_model> dm = new List<Model.dental_model>();
                        //for (int i = 0; i < ds2.Tables[0].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.dental_model dmm = DataRowToModel(ds2.Tables[0].Rows[i]);
                        //    dm.Add(se);
                        //}
                        //l.dental_model = dm;
                        l.design_scheme = DataTableList.ToList<DentalMedical.Model.design_scheme>(ds2.Tables[0]);
                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.FaceImage = DataTableList.ToList<DentalMedical.Model.FaceImage>(ds2.Tables[1]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[2].Rows.Count > 0)
                    {

                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.dental_model> dm = new List<Model.dental_model>();
                        //for (int i = 0; i < ds2.Tables[0].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.dental_model dmm = DataRowToModel(ds2.Tables[0].Rows[i]);
                        //    dm.Add(se);
                        //}
                        //l.dental_model = dm;
                        l.dental_model = DataTableList.ToList<DentalMedical.Model.dental_model>(ds2.Tables[2]);
                    }

            
                }

            }
            return List;
        }

        /// <summary>
        /// 根据病例号获取病例信息
        /// </summary>
        /// <param name="emrCode"></param>
        /// <returns></returns>
        public DentalMedical.Model.simple_EMR get_emr_byCode(string emrCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  se.[Id] ,
        se.[EMR_Code] ,
        [patient_Name] ,
        [patient_Age] ,
        [patient_Sex] ,
        [patient_Tel] ,
        [patient_WeChatCode] ,
        [main_suit] ,
        [allergy_history] ,
        [Medical_history] ,
        [therapeutic_schedule] ,
        [doctorRemarkDate],
        [doctorRemark] ,
        se.[cRemark] ,
        [emr_status] ,
        [treatment_status],
        [confirm_time] ,
        [processing_time] ,
        [processing_requirement] ,
        [order_time] ,
        [pay_time] ,
        [production_time] ,
        [delivery_time] ,
        [end_time] ,
        se.[createDate] ,
        se.[createId] ,
        se.[modifyDate] ,
        se.[modifyId] ,
        se.[flag] ,
        h.Id AS hospital_Id ,
        h.hospitalName AS hospital_Name ,
        d.Id AS doctor_Id ,
        d.userRealName AS doctor_Name ,
        d.userCode AS doctor_tel ,
        de.Id AS de_Id ,
        de.deName AS de_Name
FROM    [dbo].[simple_EMR] se
        LEFT JOIN dbo.HDE_relation hd ON hd.EMR_Code = se.EMR_Code
                                         AND hd.flag = 1
        LEFT JOIN dbo.doctors d ON d.Id = hd.doctor_Id
                                   AND d.flag = 1
        LEFT JOIN dbo.doctor_certification dc ON dc.doctor_Id = d.Id
                                                 AND dc.flag = 1
        LEFT JOIN dbo.departments de ON de.Id = dc.userDepartment
                                        AND de.flag = 1
        LEFT JOIN dbo.hospitals h ON h.Id = hd.hospital_Id
                                     AND h.flag = 1
            WHERE se.EMR_Code=@EMR_Code AND se.flag=1 ORDER BY se.createDate DESC 
        ");
            SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)			};
            parameters[0].Value = emrCode;
            DentalMedical.Model.simple_EMR model = new DentalMedical.Model.simple_EMR();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model= DataRowToModel(ds.Tables[0].Rows[0]);
                List<DentalMedical.Model.FaceImage> ListFace = new List<Model.FaceImage>();
                FaceImage fa = new FaceImage();
                ListFace = fa.get_FaceImage_List(emrCode);

                List<DentalMedical.Model.DCImage> ListDC = new List<Model.DCImage>();
                DCImage dc = new DCImage();
                ListDC = dc.get_DCImage_List(emrCode);

                List<DentalMedical.Model.rootImage> Listroot = new List<Model.rootImage>();
                rootImage root = new rootImage();
                Listroot = root.get_rootImage_List(emrCode);
                model.FaceImage = ListFace;
                model.DCImage = ListDC;
                model.rootImage = Listroot;
                return model;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="emrCode">病例号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.EMR_stream> get_stream(string emrCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    es.EMR_Code ,
                                                es.message ,
                                                es.createDate ,
                                                CASE WHEN d.userRealName IS NULL
                                                          OR d.userRealName = ''
                                                     THEN CASE WHEN f.factoryName IS NULL
                                                                    OR f.factoryName = ''
                                                               THEN CASE WHEN der.userRealName IS NULL
                                                                              OR der.userRealName = ''
                                                                         THEN '作者'
                                                                    END
                                                               ELSE f.factoryName
                                                          END
                                                     ELSE d.userRealName
                                                END AS doctorName
                                      FROM      dbo.EMR_stream es
                                                LEFT JOIN dbo.doctors d ON d.Id = es.createId
                                                                           AND d.flag = 1
                                                LEFT JOIN dbo.factory f ON f.Id = es.createId
                                                                           AND f.flag = 1
                                                LEFT JOIN dbo.designers der ON der.Id = es.createId
                                                                               AND der.flag = 1
                                      WHERE     EMR_Code = @EMR_Code
                                                AND es.flag = 1
                                      UNION
                                      SELECT    dess.EMR_Code ,
                                                dess.doctorRemark AS 'message' ,
                                                dess.createDate ,
                                                CASE WHEN d.userRealName IS NULL
                                                          OR d.userRealName = ''
                                                     THEN CASE WHEN der.userRealName IS NULL
                                                                    OR der.userRealName = '' THEN '作者'
                                                               ELSE der.userRealName
                                                          END
                                                     ELSE d.userRealName
                                                END AS doctorName
                                      FROM      dbo.doctor_essays dess
                                                LEFT JOIN dbo.doctors d ON d.Id = dess.createId
                                                                           AND d.flag = 1
                                                LEFT JOIN dbo.designers der ON der.Id = dess.createId
                                                                               AND der.flag = 1
                                      WHERE     dess.EMR_Code = @EMR_Code
                                                AND dess.flag = 1
                                    ) a
                            ORDER BY a.createDate ASC");
            SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)			};
            parameters[0].Value = emrCode;
            List<DentalMedical.Model.EMR_stream> stream = new List<Model.EMR_stream>();
            EMR_stream es = new EMR_stream();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    DentalMedical.Model.EMR_stream emrstrem = new Model.EMR_stream();
                //    emrstrem = es.DataRowToModel(ds.Tables[0].Rows[i]);
                //    stream.Add(emrstrem);
                //}
                stream = DataTableList.ToList<DentalMedical.Model.EMR_stream>(ds.Tables[0]);
            }
            return stream;
        }

        /// <summary>
        /// 根据微信号 获取病人病例列表
        /// </summary>
        /// <param name="weixin"></param>
        /// <returns></returns>
        public List<DentalMedical.Model.WX_simple_emr> Get_list_by_weixin(string weixin)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  se.[EMR_Code] AS EMR_code ,
        se.[patient_Name] AS patient_name ,
        DATEDIFF(YY, se.[patient_Age], GETDATE()) AS patient_age ,
        se.[patient_Sex] AS patient_sex ,
        se.[patient_Tel] AS patient_tel ,
        se.[emr_status] ,
        DATENAME(MONTH,
                 CASE WHEN se.[emr_status] < 5
                      THEN CASE WHEN se.modifyDate IS NULL THEN se.createDate
                                ELSE se.modifyDate
                           END
                      ELSE se.confirm_time
                 END) + '-' + DATENAME(DAY,
                                       CASE WHEN se.[emr_status] < 5
                                            THEN CASE WHEN se.modifyDate IS NULL
                                                      THEN se.createDate
                                                      ELSE se.modifyDate
                                                 END
                                            ELSE se.confirm_time
                                       END) AS pre_time ,
        CASE WHEN se.[confirm_time] IS NULL THEN '诊前ing~~~~~~'
             ELSE '诊前完成！'
        END AS pre_info ,
        DATENAME(MONTH,
                 CASE WHEN se.[emr_status] > 4
                      THEN CASE WHEN se.end_time IS NULL THEN se.modifyDate
                                ELSE se.delivery_time
                           END
                      ELSE NULL
                 END) + '-' + DATENAME(DAY,
                                       CASE WHEN se.[emr_status] > 4
                                            THEN CASE WHEN se.end_time IS NULL
                                                      THEN se.modifyDate
                                                      ELSE se.delivery_time
                                                 END
                                            ELSE NULL
                                       END) AS middle_time ,
        CASE WHEN se.[emr_status] > 4
             THEN CASE WHEN se.end_time IS NULL THEN '诊中ing~~~~~'
                       ELSE '诊中完成！'
                  END
             ELSE NULL
        END AS middle_info ,
        DATENAME(MONTH,
                 CASE WHEN se.[emr_status] > 10
                      THEN CASE WHEN se.end_time IS NULL THEN se.modifyDate
                                ELSE se.end_time
                           END
                      ELSE NULL
                 END) + '-' + DATENAME(DAY,
                                       CASE WHEN se.[emr_status] > 10
                                            THEN CASE WHEN se.end_time IS NULL
                                                      THEN se.modifyDate
                                                      ELSE se.end_time
                                                 END
                                            ELSE NULL
                                       END) AS middle_time ,
        CASE WHEN se.[emr_status] > 10
             THEN CASE WHEN se.end_time IS NULL THEN '诊后ing~~~~~~~'
                       ELSE '诊后完成！'
                  END
             ELSE NULL
        END AS end_info ,
        '' AS cue_time ,
         h.hospitalAddress AS cue_add ,
        '' AS cue_tip ,
        de.deName AS patient_department ,
        h.hospitalName AS hospital_Name
FROM    dbo.patientInfo pin
        RIGHT JOIN dbo.simple_EMR se ON se.patient_Tel = pin.patientCode
                                        AND se.flag = 1
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = se.EMR_Code
                                          AND hde.flag = 1
        LEFT JOIN dbo.hospitals h ON h.Id = hde.hospital_Id
                                     AND h.flag = 1
        LEFT JOIN dbo.doctor_certification dc ON dc.doctor_Id = hde.doctor_Id
                                                 AND dc.userHospital = hde.hospital_Id
                                                 AND dc.flag = 1
        LEFT JOIN dbo.departments de ON de.Id = dc.userDepartment
                                        AND dc.flag = 1
WHERE   pin.weixin = @weixin
        AND pin.flag = 1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@weixin", SqlDbType.VarChar)};
            parameters[0].Value = weixin;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            List<DentalMedical.Model.WX_simple_emr> List = new List<Model.WX_simple_emr>(); ;
            if (ds.Tables[0].Rows.Count > 0)
            {
                List = DataTableList.ToList<DentalMedical.Model.WX_simple_emr>(ds.Tables[0]);
                foreach (var l in List)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append(@"SELECT  [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[dental_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
		                            ORDER BY orderId DESC

                            SELECT    ds.[Id] ,
                                    ds.[EMR_Code] ,
                                    ds.[imagePath] ,
                                    ds.[orderId] ,
                                    ds.[createDate] ,
                                    ds.[createId] ,
                                    ds.[modifyDate] ,
                                    ds.[modifyId] ,
                                    ds.[flag] ,
                                    li.express_billCode ,
                                    li.expressName
                          FROM      [dbo].[design_scheme] ds
                                    LEFT JOIN dbo.logistics_info li ON li.EMR_Code = ds.EMR_Code
                                                                       AND li.dsId = ds.Id
                                                                       AND li.flag = 1
                          WHERE     ds.EMR_Code = @EMR_Code
                                     AND ds.flag = 1
                                    ORDER BY orderId DESC

                                   SELECT  [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[archiving_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                                    ORDER BY orderId DESC
                                ");
                    SqlParameter[] parameters2 = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
                    parameters2[0].Value = l.EMR_code;
                    DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        l.dental_model = DataTableList.ToList<DentalMedical.Model.dental_model>(ds2.Tables[0]);
                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        l.design_scheme = DataTableList.ToList<DentalMedical.Model.design_scheme>(ds2.Tables[1]);
                    }
                    if (ds2.Tables[2].Rows.Count > 0)
                    {
                        l.archiving_model = DataTableList.ToList<DentalMedical.Model.archiving_model>(ds2.Tables[2]);
                    }
                }

            }
            return List;
        }

        /// <summary>
        /// 判断模型文件是否有更新
        /// </summary>
        /// <param name="EMR_Code"></param>
        /// <param name="fileId"></param>
        /// <param name="filetype"></param>
        /// <returns></returns>
        public bool isChangeFile(string EMR_Code, string fileId, int filetype)
        {
            string sql = string.Empty;
            if (filetype == 1)
            {
                sql = @"SELECT TOP 1
                            [Id] ,
                            [EMR_Code] ,
                            [imagePath] ,
                            [model_status] ,
                            [orderId] ,
                            [createDate] ,
                            [createId] ,
                            [modifyDate] ,
                            [modifyId] ,
                            [flag]
                    FROM    [dbo].[dental_model]
                    WHERE   EMR_Code = @EMR_Code
                            AND flag = 1
                    ORDER BY createDate DESC";
            }
            else if (filetype == 2)
            {
                sql = @"SELECT TOP 1
                            ds.[Id] ,
                            ds.[EMR_Code] ,
                            ds.[imagePath] ,
                            ds.[orderId] ,
                            ds.[createDate] ,
                            ds.[createId] ,
                            ds.[modifyDate] ,
                            ds.[modifyId] ,
                            ds.[flag]
                    FROM    [dbo].[design_scheme] ds
                    WHERE   ds.EMR_Code = @EMR_Code
                            AND ds.flag = 1
                    ORDER BY ds.createDate DESC";
            }
            else if (filetype == 3)
            {
                sql = @"SELECT TOP 1
                            [Id] ,
                            [EMR_Code] ,
                            [imagePath] ,
                            [model_status] ,
                            [orderId] ,
                            [createDate] ,
                            [createId] ,
                            [modifyDate] ,
                            [modifyId] ,
                            [flag]
                    FROM    [dbo].[archiving_model]
                    WHERE   EMR_Code = @EMR_Code
                            AND flag = 1
                    ORDER BY createDate DESC";
            }
            else
            {
                return false;
            }
            SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
            parameters[0].Value = EMR_Code;
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string id = ds.Tables[0].Rows[0]["Id"].ToString();
                if (fileId.Equals(id))
                {
                    return false;
                }
                else
                    return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取病人病例
        /// </summary>
        /// <param name="tel">电话号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> get_emrCode(string tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    dbo.simple_EMR
                            WHERE   patient_Tel = patient_Tel");
            SqlParameter[] parameters = {
					new SqlParameter("@patientTel", SqlDbType.VarChar)			};
            parameters[0].Value = tel;
            List<DentalMedical.Model.simple_EMR> stream = new List<Model.simple_EMR>();         
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    DentalMedical.Model.EMR_stream emrstrem = new Model.EMR_stream();
                //    emrstrem = es.DataRowToModel(ds.Tables[0].Rows[i]);
                //    stream.Add(emrstrem);
                //}
                stream = DataTableList.ToList<DentalMedical.Model.simple_EMR>(ds.Tables[0]);
            }
            return stream;
        }

        /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="tel">电话号</param>
        /// <returns></returns>
        public List<DentalMedical.Model.EMR_stream> get_stream_byTel(string tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    es.EMR_Code ,
                                                es.message ,
                                                es.createDate ,
                                                d.userRealName AS doctorName ,
                                                f.factoryName
                                      FROM      dbo.EMR_stream es
                                                RIGHT JOIN dbo.simple_EMR se ON se.EMR_Code = es.EMR_Code
                                                                                AND se.flag = 1
                                                LEFT JOIN dbo.doctors d ON d.Id = es.createId
                                                                           AND d.flag = 1
                                                LEFT JOIN dbo.factory f ON f.Id = es.createId
                                                                           AND f.flag = 1
                                      WHERE     se.patient_Tel = @tel
                                                AND es.flag = 1
                                      UNION
                                      SELECT    dess.EMR_Code ,
                                                dess.doctorRemark AS 'message' ,
                                                dess.createDate ,
                                                d.userRealName AS doctorName ,
                                                ''
                                      FROM      dbo.doctor_essays dess
                                                RIGHT JOIN dbo.simple_EMR se ON se.EMR_Code = dess.EMR_Code
                                                LEFT JOIN dbo.doctors d ON d.Id = dess.createId
                                                                           AND d.flag = 1
                                      WHERE     se.patient_Tel = @tel
                                                AND dess.flag = 1
                                    ) a
                            ORDER BY a.createDate ASC");
            SqlParameter[] parameters = {
					new SqlParameter("@tel", SqlDbType.VarChar)			};
            parameters[0].Value = tel;
            List<DentalMedical.Model.EMR_stream> stream = new List<Model.EMR_stream>();
            EMR_stream es = new EMR_stream();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    DentalMedical.Model.EMR_stream emrstrem = new Model.EMR_stream();
                //    emrstrem = es.DataRowToModel(ds.Tables[0].Rows[i]);
                //    stream.Add(emrstrem);
                //}
                stream = DataTableList.ToList<DentalMedical.Model.EMR_stream>(ds.Tables[0]);
            }
            return stream;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public Hashtable Add_hash(DentalMedical.Model.simple_EMR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into simple_EMR(");
            strSql.Append("Id,EMR_Code,patient_Name,patient_Age,patient_Sex,patient_Tel,patient_WeChatCode,main_suit,allergy_history,Medical_history,therapeutic_schedule,doctorRemark,cRemark,emr_status,confirm_time,processing_time,processing_requirement,order_time,pay_time,production_time,delivery_time,end_time,createDate,createId,flag)");
            strSql.Append(" values (");
            strSql.Append("@Id,@EMR_Code,@patient_Name,@patient_Age,@patient_Sex,@patient_Tel,@patient_WeChatCode,@main_suit,@allergy_history,@Medical_history,@therapeutic_schedule,@doctorRemark,@cRemark,@emr_status,@confirm_time,@processing_time,@processing_requirement,@order_time,@pay_time,@production_time,@delivery_time,@end_time,GETDATE(),@createId,@flag)");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
					new SqlParameter("@patient_Name", SqlDbType.VarChar),
					new SqlParameter("@patient_Age", SqlDbType.VarChar),
					new SqlParameter("@patient_Sex", SqlDbType.Int),
					new SqlParameter("@patient_Tel", SqlDbType.VarChar),
					new SqlParameter("@patient_WeChatCode", SqlDbType.VarChar),
					new SqlParameter("@main_suit", SqlDbType.VarChar),
					new SqlParameter("@allergy_history", SqlDbType.VarChar),
					new SqlParameter("@Medical_history", SqlDbType.VarChar),
					new SqlParameter("@therapeutic_schedule", SqlDbType.VarChar),
					new SqlParameter("@doctorRemark", SqlDbType.VarChar),
					new SqlParameter("@cRemark", SqlDbType.VarChar),
					new SqlParameter("@emr_status", SqlDbType.Int),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@processing_time", SqlDbType.DateTime),
					new SqlParameter("@processing_requirement", SqlDbType.VarChar),
					new SqlParameter("@order_time", SqlDbType.DateTime),
					new SqlParameter("@pay_time", SqlDbType.DateTime),
					new SqlParameter("@production_time", SqlDbType.DateTime),
					new SqlParameter("@delivery_time", SqlDbType.DateTime),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@createId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@flag", SqlDbType.Int)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.EMR_Code;
            parameters[2].Value = model.patient_Name;
            parameters[3].Value = model.patient_Age;
            parameters[4].Value = model.patient_Sex;
            parameters[5].Value = model.patient_Tel;
            parameters[6].Value = model.patient_WeChatCode;
            parameters[7].Value = model.main_suit;
            parameters[8].Value = model.allergy_history;
            parameters[9].Value = model.Medical_history;
            parameters[10].Value = model.therapeutic_schedule;
            parameters[11].Value = model.doctorRemark;
            parameters[12].Value = model.cRemark;
            parameters[13].Value = model.emr_status;
            parameters[14].Value = model.confirm_time;
            parameters[15].Value = model.processing_time;
            parameters[16].Value = model.processing_requirement;
            parameters[17].Value = model.order_time;
            parameters[18].Value = model.pay_time;
            parameters[19].Value = model.production_time;
            parameters[20].Value = model.delivery_time;
            parameters[21].Value = model.end_time;
            parameters[22].Value = model.createId;
            parameters[23].Value = model.flag;
            Hashtable ht = new Hashtable();
            ht.Add(strSql, parameters);
            return ht;
        }

        /// <summary>
        /// 获取病例流程
        /// </summary>
        /// <param name="openId">微信openId</param>
        /// <returns></returns>
        public List<DentalMedical.Model.EMR_stream> get_stream_byWeixin(string openId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
FROM    ( SELECT    es.EMR_Code ,
                    es.message ,
                    es.createDate ,
                    d.userRealName AS doctorName ,
                    f.factoryName
          FROM      dbo.EMR_stream es
                    RIGHT JOIN dbo.simple_EMR se ON se.EMR_Code = es.EMR_Code
                                                    AND se.flag = 1
                    LEFT JOIN dbo.doctors d ON d.Id = es.createId
                                               AND d.flag = 1
                    LEFT JOIN dbo.factory f ON f.Id = es.createId
                                               AND f.flag = 1
                    LEFT JOIN dbo.patientInfo pinfo ON pinfo.patientCode = se.patient_Tel
                                                       AND pinfo.flag = 1
          WHERE     pinfo.weixin = @weixin
                    AND es.flag = 1
          UNION
          SELECT    dess.EMR_Code ,
                    dess.doctorRemark AS 'message' ,
                    dess.createDate ,
                    d.userRealName AS doctorName ,
                    ''
          FROM      dbo.doctor_essays dess
                    RIGHT JOIN dbo.simple_EMR se ON se.EMR_Code = dess.EMR_Code
                    LEFT JOIN dbo.doctors d ON d.Id = dess.createId
                                               AND d.flag = 1
                    LEFT JOIN dbo.patientInfo pinfo ON pinfo.patientCode = se.patient_Tel
                                                       AND pinfo.flag = 1
          WHERE     pinfo.weixin = @weixin
                    AND dess.flag = 1
        ) a
ORDER BY a.createDate ASC");
            SqlParameter[] parameters = {
					new SqlParameter("@weixin", SqlDbType.VarChar)			};
            parameters[0].Value = openId;
            List<DentalMedical.Model.EMR_stream> stream = new List<Model.EMR_stream>();
            EMR_stream es = new EMR_stream();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    DentalMedical.Model.EMR_stream emrstrem = new Model.EMR_stream();
                //    emrstrem = es.DataRowToModel(ds.Tables[0].Rows[i]);
                //    stream.Add(emrstrem);
                //}
                stream = DataTableList.ToList<DentalMedical.Model.EMR_stream>(ds.Tables[0]);
            }
            return stream;
        }

        /// <summary>
        /// 事务提交新增病例
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="emrCode"></param>
        /// <returns></returns>
        public DentalMedical.Model.simple_EMR simple_add_hash(Hashtable ht,string emrCode)
        {
            DbHelperSQL.ExecuteSqlTran(ht);
            DentalMedical.Model.simple_EMR se = get_emr_byCode(emrCode);
            if (se != null && !string.IsNullOrEmpty(se.EMR_Code))
            {
                return se;
            }
            return null;
        }
        
        /// <summary>
        /// 根据设计者登录的账号，就诊状态获取emr列表
        /// </summary>
        /// <param name="treatmentstatus">状态</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> EMR_design_list( int treatmentstatus)
        {
            List<DentalMedical.Model.simple_EMR> List = new List<Model.simple_EMR>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  emr.Id ,
        emr.EMR_Code ,
        patient_Name ,
        patient_Age ,
        patient_Sex ,
        patient_Tel ,
        patient_WeChatCode ,
        main_suit ,
        allergy_history ,
        Medical_history ,
        therapeutic_schedule ,
        doctorRemarkDate,
        doctorRemark ,
        emr.cRemark ,
        emr_status ,treatment_status,
        confirm_time ,
        processing_time ,
        processing_requirement ,
        order_time ,
        pay_time ,
        production_time ,
        delivery_time ,
        end_time ,
        emr.createDate ,
        emr.createId ,
        emr.modifyDate ,
        emr.modifyId ,
        emr.flag ");
            strSql.Append(@" FROM    [dbo].[simple_EMR] emr
        LEFT JOIN dbo.HDE_relation hde ON hde.EMR_Code = emr.EMR_Code
                                          AND hde.flag = 1 
        LEFT JOIN dbo.doctor_designer_relation ddr ON ddr.doctorId = hde.doctor_Id
                                                      AND ddr.flag = 1");
            if (treatmentstatus == 4)
            {
                strSql.Append(@" WHERE   emr.flag = 1
        ORDER BY emr.createDate DESC ");
            }
            else
            {
                strSql.Append(@" WHERE   emr.flag = 1
        AND treatment_status=@treatment_status
        ORDER BY emr.createDate DESC ");
            }
            SqlParameter[] parameters = {	
                                        new SqlParameter("@treatment_status", SqlDbType.Int)};
            parameters[0].Value = treatmentstatus;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                List = DataTableList.ToList<DentalMedical.Model.simple_EMR>(ds.Tables[0]);
                foreach (var l in List)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append(@"SELECT TOP 1
                                    [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[dental_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC

                            SELECT TOP 1
                                    ds.[Id] ,
                                    ds.[EMR_Code] ,
                                    ds.[imagePath] ,
                                    ds.[orderId] ,
                                    ds.[createDate] ,
                                    ds.[createId] ,
                                    ds.[modifyDate] ,
                                    ds.[modifyId] ,
                                    ds.[flag] ,
                                    li.express_billCode ,
                                    li.expressName
                            FROM    [dbo].[design_scheme] ds
                                    LEFT JOIN dbo.logistics_info li ON li.EMR_Code = ds.EMR_Code
                                                                       AND li.dsId = ds.Id
                                                                       AND li.flag = 1
                            WHERE   ds.EMR_Code = @EMR_Code
                                    AND ds.flag = 1
                            ORDER BY ds.createDate DESC

                            SELECT  *
                            FROM    dbo.FaceImage
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY orderId

                            SELECT  TOP 1 *
                            FROM    dbo.doctor_essays
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC

                            SELECT TOP 1
                                    [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[archiving_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC
                    ");
                    SqlParameter[] parameters2 = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
                    parameters2[0].Value = l.EMR_Code;
                    DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        l.dental_model = DataTableList.ToList<DentalMedical.Model.dental_model>(ds2.Tables[0]);
                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        l.design_scheme = DataTableList.ToList<DentalMedical.Model.design_scheme>(ds2.Tables[1]);
                    }
                    if (ds2.Tables[2].Rows.Count > 0)
                    {
                        l.FaceImage = DataTableList.ToList<DentalMedical.Model.FaceImage>(ds2.Tables[2]);
                    }
                    if (ds2.Tables[3].Rows.Count > 0)
                    {
                        l.doctor_essays = DataTableList.ToList<DentalMedical.Model.doctor_essays>(ds2.Tables[3]);

                    }
                    if (ds2.Tables[4].Rows.Count > 0)
                    {
                        l.archiving_model = DataTableList.ToList<DentalMedical.Model.archiving_model>(ds2.Tables[4]);

                    }
                }

            }

            return List;
        }

        /// <summary>
        /// 设计者的账号，根据当前状态的搜索条件获取emr列表
        /// </summary>
        /// <param name="minStatus">状态</param>
        /// <param name="maxStatus">状态</param>
        /// <param name="strwhere">搜索条件</param>
        /// <returns></returns>
        public List<DentalMedical.Model.simple_EMR> find_Emr_design(int treatmentstatus, string strwhere)
        {
            List<DentalMedical.Model.simple_EMR> List = new List<Model.simple_EMR>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  emr.Id ,
            emr.EMR_Code ,
            patient_Name ,
            patient_Age ,
            patient_Sex ,
            patient_Tel ,
            patient_WeChatCode ,
            main_suit ,
            allergy_history ,
            Medical_history ,
            therapeutic_schedule ,
            doctorRemarkDate,
            doctorRemark ,
            emr.cRemark ,
            emr_status ,
            confirm_time ,
            processing_time ,
            processing_requirement ,
            order_time ,
            pay_time ,
            production_time ,
            delivery_time ,
            end_time ,
            emr.createDate ,
            emr.createId ,
            emr.modifyDate ,
            emr.modifyId ,
            emr.flag ");
            strSql.Append(@"FROM    [dbo].[simple_EMR] emr       ");
            if (treatmentstatus == 4)
            {
                strSql.Append(@" WHERE   emr.flag = 1
             AND ( CHARINDEX(@strWhere, emr.patient_Name) > 0
                  OR CHARINDEX(@strWhere, emr.EMR_Code) > 0
                  OR CHARINDEX(@strWhere, emr.main_suit) > 0
                  OR CHARINDEX(@strWhere, emr.therapeutic_schedule) > 0
                  OR CHARINDEX(@strWhere, emr.doctorRemark) > 0
                ) ORDER BY emr.createDate DESC 
            ");
            }
            else
            {
                strSql.Append(@" WHERE   emr.flag = 1
            AND treatment_status=@treatment_status
             AND ( CHARINDEX(@strWhere, emr.patient_Name) > 0
                  OR CHARINDEX(@strWhere, emr.EMR_Code) > 0
                  OR CHARINDEX(@strWhere, emr.main_suit) > 0
                  OR CHARINDEX(@strWhere, emr.therapeutic_schedule) > 0
                  OR CHARINDEX(@strWhere, emr.doctorRemark) > 0
                ) ORDER BY emr.createDate DESC 
            ");
            }
            SqlParameter[] parameters = {
                                        new SqlParameter("@treatment_status", SqlDbType.Int),
         new SqlParameter("@strWhere", SqlDbType.VarChar)                               
                                        };
            parameters[0].Value = treatmentstatus;
            parameters[1].Value = strwhere;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ////用于反射类无法使用时使用
                //for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                //{
                //    DentalMedical.Model.simple_EMR se = DataRowToModel(ds.Tables[0].Rows[i]);
                //    List.Add(se);
                //}
                List = DataTableList.ToList<DentalMedical.Model.simple_EMR>(ds.Tables[0]);
                foreach (var l in List)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append(@"SELECT TOP 1
                                            [Id] ,
                                            [EMR_Code] ,
                                            [imagePath] ,
                                            [model_status] ,
                                            [orderId] ,
                                            [createDate] ,
                                            [createId] ,
                                            [modifyDate] ,
                                            [modifyId] ,
                                            [flag]
                                    FROM    [dbo].[dental_model]
                                    WHERE   EMR_Code = @EMR_Code
                                            AND flag = 1
                                    ORDER BY createDate DESC

                        
                       SELECT TOP 1
                                ds.[Id] ,
                                ds.[EMR_Code] ,
                                ds.[imagePath] ,
                                ds.[orderId] ,
                                ds.[createDate] ,
                                ds.[createId] ,
                                ds.[modifyDate] ,
                                ds.[modifyId] ,
                                ds.[flag] ,
                                li.express_billCode ,
                                li.expressName
                        FROM    [dbo].[design_scheme] ds
                                LEFT JOIN dbo.logistics_info li ON li.EMR_Code = ds.EMR_Code
                                                                   AND li.dsId = ds.Id
                                                                   AND li.flag = 1
                        WHERE   ds.EMR_Code = @EMR_Code
                                AND ds.flag = 1
                        ORDER BY ds.createDate DESC

                              SELECT  *
                            FROM    dbo.FaceImage
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY orderId

                           SELECT  TOP 1 *
                            FROM    dbo.doctor_essays
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC

                            SELECT TOP 1  [Id] ,
                                    [EMR_Code] ,
                                    [imagePath] ,
                                    [model_status] ,
                                    [orderId] ,
                                    [createDate] ,
                                    [createId] ,
                                    [modifyDate] ,
                                    [modifyId] ,
                                    [flag]
                            FROM    [dbo].[archiving_model]
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1
                            ORDER BY createDate DESC
                            ");
                    SqlParameter[] parameters2 = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar)};
                    parameters2[0].Value = l.EMR_Code;
                    DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {

                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.dental_model> dm = new List<Model.dental_model>();
                        //for (int i = 0; i < ds2.Tables[0].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.dental_model dmm = DataRowToModel(ds2.Tables[0].Rows[i]);
                        //    dm.Add(se);
                        //}
                        //l.dental_model = dm;
                        l.dental_model = DataTableList.ToList<DentalMedical.Model.dental_model>(ds2.Tables[0]);
                    }
                    if (ds2.Tables[1].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.design_scheme = DataTableList.ToList<DentalMedical.Model.design_scheme>(ds2.Tables[1]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[2].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.FaceImage = DataTableList.ToList<DentalMedical.Model.FaceImage>(ds2.Tables[2]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[3].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.doctor_essays = DataTableList.ToList<DentalMedical.Model.doctor_essays>(ds2.Tables[3]);
                        //}
                        //l.dental_model = dsc;
                    }
                    if (ds2.Tables[4].Rows.Count > 0)
                    {
                        ////用于反射类无法使用时使用
                        //List<DentalMedical.Model.design_scheme> dsc = new List<Model.design_scheme>();
                        //for (int i = 0; i < ds2.Tables[1].Rows.Count;i++ )
                        //{
                        //    DentalMedical.Model.design_scheme dscm = DataRowToModel(ds2.Tables[1].Rows[i]);
                        //    dsc.Add(dscm);
                        l.archiving_model = DataTableList.ToList<DentalMedical.Model.archiving_model>(ds2.Tables[4]);
                        //}
                        //l.dental_model = dsc;
                    }
                }




            }
            return List;
        }

        /// <summary>
        /// 更新就诊状态
        /// </summary>
        /// <param name="traatment"></param>
        /// <param name="EMR_Code"></param>
        /// <returns></returns>
        public int update_treatmentstatus(int traatment, string EMR_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE  dbo.simple_EMR
                            SET     treatment_status = @treatment_status
                            WHERE   EMR_Code = @EMR_Code
                                    AND flag = 1");
            SqlParameter[] parameters = {
					new SqlParameter("@EMR_Code", SqlDbType.VarChar),
                                           new SqlParameter("@treatment_status", SqlDbType.Int)
                                            };
            parameters[0].Value = EMR_Code;
            parameters[1].Value = traatment;
            int result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return result;
        }
		#endregion  ExtensionMethod
	}
}

