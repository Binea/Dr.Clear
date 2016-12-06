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
		DentalMedical.BLL.sys_logs bll=new DentalMedical.BLL.sys_logs();
		DentalMedical.Model.sys_logs model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lbldoctor_Id.Text=model.doctor_Id.ToString();
		this.txtLogsType.Text=model.LogsType.ToString();
		this.txtEntity.Text=model.Entity;
		this.txtincident.Text=model.incident;
		this.txtIP.Text=model.IP;
		this.txtclientInfo.Text=model.clientInfo;
		this.txtlogmessage.Text=model.logmessage;
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
			Guid Id= new Guid(this.lblId.Text);
			Guid doctor_Id= new Guid(this.lbldoctor_Id.Text);
			int LogsType=int.Parse(this.txtLogsType.Text);
			string Entity=this.txtEntity.Text;
			string incident=this.txtincident.Text;
			string IP=this.txtIP.Text;
			string clientInfo=this.txtclientInfo.Text;
			string logmessage=this.txtlogmessage.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.sys_logs model=new DentalMedical.Model.sys_logs();
			model.Id=Id;
			model.doctor_Id=doctor_Id;
			model.LogsType=LogsType;
			model.Entity=Entity;
			model.incident=incident;
			model.IP=IP;
			model.clientInfo=clientInfo;
			model.logmessage=logmessage;
			model.orderId=orderId;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.sys_logs bll=new DentalMedical.BLL.sys_logs();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
