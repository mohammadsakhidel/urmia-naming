using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Admins_UserAccessRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            uc_AccessRulesEditor.MemberID = Convert.ToInt32(Request.QueryString["id"]);
            uc_AccessRulesEditor.LoadData();
        }
    }
}