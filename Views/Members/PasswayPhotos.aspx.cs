using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Members_PasswayPhotos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MembersRepository mr = new MembersRepository();
        AccessRule rule = mr.GetAccessRule(HttpContext.Current.User.Identity.Name);
        if (!rule.AccessToPasswaysObj.Photos)
            throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
        uc_PasswayPhotos.Access = rule.AccessToPasswaysObj;
        //////////////////////////////
        if (!Page.IsPostBack)
        {
            uc_PasswayPhotos.PasswayID = Convert.ToInt32(Request.QueryString["id"]);
            uc_PasswayPhotos.LoadData();
        }
    }
}