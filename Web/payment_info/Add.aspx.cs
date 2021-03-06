﻿using System;
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
			string EMR_Code=this.txtEMR_Code.Text;
			string channel=this.txtchannel.Text;
			string type=this.txttype.Text;
			decimal money=decimal.Parse(this.txtmoney.Text);
			string bill_code=this.txtbill_code.Text;
			string cRemark=this.txtcRemark.Text;
			DateTime createDate=DateTime.Parse(this.txtcreateDate.Text);
			DateTime modifyDate=DateTime.Parse(this.txtmodifyDate.Text);
			int flag=int.Parse(this.txtflag.Text);

			DentalMedical.Model.payment_info model=new DentalMedical.Model.payment_info();
			model.EMR_Code=EMR_Code;
			model.channel=channel;
			model.type=type;
			model.money=money;
			model.bill_code=bill_code;
			model.cRemark=cRemark;
			model.createDate=createDate;
			model.modifyDate=modifyDate;
			model.flag=flag;

			DentalMedical.BLL.payment_info bll=new DentalMedical.BLL.payment_info();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
