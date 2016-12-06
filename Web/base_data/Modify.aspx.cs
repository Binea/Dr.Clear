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
namespace DentalMedical.Web.base_data
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
		DentalMedical.BLL.base_data bll=new DentalMedical.BLL.base_data();
		DentalMedical.Model.base_data model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txttypeName.Text=model.typeName;
		this.txttype.Text=model.type;
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
			if(this.txttypeName.Text.Trim().Length==0)
			{
				strErr+="typeName不能为空！\\n";	
			}
			if(this.txttype.Text.Trim().Length==0)
			{
				strErr+="type不能为空！\\n";	
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
			string typeName=this.txttypeName.Text;
			string type=this.txttype.Text;
			int orderId=int.Parse(this.txtorderId.Text);
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.base_data model=new DentalMedical.Model.base_data();
			model.Id=Id;
			model.typeName=typeName;
			model.type=type;
			model.orderId=orderId;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.base_data bll=new DentalMedical.BLL.base_data();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
