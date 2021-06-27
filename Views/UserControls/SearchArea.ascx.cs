using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_UserControls_SearchArea : System.Web.UI.UserControl
{
    #region Properties:
    public AccessToPassways Access
    {
        get
        {
            return new AccessToPassways(hid_Access.Value);
        }
        set
        {
            hid_Access.Value = value.GetString();
        }
    }
    #endregion

    #region Event Handlers:
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                FillCombos();
                uc_GoogleMap.ShowCity();
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
    protected void btn_ShowArea_Click(object sender, EventArgs e)
    {
        try
        {
            var center = uc_GoogleMap.GetCenter();
            uc_GoogleMap.ClearShape();
            uc_GoogleMap.DrawCircle(center, Convert.ToInt32(tb_Radius.Text));
            hid_Center.Value = new Models.Location(center.Longitude, center.Latitude).ToString();
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
    protected void grid_items_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            TableCell td1 = (TableCell)e.Row.Controls[0];
            td1.Attributes["class"] = "grid-pager";
            ///////
            Table table1 = (Table)td1.Controls[0];
            table1.Attributes["class"] = "center";
            table1.Attributes["cellspacing"] = "3";
            ///////
            TableRow tr_LinkCellsContainer = (TableRow)table1.Rows[0];
            /////// ge link td :
            for (int i = 0; i < tr_LinkCellsContainer.Controls.Count; i++)
            {
                TableCell td = (TableCell)tr_LinkCellsContainer.Controls[i];
                try
                {
                    Label span = (Label)td.Controls[0];
                    span.CssClass = "grid-pager-selected-link";
                }
                catch
                {
                    LinkButton link = (LinkButton)td.Controls[0];
                    link.CssClass = "grid-pager-link";
                }
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.CssClass = (e.Row.RowIndex % 2 == 0 ? "grid-row-even" : "grid-row-odd");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            #region Gather Values:
            var radius_meters = Convert.ToInt32(tb_Radius.Text);
            double dist = (double)radius_meters / 1000;
            var map_center = uc_GoogleMap.GetCenter();
            var center = !String.IsNullOrEmpty(hid_Center.Value) ?
                new Location(hid_Center.Value) :
                new Location(latitude: map_center.Latitude, longitude: map_center.Longitude);
            var passType = cmb_PasswayType.SelectedIndex > 0 ? Convert.ToInt32(cmb_PasswayType.SelectedValue) : (int?)null;
            var hasName = ch_HasName.Checked;
            var pageSize = Convert.ToInt32(cmb_PageSize.SelectedValue);
            #endregion

            #region Calculate Corners:
            var tl_point = GeoCodeCalc.FindPointAtDistanceFrom(new GeoLocation { Latitude = center.Latitude, Longitude = center.Longitude },
                GeoCodeCalc.DegreesToRadians(315), dist);
            var br_point = GeoCodeCalc.FindPointAtDistanceFrom(new GeoLocation { Latitude = center.Latitude, Longitude = center.Longitude },
                GeoCodeCalc.DegreesToRadians(135), dist);
            #endregion

            //uc_GoogleMap.CreateMarker(new Models.Location(tl_point.Longitude, tl_point.Latitude));
            //uc_GoogleMap.CreateMarker(new Models.Location(tr_point.Longitude, tr_point.Latitude));
            //uc_GoogleMap.CreateMarker(new Models.Location(br_point.Longitude, br_point.Latitude));
            //uc_GoogleMap.CreateMarker(new Models.Location(bl_point.Longitude, bl_point.Latitude));

            #region Query Db:
            var pr = new PasswaysRepository();
            var passways = pr.SearchInArea(new Models.Location(longitude: tl_point.Longitude, latitude: tl_point.Latitude),
                new Models.Location(longitude: br_point.Longitude, latitude: br_point.Latitude),
                passType, hasName, pageSize
                );
            grid_items.DataSource = passways;
            grid_items.DataBind();
            #endregion
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
    #endregion

    #region Methods:
    private void FillCombos()
    {
        cmb_PasswayType.Items.Clear();
        cmb_PasswayType.Items.Add(new ListItem("", ""));
        var passTypes = Pairs.PasswayTypes;
        foreach (KeyValuePair<int, string> pair in passTypes)
        {
            cmb_PasswayType.Items.Add(new ListItem(pair.Value, pair.Key.ToString()));
        }
    }
    #endregion
}