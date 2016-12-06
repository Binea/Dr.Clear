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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Guid Id;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					Id= Request.Params["id0"];
				}
				int factoryCode = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					factoryCode=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo(Id,factoryCode);
			}
		}
			
	private void ShowInfo(Guid Id,int factoryCode)
	{
		DentalMedical.BLL.factory bll=new DentalMedical.BLL.factory();
		DentalMedical.Model.factory model=bll.GetModel(Id,factoryCode);
		this.lblId.Text=model.Id.ToString();
		this.lblfactoryCode.Text=model.factoryCode.ToString();
		this.txtfactoryTel.Text=model.factoryTel;
		this.txtfactoryPwd.Text=model.factoryPwd;
		this.txtfactoryEmail.Text=model.factoryEmail;
		this.txtfactoryKey.Text=model.factoryKey.ToString();
		this.txtfactoryLogo.Text=model.factoryLogo;
		this.txtonlineStatus.Text=model.onlineStatus.ToString();
		this.txtfactoryName.Text=model.factoryName;
		this.txtfee.Text=model.fee.ToString();
		this.txtinvit_code.Text=model.invit_code;
		this.txtorderId.Text=model.orderId.ToString();
		this.txtfactoryRemark.Text=model.factoryRemark;
		this.txtcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.txtmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.txtflag.Text=model.flag.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			Guid Id= new Guid(this.lblId.Text);
			int factoryCode=int.Parse(this.lblfactoryCode.Text);
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
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.factory model=new DentalMedical.Model.factory();
			model.Id=Id;
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
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.factory bll=new DentalMedical.BLL.factory();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
