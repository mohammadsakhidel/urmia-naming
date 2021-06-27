using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Views_UserControls_Passways : System.Web.UI.UserControl
{
    //********************** properties:
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
    //********************** Methods:
    public void LoadData(IEnumerable<Passway> items)
    {
        grid_items.DataSource = items.ToList();
        grid_items.DataBind();
        pnl_grid.Visible = true;
        pnl_noItem.Visible = false;
        lblCount.Text = String.Format("تعداد رکوردها: {0}", items.Count());
    }
    //********************** Event Handlers:
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            var found = uc_SearchPassway.Search();
            if (found.Count() > 0)
            {
                LoadData(found);
            }
            else
            {
                pnl_grid.Visible = false;
                pnl_noItem.Visible = true;
            }
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

    protected void grid_items_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_items.PageIndex = e.NewPageIndex;
        LoadData(uc_SearchPassway.Search());
    }

    protected void grid_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeletePass")
        {
            if (!Access.Delete) throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
            int id = Convert.ToInt32(e.CommandArgument);
            PasswaysRepository pr = new PasswaysRepository();
            pr.Delete(id);
            ///////////////
            LoadData(uc_SearchPassway.Search());
        }
    }
}