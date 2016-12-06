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
namespace DentalMedical.Web.hospitals
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
		DentalMedical.BLL.hospitals bll=new DentalMedical.BLL.hospitals();
		DentalMedical.Model.hospitals model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txthospitalName.Text=model.hospitalName;
		this.txthospitalEName.Text=model.hospitalEName;
		this.txthospitalCode.Text=model.hospitalCode;
		this.txthospitalAddress.Text=model.hospitalAddress;
		this.txthospitalTel.Text=model.hospitalTel;
		this.txthospitalWeb.Text=model.hospitalWeb;
		this.txthospitalIntroduction.Text=model.hospitalIntroduction;
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
			if(this.txthospitalName.Text.Trim().Length==0)
			{
				strErr+="hospitalName不能为空！\\n";	
			}
			if(this.txthospitalEName.Text.Trim().Length==0)
			{
				strErr+="hospitalEName不能为空！\\n";	
			}
			if(this.txthospitalCode.Text.Trim().Length==0)
			{
				strErr+="hospitalCode不能为空！\\n";	
			}
			if(this.txthospitalAddress.Text.Trim().Length==0)
			{
				strErr+="hospitalAddress不能为空！\\n";	
			}
			if(this.txthospitalTel.Text.Trim().Length==0)
			{
				strErr+="hospitalTel不能为空！\\n";	
			}
			if(this.txthospitalWeb.Text.Trim().Length==0)
			{
				strErr+="hospitalWeb不能为空！\\n";	
			}
			if(this.txthospitalIntroduction.Text.Trim().Length==0)
			{
				strErr+="hospitalIntroduction不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderId.Text))
			{
				strErr+="orderId格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtcreateDate.Text))
			{
				strErr+="createDate格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtmodifyDate.Text))
			{
				strErr+="modifyDate格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtflag.Text))
			{
				strErr+="flag格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			Guid Id= new Guid(this.lblId.Text);
			string hospitalName=this.txthospitalName.Text;
			string hospitalEName=this.txthospitalEName.Text;
			string hospitalCode=this.txthospitalCode.Text;
			string hospitalAddress=this.txthospitalAddress.Text;
			string hospitalTel=this.txthospitalTel.Text;
			string hospitalWeb=this.txthospitalWeb.Text;
			string hospitalIntroduction=this.txthospitalIntroduction.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.hospitals model=new DentalMedical.Model.hospitals();
			model.Id=Id;
			model.hospitalName=hospitalName;
			model.hospitalEName=hospitalEName;
			model.hospitalCode=hospitalCode;
			model.hospitalAddress=hospitalAddress;
			model.hospitalTel=hospitalTel;
			model.hospitalWeb=hospitalWeb;
			model.hospitalIntroduction=hospitalIntroduction;
			model.orderId=orderId;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.hospitals bll=new DentalMedical.BLL.hospitals();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
