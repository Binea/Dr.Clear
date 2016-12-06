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
namespace DentalMedical.Web.logistics_info
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtEMR_Code.Text.Trim().Length==0)
			{
				strErr+="病历编号不能为空！\\n";	
			}
			if(this.txtexpressName.Text.Trim().Length==0)
			{
				strErr+="快递公司不能为空！\\n";	
			}
			if(this.txtexpress_billCode.Text.Trim().Length==0)
			{
				strErr+="快递编号不能为空！\\n";	
			}
			if(this.txtcRemark.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
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
			string EMR_Code=this.txtEMR_Code.Text;
			string expressName=this.txtexpressName.Text;
			string express_billCode=this.txtexpress_billCode.Text;
			string cRemark=this.txtcRemark.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.logistics_info model=new DentalMedical.Model.logistics_info();
			model.EMR_Code=EMR_Code;
			model.expressName=expressName;
			model.express_billCode=express_billCode;
			model.cRemark=cRemark;
			model.orderId=orderId;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.logistics_info bll=new DentalMedical.BLL.logistics_info();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
