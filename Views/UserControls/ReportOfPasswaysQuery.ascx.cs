using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UserControls_ReportOfPasswaysQuery : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void btnSubmit_Click(object sender, EventArgs e) {
        try {
            var query = String.Format("SELECT * FROM Passways {0}", tbQuery.Text);
            var isQueryValid = ValidateQuery(query);
            if (!isQueryValid)
                throw new Exception("پرس و جو معتبر نیست.");

            var repo = new PasswaysRepository();
            var passways = repo.ExecuteQuery(query);
            var randomId = MyHelper.GetRandomString(6, true);

            Session[String.Format("{0}-{1}", randomId, "records")] = passways;
            Session[String.Format("{0}-{1}", randomId, "title")] = tbReportTitle.Text;

            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + MyHelper.Url("~/views/reports/passwaysqueryreport.aspx?sid=" + randomId) + "','_newtab');", true);

        } catch (Exception ex) {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }

    private bool ValidateQuery(string sql) {
        try {
            using (var connection = new SqlConnection(MyHelper.ConnectionString))
            using (var command = new SqlCommand(sql, connection)) {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        } catch {
            return false;
        }
    }
}