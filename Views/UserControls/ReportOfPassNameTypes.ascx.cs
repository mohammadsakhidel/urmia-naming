using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using Models;
using Utilities;

public partial class Views_UserControls_ReportOfPassNameTypes : System.Web.UI.UserControl
{

    private DataPoint GetDataPoint()
    {
        DataPoint point = new DataPoint();
        point.Color = MyHelper.GetRandomColor();
        point.Font = new System.Drawing.Font("Tahoma", 10);
        point.IsValueShownAsLabel = true;
        point.LabelForeColor = System.Drawing.Color.Gray;
        return point;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            PasswaysRepository pr = new PasswaysRepository();
            var types = Pairs.PassNameTypes;
            foreach (KeyValuePair<int, string> type in types)
            {
                DataPoint pnt = GetDataPoint();
                pnt.AxisLabel = type.Value;
                int usage = pr.GetNameTypeUsage(type.Key, ShamsiDateTime.FromText(tb_BeginDate.Text).MiladyDate, ShamsiDateTime.FromText(tb_EndDate.Text).MiladyDate, Convert.ToInt32(cmb_Region.SelectedValue));
                pnt.YValues = new double[] { usage };
                chart_Report.Series["chart_Report_Series"].Points.Add(pnt);
            }
            chart_Report.Visible = true;
        }
        catch(Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}