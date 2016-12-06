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
namespace DentalMedical.Web.factory
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtfactoryCode.Text))
			{
				strErr+="账户格式错误！\\n";	
			}
			if(this.txtfactoryTel.Text.Trim().Length==0)
			{
				strErr+="电话不能为空！\\n";	
			}
			if(this.txtfactoryPwd.Text.Trim().Length==0)
			{
				strErr+="密码不能为空！\\n";	
			}
			if(this.txtfactoryEmail.Text.Trim().Length==0)
			{
				strErr+="邮箱不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtfactoryKey.Text))
			{
				strErr+="验证号格式错误！\\n";	
			}
			if(this.txtfactoryLogo.Text.Trim().Length==0)
			{
				strErr+="厂家logo不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtonlineStatus.Text))
			{
				strErr+="在线状态格式错误！\\n";	
			}
			if(this.txtfactoryName.Text.Trim().Length==0)
			{
				strErr+="厂家名字不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtfee.Text))
			{
				strErr+="厂家服务费格式错误！\\n";	
			}
			if(this.txtinvit_code.Text.Trim().Length==0)
			{
				strErr+="邀请码不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderId.Text))
			{
				strErr+="排序号格式错误！\\n";	
			}
			if(this.txtfactoryRemark.Text.Trim().Length==0)
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
			int factoryCode=int.Parse(this.txtfactoryCode.Text);
			string factoryTel=this.txtfactoryTel.Text;
			string factoryPwd=this.txtfactoryPwd.Text;
			string factoryEmail=this.txtfactoryEmail.Text;
			int factoryKey=int.Parse(this.txtfactoryKey.Text);
			string factoryLogo=this.txtfactoryLogo.Text;
			int onlineStatus=int.Parse(this.txtonlineStatus.Text);
			string factoryName=this.txtfactoryName.Text;
			decimal fee=decimal.Parse(this.txtfee.Text);
			string invit_code=this.txtinvit_code.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			string factoryRemark=this.txtfactoryRemark.Text;
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.factory model=new DentalMedical.Model.factory();
			model.factoryCode=factoryCode;
			model.factoryTel=factoryTel;
			model.factoryPwd=factoryPwd;
			model.factoryEmail=factoryEmail;
			model.factoryKey=factoryKey;
			model.factoryLogo=factoryLogo;
			model.onlineStatus=onlineStatus;
			model.factoryName=factoryName;
			model.fee=fee;
			model.invit_code=invit_code;
			model.orderId=orderId;
			model.factoryRemark=factoryRemark;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.factory bll=new DentalMedical.BLL.factory();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
