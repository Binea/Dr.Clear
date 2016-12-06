using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalMedical.Web.area_BaseData
{
    public partial class delete : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            			if (!Page.IsPostBack)
			{
				DentalMedical.BLL.area_BaseData bll=new DentalMedical.BLL.area_BaseData();
				#warning 代码生成提示：删除页面,请检查确认传递过来的参数是否正确
				// bll.Delete();
			}

        }
    }
}