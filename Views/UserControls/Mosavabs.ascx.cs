using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_Mosavabs : System.Web.UI.UserControl
{
    //********************** properties:
    public AccessToMosavabs Access
    {
        get
        {
            return new AccessToMosavabs(hid_Access.Value);
        }
        set
        {
            hid_Access.Value = value.GetString();
        }
    }
    //********************** Methods:
    public void LoadData(IEnumerable<Mosavab> items)
    {
        grid_items.DataSource = items;
        grid_items.DataBind();
        pnl_noItem.Visible = false;
        grid_items.Visible = true;
    }
    //********************** Event Handlers:
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
    protected void grid_items_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_items.PageIndex = e.NewPageIndex;
        LoadData(uc_SearchMosavab.Search());
    }
    protected void grid_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMosavab")
        {
            if (!Access.Delete) throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
            MosavabsRepository mr = new MosavabsRepository();
            mr.Delete(Convert.ToInt32(e.CommandArgument));
            LoadData(uc_SearchMosavab.Search());
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            var found = uc_SearchMosavab.Search();
            if (found.Count() > 0)
            {
                LoadData(found);
            }
            else
            {
                grid_items.Visible = false;
                pnl_noItem.Visible = true;
            }
        }
        catch (Exception ex)
        {
            MyHelper.MessageBoxShow(ex.Message, (Control)sender);
        }
    }
}