﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admins_PasswayPhotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            uc_PasswayPhotos.PasswayID = Convert.ToInt32(Request.QueryString["id"]);
            uc_PasswayPhotos.LoadData();
        }
    }
}