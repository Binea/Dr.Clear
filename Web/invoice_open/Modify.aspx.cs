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
namespace DentalMedical.Web.invoice_open
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
		DentalMedical.BLL.invoice_open bll=new DentalMedical.BLL.invoice_open();
		DentalMedical.Model.invoice_open model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblfactoryId.Text=model.factoryId.ToString();
		this.txtinvoice_title.Text=model.invoice_title;
		this.txtinvoice_openType.Text=model.invoice_openType;
		this.txtinvoice_type.Text=model.invoice_type;
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
			if(this.txtinvoice_title.Text.Trim().Length==0)
			{
				strErr+="invoice_title不能为空！\\n";	
			}
			if(this.txtinvoice_openType.Text.Trim().Length==0)
			{
				strErr+="invoice_openType不能为空！\\n";	
			}
			if(this.txtinvoice_type.Text.Trim().Length==0)
			{
				strErr+="invoice_type不能为空！\\n";	
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
			Guid factoryId= new Guid(this.lblfactoryId.Text);
			string invoice_title=this.txtinvoice_title.Text;
			string invoice_openType=this.txtinvoice_openType.Text;
			string invoice_type=this.txtinvoice_type.Text;
			bool isdefault=this.chkisdefault.Checked;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.invoice_open model=new DentalMedical.Model.invoice_open();
			model.Id=Id;
			model.factoryId=factoryId;
			model.invoice_title=invoice_title;
			model.invoice_openType=invoice_openType;
			model.invoice_type=invoice_type;
			model.isdefault=isdefault;
			model.orderId=orderId;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.invoice_open bll=new DentalMedical.BLL.invoice_open();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
