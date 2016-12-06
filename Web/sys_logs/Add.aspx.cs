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
namespace DentalMedical.Web.sys_logs
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtLogsType.Text))
			{
				strErr+="LogsType格式错误！\\n";	
			}
			if(this.txtEntity.Text.Trim().Length==0)
			{
				strErr+="Entity不能为空！\\n";	
			}
			if(this.txtincident.Text.Trim().Length==0)
			{
				strErr+="incident不能为空！\\n";	
			}
			if(this.txtIP.Text.Trim().Length==0)
			{
				strErr+="IP不能为空！\\n";	
			}
			if(this.txtclientInfo.Text.Trim().Length==0)
			{
				strErr+="clientInfo不能为空！\\n";	
			}
			if(this.txtlogmessage.Text.Trim().Length==0)
			{
				strErr+="logmessage不能为空！\\n";	
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
			int LogsType=int.Parse(this.txtLogsType.Text);
			string Entity=this.txtEntity.Text;
			string incident=this.txtincident.Text;
			string IP=this.txtIP.Text;
			string clientInfo=this.txtclientInfo.Text;
			string logmessage=this.txtlogmessage.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.sys_logs model=new DentalMedical.Model.sys_logs();
			model.LogsType=LogsType;
			model.Entity=Entity;
			model.incident=incident;
			model.IP=IP;
			model.clientInfo=clientInfo;
			model.logmessage=logmessage;
			model.orderId=orderId;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.sys_logs bll=new DentalMedical.BLL.sys_logs();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
