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
namespace DentalMedical.Web.area_BaseData
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
		
	private void ShowInfo()
	{
		DentalMedical.BLL.area_BaseData bll=new DentalMedical.BLL.area_BaseData();
		DentalMedical.Model.area_BaseData model=bll.GetModel();
		this.lblcodeid.Text=model.codeid.ToString();
		this.lblparentid.Text=model.parentid.ToString();
		this.lblcityName.Text=model.cityName;

	}


    }
}
