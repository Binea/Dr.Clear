using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalMedical.Web.simple_EMR
{
    public partial class delete : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            			if (!Page.IsPostBack)
			{
				DentalMedical.BLL.simple_EMR bll=new DentalMedical.BLL.simple_EMR();
				Guid Id ;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					Id=new Guid(Request.Params["id"]);
				}
				string EMR_Code = "";
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					EMR_Code= Request.Params["id1"];
				}
				#warning 代码生成提示：删除页面,请检查确认传递过来的参数是否正确
				// bll.Delete(Id,EMR_Code);
			}

        }
    }
}