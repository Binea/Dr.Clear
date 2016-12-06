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
namespace DentalMedical.Web.express_info
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtcompanyName.Text.Trim().Length==0)
			{
				strErr+="companyName不能为空！\\n";	
			}
			if(this.txtcompanyCode.Text.Trim().Length==0)
			{
				strErr+="companyCode不能为空！\\n";	
			}
			if(this.txtcompanyApi.Text.Trim().Length==0)
			{
				strErr+="companyApi不能为空！\\n";	
			}
			if(this.txtcodeRole.Text.Trim().Length==0)
			{
				strErr+="codeRole不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderId.Text))
			{
				strErr+="排序格式错误！\\n";	
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
			string companyName=this.txtcompanyName.Text;
			string companyCode=this.txtcompanyCode.Text;
			string companyApi=this.txtcompanyApi.Text;
			string codeRole=this.txtcodeRole.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.express_info model=new DentalMedical.Model.express_info();
			model.companyName=companyName;
			model.companyCode=companyCode;
			model.companyApi=companyApi;
			model.codeRole=codeRole;
			model.orderId=orderId;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.express_info bll=new DentalMedical.BLL.express_info();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
