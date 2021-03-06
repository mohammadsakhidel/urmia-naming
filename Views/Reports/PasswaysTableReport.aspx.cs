using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Reports_PasswaysTableReport : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        var sid = Request.QueryString["sid"].ToString();
        if (!string.IsNullOrEmpty(sid)) {
            var records = Session[sid + "-records"] != null ? ((IEnumerable<Models.Passway>)Session[sid + "-records"]).ToList() : null;
            var title = Session[sid + "-title"] != null ? Session[sid + "-title"].ToString() : "";
            if (records != null) {
                var report = new Stimulsoft.Report.StiReport();
                report.Load(Server.MapPath("~/Reports/PasswaysTableReport.mrt"));

                // Variables:
                report.Dictionary.Variables["Title"].Value = title;
                report.Dictionary.Variables["ReportDate"].Value = RamancoLibrary.Utilities.DateTimeUtils.ToShamsi(DateTime.Now).ToString();

                // Data:
                report.RegData("Passways", records);

                rep_viewer.Report = report;
            }
        }
    }
}