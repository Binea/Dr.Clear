using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalMedical.Web.factory
{
    public partial class delete : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            			if (!Page.IsPostBack)
			{
				DentalMedical.BLL.factory bll=new DentalMedical.BLL.factory();
				Guid Id ;
				if (Request.Params["id0"] != null && Request.Params["id0"].Trim() != "")
				{
					Id=new Guid(Request.Params["id"]);
				}
				int factoryCode = -1;
				if (Request.Params["id1"] != null && Request.Params["id1"].Trim() != "")
				{
					factoryCode=(Convert.ToInt32(Request.Params["id1"]));
				}
				#warning 代码生成提示：删除页面,请检查确认传递过来的参数是否正确
				// bll.Delete(Id,factoryCode);
			}

        }
    }
}