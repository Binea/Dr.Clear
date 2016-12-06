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
namespace DentalMedical.Web.payment_info
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
		DentalMedical.BLL.payment_info bll=new DentalMedical.BLL.payment_info();
		DentalMedical.Model.payment_info model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtEMR_Code.Text=model.EMR_Code;
		this.lblfactory_Id.Text=model.factory_Id.ToString();
		this.txtchannel.Text=model.channel;
		this.txttype.Text=model.type;
		this.txtmoney.Text=model.money.ToString();
		this.txtbill_code.Text=model.bill_code;
		this.txtcRemark.Text=model.cRemark;
		this.txtcreateDate.Text=model.createDate.ToString();
		this.lblcreateId.Text=model.createId.ToString();
		this.txtmodifyDate.Text=model.modifyDate.ToString();
		this.lblmodifyId.Text=model.modifyId.ToString();
		this.txtflag.Text=model.flag.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtEMR_Code.Text.Trim().Length==0)
			{
				strErr+="病历编号不能为空！\\n";	
			}
			if(this.txtchannel.Text.Trim().Length==0)
			{
				strErr+="渠道 支付宝等不能为空！\\n";	
			}
			if(this.txttype.Text.Trim().Length==0)
			{
				strErr+="付款不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtmoney.Text))
			{
				strErr+="金额格式错误！\\n";	
			}
			if(this.txtbill_code.Text.Trim().Length==0)
			{
				strErr+="单号不能为空！\\n";	
			}
			if(this.txtcRemark.Text.Trim().Length==0)
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
			string EMR_Code=this.txtEMR_Code.Text;
			Guid factory_Id= new Guid(this.lblfactory_Id.Text);
			string channel=this.txtchannel.Text;
			string type=this.txttype.Text;
			decimal money=decimal.Parse(this.txtmoney.Text);
			string bill_code=this.txtbill_code.Text;
			string cRemark=this.txtcRemark.Text;
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			Guid createId= new Guid(this.lblcreateId.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			Guid modifyId= new Guid(this.lblmodifyId.Text);
			int flag=int.Parse(this.txtflag.Text);


			DentalMedical.Model.payment_info model=new DentalMedical.Model.payment_info();
			model.Id=Id;
			model.EMR_Code=EMR_Code;
			model.factory_Id=factory_Id;
			model.channel=channel;
			model.type=type;
			model.money=money;
			model.bill_code=bill_code;
			model.cRemark=cRemark;
			model.createDate=createDate;
			model.createId=createId;
			model.modifyDate=modifyDate;
			model.modifyId=modifyId;
			model.flag=flag;

			DentalMedical.BLL.payment_info bll=new DentalMedical.BLL.payment_info();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
