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
namespace DentalMedical.Web.factory
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
				int factoryCode = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					factoryCode=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(Id,factoryCode);
			}
		}
		
	private void ShowInfo(Guid Id,int factoryCode)
	{
		DentalMedical.BLL.factory bll=new DentalMedical.BLL.factory();
		DentalMedical.Model.factory model=bll.GetModel(Id,factoryCode);
		this.lblId.Text=model.Id.ToString();
		this.lblfactoryCode.Text=model.factoryCode.ToString();
		this.lblfactoryTel.Text=model.factoryTel;
		this.lblfactoryPwd.Text=model.factoryPwd;
		this.lblfactoryEmail.Text=model.factoryEmail;
		this.lblfactoryKey.Text=model.factoryKey.ToString();
		this.lblfactoryLogo.Text=model.factoryLogo;
		this.lblonlineStatus.Text=model.onlineStatus.ToString();
		this.lblfactoryName.Text=model.factoryName;
		this.lblfee.Text=model.fee.ToString();
		this.lblinvit_code.Text=model.invit_code;
		this.lblorderId.Text=model.orderId.ToString();
		this.lblfactoryRemark.Text=model.factoryRemark;
		this.lblcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.lblmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.lblflag.Text=model.flag.ToString();

	}


    }
}
