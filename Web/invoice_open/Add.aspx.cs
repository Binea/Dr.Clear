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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string invoice_title=this.txtinvoice_title.Text;
			string invoice_openType=this.txtinvoice_openType.Text;
			string invoice_type=this.txtinvoice_type.Text;
			bool isdefault=this.chkisdefault.Checked;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.invoice_open model=new DentalMedical.Model.invoice_open();
			model.invoice_title=invoice_title;
			model.invoice_openType=invoice_openType;
			model.invoice_type=invoice_type;
			model.isdefault=isdefault;
			model.orderId=orderId;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.invoice_open bll=new DentalMedical.BLL.invoice_open();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
