using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using System.Web.Security;

public partial class Views_UserControls_Members : System.Web.UI.UserControl
{
    //********************** properties:
    public AccessToMembers Access
    {
        get
        {
            return new AccessToMembers(hid_Access.Value);
        }
        set
        {
            hid_Access.Value = value.GetString();
        }
    }
    //********************** Methods:
    public void LoadData()
    {
        MembersRepository mr = new MembersRepository();
        var items = mr.GetAll();
        grid_items.DataSource = items;
        grid_items.DataBind();
        if (items.Count() > 0)
        {
            pnl_noItem.Visible = false;
            grid_items.Visible = true;
        }
        else
        {
            pnl_noItem.Visible = true;
            grid_items.Visible = false;
        }
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
        LoadData();
    }
    protected void grid_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMember")
        {
            if (!Access.Delete) throw new Exception("شما دارای حق دسترسی لازم نمی باشید");
            int id = Convert.ToInt32(e.CommandArgument);
            MembersRepository mr = new MembersRepository();
            Member member = mr.Get(id);
            string memberUserName = member.UserName;
            System.Web.Security.Membership.DeleteUser(memberUserName);
            mr.Delete(id);
            if (HttpContext.Current.User.Identity.Name == memberUserName)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Default.aspx");
            }
            //////
            LoadData();
        }
    }
    protected void grid_checkbox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        Control hidden = MyHelper.FindControl(checkbox.Parent.Controls, typeof(HiddenField));
        if (hidden != null)
        {
            int Id = Int32.Parse(((HiddenField)hidden).Value);
            MembersRepository mr = new MembersRepository();
            Member member = mr.Get(Id);
            MembershipUser user = Membership.GetUser(member.UserName);
            user.IsApproved = checkbox.Checked;
            Membership.UpdateUser(user);
            /////////////////////
            LoadData();
        }
    }
}