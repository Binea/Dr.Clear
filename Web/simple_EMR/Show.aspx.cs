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
namespace DentalMedical.Web.simple_EMR
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Guid Id ;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					Id=new Guid(Request.Params["id"]);
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
		this.lblpatient_Name.Text=model.patient_Name;
		this.lblpatient_Age.Text=model.patient_Age;
		this.lblpatient_Sex.Text=model.patient_Sex.ToString();
		this.lblpatient_Tel.Text=model.patient_Tel;
		this.lblpatient_WeChatCode.Text=model.patient_WeChatCode;
		this.lblmain_suit.Text=model.main_suit;
		this.lblallergy_history.Text=model.allergy_history;
		this.lblMedical_history.Text=model.Medical_history;
		this.lbltherapeutic_schedule.Text=model.therapeutic_schedule;
		this.lbldoctorRemark.Text=model.doctorRemark;
		this.lblcRemark.Text=model.cRemark;
		this.lblemr_status.Text=model.emr_status.ToString();
		this.lblconfirm_time.Text=model.confirm_time.ToString();
		this.lblprocessing_time.Text=model.processing_time.ToString();
		this.lblprocessing_requirement.Text=model.processing_requirement;
		this.lblorder_time.Text=model.order_time.ToString();
		this.lblpay_time.Text=model.pay_time.ToString();
		this.lblproduction_time.Text=model.production_time.ToString();
		this.lbldelivery_time.Text=model.delivery_time.ToString();
		this.lblend_time.Text=model.end_time.ToString();
		this.lblcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.lblmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.lblflag.Text=model.flag.ToString();

	}


    }
}
