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
namespace DentalMedical.Web.invoice_info
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
		DentalMedical.BLL.invoice_info bll=new DentalMedical.BLL.invoice_info();
		DentalMedical.Model.invoice_info model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtexpressName.Text=model.expressName;
		this.txtexpressCode.Text=model.expressCode;
		this.txttotal_amount.Text=model.total_amount.ToString();
		this.lblioId.Text=model.ioId.ToString();
		this.txtcRemark.Text=model.cRemark;
		this.txtcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.txtmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.txtflag.Text=model.flag.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtexpressName.Text.Trim().Length==0)
			{
				strErr+="expressName不能为空！\\n";	
			}
			if(this.txtexpressCode.Text.Trim().Length==0)
			{
				strErr+="expressCode不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txttotal_amount.Text))
			{
				strErr+="total_amount格式错误！\\n";	
			}
			if(this.txtcRemark.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
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
			string expressName=this.txtexpressName.Text;
			string expressCode=this.txtexpressCode.Text;
			decimal total_amount=decimal.Parse(this.txttotal_amount.Text);
			Guid ioId= new Guid(this.lblioId.Text);
			string cRemark=this.txtcRemark.Text;
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.invoice_info model=new DentalMedical.Model.invoice_info();
			model.Id=Id;
			model.expressName=expressName;
			model.expressCode=expressCode;
			model.total_amount=total_amount;
			model.ioId=ioId;
			model.cRemark=cRemark;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.invoice_info bll=new DentalMedical.BLL.invoice_info();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
