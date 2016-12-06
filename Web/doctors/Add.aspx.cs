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
namespace DentalMedical.Web.doctors
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuserCode.Text))
			{
				strErr+="用户账户格式错误！\\n";	
			}
			if(this.txtuserTel.Text.Trim().Length==0)
			{
				strErr+="电话不能为空！\\n";	
			}
			if(this.txtuserPwd.Text.Trim().Length==0)
			{
				strErr+="密码不能为空！\\n";	
			}
			if(this.txtuserEmail.Text.Trim().Length==0)
			{
				strErr+="邮箱不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserKey.Text))
			{
				strErr+="验证号格式错误！\\n";	
			}
			if(this.txtuserPetName.Text.Trim().Length==0)
			{
				strErr+="昵称不能为空！\\n";	
			}
			if(this.txtuserLogo.Text.Trim().Length==0)
			{
				strErr+="头像不能为空！\\n";	
			}
			if(this.txtuserRealName.Text.Trim().Length==0)
			{
				strErr+="真名不能为空！\\n";	
			}
			if(this.txtuserAddress.Text.Trim().Length==0)
			{
				strErr+="联系地址不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserWorkYears.Text))
			{
				strErr+="工作年限格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtuserSchool.Text))
			{
				strErr+="毕业院校格式错误！\\n";	
			}
			if(this.txtuserBlog.Text.Trim().Length==0)
			{
				strErr+="博客不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtonlineStatus.Text))
			{
				strErr+="在线状态格式错误！\\n";	
			}
			if(this.txtf_invit_code.Text.Trim().Length==0)
			{
				strErr+="厂房邀请码不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtorderId.Text))
			{
				strErr+="排序号格式错误！\\n";	
			}
			if(this.txtdoctor_Id.Text.Trim().Length==0)
			{
				strErr+="用户号不能为空！\\n";	
			}
			if(this.txtuserRemark.Text.Trim().Length==0)
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
			int userCode=int.Parse(this.txtuserCode.Text);
			string userTel=this.txtuserTel.Text;
			string userPwd=this.txtuserPwd.Text;
			string userEmail=this.txtuserEmail.Text;
			int userKey=int.Parse(this.txtuserKey.Text);
			string userPetName=this.txtuserPetName.Text;
			string userLogo=this.txtuserLogo.Text;
			string userRealName=this.txtuserRealName.Text;
			string userAddress=this.txtuserAddress.Text;
			int userWorkYears=int.Parse(this.txtuserWorkYears.Text);
			int userSchool=int.Parse(this.txtuserSchool.Text);
			string userBlog=this.txtuserBlog.Text;
			int onlineStatus=int.Parse(this.txtonlineStatus.Text);
			string f_invit_code=this.txtf_invit_code.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			string doctor_Id=this.txtdoctor_Id.Text;
			string userRemark=this.txtuserRemark.Text;
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.doctors model=new DentalMedical.Model.doctors();
			model.userCode=userCode;
			model.userTel=userTel;
			model.userPwd=userPwd;
			model.userEmail=userEmail;
			model.userKey=userKey;
			model.userPetName=userPetName;
			model.userLogo=userLogo;
			model.userRealName=userRealName;
			model.userAddress=userAddress;
			model.userWorkYears=userWorkYears;
			model.userSchool=userSchool;
			model.userBlog=userBlog;
			model.onlineStatus=onlineStatus;
			model.f_invit_code=f_invit_code;
			model.orderId=orderId;
			model.doctor_Id=doctor_Id;
			model.userRemark=userRemark;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.doctors bll=new DentalMedical.BLL.doctors();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
