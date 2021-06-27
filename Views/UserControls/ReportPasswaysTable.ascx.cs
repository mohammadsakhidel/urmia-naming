using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UserControls_ReportPasswaysTable : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnSubmit_Click(object sender, EventArgs e) {

        var passways = ucSearchPassway.Search();
        var randomId = MyHelper.GetRandomString(6, true);

        Session[String.Format("{0}-{1}", randomId, "records")] = passways;
        Session[String.Format("{0}-{1}", randomId, "title")] = tbReportTitle.Text;

        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + MyHelper.Url("~/views/reports/passwaystablereport.aspx?sid=" + randomId) + "','_newtab');", true);

    }
}