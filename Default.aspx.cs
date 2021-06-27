using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            string folderUrl = MyHelper.GetFolderUrl();
            Response.Redirect(folderUrl + "Panel.aspx");
        }
    }
    protected void loginToSite_LoggedIn(object sender, EventArgs e)
    {
        string folderUrl = MyHelper.GetFolderUrl(LoginControl.UserName);
        Response.Redirect(folderUrl + "Panel.aspx");
    }
}