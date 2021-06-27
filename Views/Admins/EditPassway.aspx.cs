using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admins_EditPassway : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            uc_PasswayEditor.PasswayID = id;
            uc_PasswayEditor.LoadForm();
        }
    }
}