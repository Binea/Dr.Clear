using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace DentalMedical.Web.simple_EMR
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Guid Id;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					Id= Request.Params["id0"];
				}
				string EMR_Code = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					EMR_Code= Request.Params["id1"];
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(Id,EMR_Code);
			}
		}
			
	private void ShowInfo(Guid Id,string EMR_Code)
	{
		DentalMedical.BLL.simple_EMR bll=new DentalMedical.BLL.simple_EMR();
		DentalMedical.Model.simple_EMR model=bll.GetModel(Id,EMR_Code);
		this.lblId.Text=model.Id.ToString();
		this.lblEMR_Code.Text=model.EMR_Code;
		this.txtpatient_Name.Text=model.patient_Name;
		this.txtpatient_Age.Text=model.patient_Age;
		this.txtpatient_Sex.Text=model.patient_Sex.ToString();
		this.txtpatient_Tel.Text=model.patient_Tel;
		this.txtpatient_WeChatCode.Text=model.patient_WeChatCode;
		this.txtmain_suit.Text=model.main_suit;
		this.txtallergy_history.Text=model.allergy_history;
		this.txtMedical_history.Text=model.Medical_history;
		this.txttherapeutic_schedule.Text=model.therapeutic_schedule;
		this.txtdoctorRemark.Text=model.doctorRemark;
		this.txtcRemark.Text=model.cRemark;
		this.txtemr_status.Text=model.emr_status.ToString();
		this.txtconfirm_time.Text=model.confirm_time.ToString();
		this.txtprocessing_time.Text=model.processing_time.ToString();
		this.txtprocessing_requirement.Text=model.processing_requirement;
		this.txtorder_time.Text=model.order_time.ToString();
		this.txtpay_time.Text=model.pay_time.ToString();
		this.txtproduction_time.Text=model.production_time.ToString();
		this.txtdelivery_time.Text=model.delivery_time.ToString();
		this.txtend_time.Text=model.end_time.ToString();
		this.txtcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.txtmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.txtflag.Text=model.flag.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtpatient_Name.Text.Trim().Length==0)
			{
				strErr+="名字不能为空！\\n";	
			}
			if(this.txtpatient_Age.Text.Trim().Length==0)
			{
				strErr+="年龄不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtpatient_Sex.Text))
			{
				strErr+="性别格式错误！\\n";	
			}
			if(this.txtpatient_Tel.Text.Trim().Length==0)
			{
				strErr+="电话不能为空！\\n";	
			}
			if(this.txtpatient_WeChatCode.Text.Trim().Length==0)
			{
				strErr+="微信（暂时无法得知是否能够获取不能为空！\\n";	
			}
			if(this.txtmain_suit.Text.Trim().Length==0)
			{
				strErr+="主诉不能为空！\\n";	
			}
			if(this.txtallergy_history.Text.Trim().Length==0)
			{
				strErr+="过敏史不能为空！\\n";	
			}
			if(this.txtMedical_history.Text.Trim().Length==0)
			{
				strErr+="治疗史不能为空！\\n";	
			}
			if(this.txttherapeutic_schedule.Text.Trim().Length==0)
			{
				strErr+="治疗方案不能为空！\\n";	
			}
			if(this.txtdoctorRemark.Text.Trim().Length==0)
			{
				strErr+="医生随笔不能为空！\\n";	
			}
			if(this.txtcRemark.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtemr_status.Text))
			{
				strErr+="订单状态格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtconfirm_time.Text))
			{
				strErr+="确定时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtprocessing_time.Text))
			{
				strErr+="加工时间格式错误！\\n";	
			}
			if(this.txtprocessing_requirement.Text.Trim().Length==0)
			{
				strErr+="加工描述不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtorder_time.Text))
			{
				strErr+="接单时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtpay_time.Text))
			{
				strErr+="付款时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtproduction_time.Text))
			{
				strErr+="排产时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtdelivery_time.Text))
			{
				strErr+="发货时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtend_time.Text))
			{
				strErr+="结束时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtcreateDate.Text))
			{
				strErr+="创建时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtmodifyDate.Text))
			{
				strErr+="修改时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtflag.Text))
			{
				strErr+="是否有效格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			Guid Id= new Guid(this.lblId.Text);
			string EMR_Code=this.lblEMR_Code.Text;
			string patient_Name=this.txtpatient_Name.Text;
			string patient_Age=this.txtpatient_Age.Text;
			int patient_Sex=int.Parse(this.txtpatient_Sex.Text);
			string patient_Tel=this.txtpatient_Tel.Text;
			string patient_WeChatCode=this.txtpatient_WeChatCode.Text;
			string main_suit=this.txtmain_suit.Text;
			string allergy_history=this.txtallergy_history.Text;
			string Medical_history=this.txtMedical_history.Text;
			string therapeutic_schedule=this.txttherapeutic_schedule.Text;
			string doctorRemark=this.txtdoctorRemark.Text;
			string cRemark=this.txtcRemark.Text;
			int emr_status=int.Parse(this.txtemr_status.Text);
			DateTime confirm_time=DateTime.Parse(this.txtconfirm_time.Text);
			DateTime processing_time=DateTime.Parse(this.txtprocessing_time.Text);
			string processing_requirement=this.txtprocessing_requirement.Text;
			DateTime order_time=DateTime.Parse(this.txtorder_time.Text);
			DateTime pay_time=DateTime.Parse(this.txtpay_time.Text);
			DateTime production_time=DateTime.Parse(this.txtproduction_time.Text);
			DateTime delivery_time=DateTime.Parse(this.txtdelivery_time.Text);
			DateTime end_time=DateTime.Parse(this.txtend_time.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.simple_EMR model=new DentalMedical.Model.simple_EMR();
			model.Id=Id;
			model.EMR_Code=EMR_Code;
			model.patient_Name=patient_Name;
			model.patient_Age=patient_Age;
			model.patient_Sex=patient_Sex;
			model.patient_Tel=patient_Tel;
			model.patient_WeChatCode=patient_WeChatCode;
			model.main_suit=main_suit;
			model.allergy_history=allergy_history;
			model.Medical_history=Medical_history;
			model.therapeutic_schedule=therapeutic_schedule;
			model.doctorRemark=doctorRemark;
			model.cRemark=cRemark;
			model.emr_status=emr_status;
			model.confirm_time=confirm_time;
			model.processing_time=processing_time;
			model.processing_requirement=processing_requirement;
			model.order_time=order_time;
			model.pay_time=pay_time;
			model.production_time=production_time;
			model.delivery_time=delivery_time;
			model.end_time=end_time;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.simple_EMR bll=new DentalMedical.BLL.simple_EMR();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
