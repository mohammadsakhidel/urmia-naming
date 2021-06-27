using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Members_PasswayDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MembersRepository mr = new MembersRepository();
        AccessRule rule = mr.GetAccessRule(HttpContext.Current.User.Identity.Name);
        if (!rule.AccessToPasswaysObj.Details)
            throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
        /////////////////////////
        if (!Page.IsPostBack)
        {
            uc_PasswayDetails.PasswayID = Convert.ToInt32(Request.QueryString["id"]);
            uc_PasswayDetails.LoadData();
        }
    }
}