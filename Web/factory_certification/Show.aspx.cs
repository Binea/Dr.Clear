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
namespace DentalMedical.Web.factory_certification
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
		DentalMedical.BLL.factory_certification bll=new DentalMedical.BLL.factory_certification();
		DentalMedical.Model.factory_certification model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblfactory_Id.Text=model.factory_Id.ToString();
		this.lbllegal_Person.Text=model.legal_Person;
		this.lblorganization_Code.Text=model.organization_Code;
		this.lblmain_Person.Text=model.main_Person;
		this.lblmain_Tel.Text=model.main_Tel;
		this.lblbusiness_license.Text=model.business_license;
		this.lblLegal_ID.Text=model.Legal_ID;
		this.lblfactory_Address.Text=model.factory_Address;
		this.lblmedical_license.Text=model.medical_license;
		this.lblinstrument_license.Text=model.instrument_license;
		this.lblstatus.Text=model.status.ToString();
		this.lblorderId.Text=model.orderId.ToString();
		this.lblcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.lblmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.lblflag.Text=model.flag.ToString();

	}


    }
}
