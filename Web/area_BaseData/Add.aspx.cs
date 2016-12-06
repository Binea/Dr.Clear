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
namespace DentalMedical.Web.area_BaseData
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtcodeid.Text))
			{
				strErr+="codeid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtparentid.Text))
			{
				strErr+="parentid格式错误！\\n";	
			}
			if(this.txtcityName.Text.Trim().Length==0)
			{
				strErr+="cityName不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int codeid=int.Parse(this.txtcodeid.Text);
			int parentid=int.Parse(this.txtparentid.Text);
			string cityName=this.txtcityName.Text;

			DentalMedical.Model.area_BaseData model=new DentalMedical.Model.area_BaseData();
			model.codeid=codeid;
			model.parentid=parentid;
			model.cityName=cityName;

			DentalMedical.BLL.area_BaseData bll=new DentalMedical.BLL.area_BaseData();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
