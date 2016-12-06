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
namespace DentalMedical.Web.doctor_certification
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					Guid Id=new Guid(Request.Params["id"]);
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
		this.txtwork_Card.Text=model.work_Card;
		this.txtstatus.Text=model.status.ToString();
		this.txtdh_logo.Text=model.dh_logo;
		this.chkisdefault.Checked=model.isdefault;
		this.txtorderId.Text=model.orderId.ToString();
		this.txtcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.txtmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.txtflag.Text=model.flag.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtwork_Card.Text.Trim().Length==0)
			{
				strErr+="工牌不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtstatus.Text))
			{
				strErr+="状态格式错误！\\n";	
			}
			if(this.txtdh_logo.Text.Trim().Length==0)
			{
				strErr+="二维码不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderId.Text))
			{
				strErr+="排序号格式错误！\\n";	
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
			Guid doctor_Id= new Guid(this.lbldoctor_Id.Text);
			Guid userHospital= new Guid(this.lbluserHospital.Text);
			Guid userDepartment= new Guid(this.lbluserDepartment.Text);
			Guid userTitle= new Guid(this.lbluserTitle.Text);
			string work_Card=this.txtwork_Card.Text;
			int status=int.Parse(this.txtstatus.Text);
			string dh_logo=this.txtdh_logo.Text;
			bool isdefault=this.chkisdefault.Checked;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.doctor_certification model=new DentalMedical.Model.doctor_certification();
			model.Id=Id;
			model.doctor_Id=doctor_Id;
			model.userHospital=userHospital;
			model.userDepartment=userDepartment;
			model.userTitle=userTitle;
			model.work_Card=work_Card;
			model.status=status;
			model.dh_logo=dh_logo;
			model.isdefault=isdefault;
			model.orderId=orderId;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.doctor_certification bll=new DentalMedical.BLL.doctor_certification();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
