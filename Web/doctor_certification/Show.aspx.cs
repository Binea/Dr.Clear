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
namespace DentalMedical.Web.doctor_certification
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					Guid Id=new Guid(strid);
					ShowInfo(Id);
				}
			}
		}
		
	private void ShowInfo(Guid Id)
	{
		DentalMedical.BLL.doctor_certification bll=new DentalMedical.BLL.doctor_certification();
		DentalMedical.Model.doctor_certification model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lbldoctor_Id.Text=model.doctor_Id.ToString();
		this.lbluserHospital.Text=model.userHospital.ToString();
		this.lbluserDepartment.Text=model.userDepartment.ToString();
		this.lbluserTitle.Text=model.userTitle.ToString();
		this.lblwork_Card.Text=model.work_Card;
		this.lblstatus.Text=model.status.ToString();
		this.lbldh_logo.Text=model.dh_logo;
		this.lblisdefault.Text=model.isdefault?"是":"否";
		this.lblorderId.Text=model.orderId.ToString();
		this.lblcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.lblmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.lblflag.Text=model.flag.ToString();

	}


    }
}
