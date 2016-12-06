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
namespace DentalMedical.Web.message_info
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
		DentalMedical.BLL.message_info bll=new DentalMedical.BLL.message_info();
		DentalMedical.Model.message_info model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtmobilePhone.Text=model.mobilePhone.ToString();
		this.txtmtype.Text=model.mtype.ToString();
		this.txtvalidation_Code.Text=model.validation_Code;
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
			if(!PageValidate.IsNumber(txtmobilePhone.Text))
			{
				strErr+="手机号格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtmtype.Text))
			{
				strErr+="短信类型格式错误！\\n";	
			}
			if(this.txtvalidation_Code.Text.Trim().Length==0)
			{
				strErr+="手机短信验证号不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderId.Text))
			{
				strErr+="序号格式错误！\\n";	
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
			int mobilePhone=int.Parse(this.txtmobilePhone.Text);
			int mtype=int.Parse(this.txtmtype.Text);
			string validation_Code=this.txtvalidation_Code.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.message_info model=new DentalMedical.Model.message_info();
			model.Id=Id;
			model.mobilePhone=mobilePhone;
			model.mtype=mtype;
			model.validation_Code=validation_Code;
			model.orderId=orderId;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.message_info bll=new DentalMedical.BLL.message_info();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
