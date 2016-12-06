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
namespace DentalMedical.Web.doctors
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
				int userCode = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					userCode=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(Id,userCode);
			}
		}
		
	private void ShowInfo(Guid Id,int userCode)
	{
		DentalMedical.BLL.doctors bll=new DentalMedical.BLL.doctors();
		DentalMedical.Model.doctors model=bll.GetModel(Id,userCode);
		this.lblId.Text=model.Id.ToString();
		this.lbluserCode.Text=model.userCode.ToString();
		this.lbluserTel.Text=model.userTel;
		this.lbluserPwd.Text=model.userPwd;
		this.lbluserEmail.Text=model.userEmail;
		this.lbluserKey.Text=model.userKey.ToString();
		this.lbluserPetName.Text=model.userPetName;
		this.lbluserLogo.Text=model.userLogo;
		this.lbluserRealName.Text=model.userRealName;
		this.lbluserAddress.Text=model.userAddress;
		this.lbluserWorkYears.Text=model.userWorkYears.ToString();
		this.lbluserSchool.Text=model.userSchool.ToString();
		this.lbluserBlog.Text=model.userBlog;
		this.lblonlineStatus.Text=model.onlineStatus.ToString();
		this.lblf_invit_code.Text=model.f_invit_code;
		this.lblorderId.Text=model.orderId.ToString();
		this.lbldoctor_Id.Text=model.doctor_Id;
		this.lbluserRemark.Text=model.userRemark;
		this.lblcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.lblmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.lblflag.Text=model.flag.ToString();

	}


    }
}
