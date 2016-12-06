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
namespace DentalMedical.Web.factory_certification
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtlegal_Person.Text.Trim().Length==0)
			{
				strErr+="法人不能为空！\\n";	
			}
			if(this.txtorganization_Code.Text.Trim().Length==0)
			{
				strErr+="组织机构代码不能为空！\\n";	
			}
			if(this.txtmain_Person.Text.Trim().Length==0)
			{
				strErr+="主要联系人不能为空！\\n";	
			}
			if(this.txtmain_Tel.Text.Trim().Length==0)
			{
				strErr+="联系人电话不能为空！\\n";	
			}
			if(this.txtbusiness_license.Text.Trim().Length==0)
			{
				strErr+="营业执照不能为空！\\n";	
			}
			if(this.txtLegal_ID.Text.Trim().Length==0)
			{
				strErr+="法人身份证不能为空！\\n";	
			}
			if(this.txtfactory_Address.Text.Trim().Length==0)
			{
				strErr+="地址不能为空！\\n";	
			}
			if(this.txtmedical_license.Text.Trim().Length==0)
			{
				strErr+="医疗企业生产许可证不能为空！\\n";	
			}
			if(this.txtinstrument_license.Text.Trim().Length==0)
			{
				strErr+="医疗器械产品注册证不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtstatus.Text))
			{
				strErr+="状态格式错误！\\n";	
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
			string legal_Person=this.txtlegal_Person.Text;
			string organization_Code=this.txtorganization_Code.Text;
			string main_Person=this.txtmain_Person.Text;
			string main_Tel=this.txtmain_Tel.Text;
			string business_license=this.txtbusiness_license.Text;
			string Legal_ID=this.txtLegal_ID.Text;
			string factory_Address=this.txtfactory_Address.Text;
			string medical_license=this.txtmedical_license.Text;
			string instrument_license=this.txtinstrument_license.Text;
			int status=int.Parse(this.txtstatus.Text);
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.factory_certification model=new DentalMedical.Model.factory_certification();
			model.legal_Person=legal_Person;
			model.organization_Code=organization_Code;
			model.main_Person=main_Person;
			model.main_Tel=main_Tel;
			model.business_license=business_license;
			model.Legal_ID=Legal_ID;
			model.factory_Address=factory_Address;
			model.medical_license=medical_license;
			model.instrument_license=instrument_license;
			model.status=status;
			model.orderId=orderId;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.factory_certification bll=new DentalMedical.BLL.factory_certification();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
