﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalMedical.Web.factory_certification
{
    public partial class delete : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            			if (!Page.IsPostBack)
			{
				DentalMedical.BLL.factory_certification bll=new DentalMedical.BLL.factory_certification();
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					Guid Id=new Guid(Request.Params["id"]);
					bll.Delete(Id);
					Response.Redirect("list.aspx");
				}
			}

        }
    }
}