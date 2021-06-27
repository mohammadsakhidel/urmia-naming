using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Reports_PasswaysDynamicReport : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        try {

            var sid = Request.QueryString["sid"].ToString();
            if (!string.IsNullOrEmpty(sid)) {
                var mrtBytes = Session[sid + "-mrt"] != null ? (byte[])Session[sid + "-mrt"] : null;
                var passways = Session[sid + "-records"] != null ? ((IEnumerable<Models.Passway>)Session[sid + "-records"]).ToList() : null;
                if (passways != null && mrtBytes != null) {

                    var report = new Stimulsoft.Report.StiReport();
                    report.Load(mrtBytes);

                    // Variables:
                    if (report.Dictionary.Variables.Contains("ReportDate"))
                        report.Dictionary.Variables["ReportDate"].Value = RamancoLibrary.Utilities.DateTimeUtils.ToShamsi(DateTime.Now).ToString();

                    // Data:
                    report.RegData("Passways", passways);

                    rep_viewer.Report = report;
                } else {
                    throw new Exception("موردی جهت نمایش موجود نیست.");
                }
            }

        } catch (Exception ex) {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}