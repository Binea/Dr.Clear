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
namespace DentalMedical.Web.FaceImage
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
		DentalMedical.BLL.FaceImage bll=new DentalMedical.BLL.FaceImage();
		DentalMedical.Model.FaceImage model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblEMR_Code.Text=model.EMR_Code;
		this.lblimagePath.Text=model.imagePath;
		this.lblorderId.Text=model.orderId.ToString();
		this.lblcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.lblmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.lblflag.Text=model.flag.ToString();

	}


    }
}
