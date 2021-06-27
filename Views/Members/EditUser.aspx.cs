using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_Members_EditUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MembersRepository mr = new MembersRepository();
        Member editedMember = mr.Get(Convert.ToInt32(Request.QueryString["id"]));
        AccessRule rule = mr.GetAccessRule(HttpContext.Current.User.Identity.Name);
        if (HttpContext.Current.User.Identity.Name == editedMember.UserName || !rule.AccessToMembersObj.Edit)
            throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
        //////////////////////////////
        if (!Page.IsPostBack)
        {
            uc_MemberEditor.MemberID = Convert.ToInt32(Request.QueryString["id"]);
            uc_MemberEditor.LoadData();
        }
    }
}