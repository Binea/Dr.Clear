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
namespace DentalMedical.Web.payment_info
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
		DentalMedical.BLL.payment_info bll=new DentalMedical.BLL.payment_info();
		DentalMedical.Model.payment_info model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblEMR_Code.Text=model.EMR_Code;
		this.lblfactory_Id.Text=model.factory_Id.ToString();
		this.lblchannel.Text=model.channel;
		this.lbltype.Text=model.type;
		this.lblmoney.Text=model.money.ToString();
		this.lblbill_code.Text=model.bill_code;
		this.lblcRemark.Text=model.cRemark;
		this.lblcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.lblmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.lblflag.Text=model.flag.ToString();

	}


    }
}
