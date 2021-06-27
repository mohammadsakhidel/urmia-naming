<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Members.ascx.cs" Inherits="Views_UserControls_Members" %>

<asp:GridView ID="grid_items" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-CssClass="grid-header"
    CssClass="grid" AllowPaging="true" PageSize="15" AllowSorting="false" GridLines="Horizontal" 
    OnRowCreated="grid_items_RowCreated" OnPageIndexChanging="grid_items_PageIndexChanging" OnRowCommand="grid_items_RowCommand">
    <Columns>

        <asp:TemplateField HeaderText="فعال/غیرفعال" ItemStyle-CssClass="grid-item">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="grid_checkbox_CheckedChanged" 
                    AutoPostBack="true" Checked='<%# Eval("IsApproved") %>' Visible='<%# (HttpContext.Current.User.Identity.Name != Eval("UserName").ToString()) && Access.Edit %>'/>
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="نام کامل" DataField="FullName" ItemStyle-CssClass="grid-item" />
        <asp:BoundField HeaderText="نام کاربری" DataField="UserName" ItemStyle-CssClass="grid-item" />
        <asp:BoundField HeaderText="سازمان" DataField="Organization" ItemStyle-CssClass="grid-item" />
        <asp:BoundField HeaderText="سمت" DataField="Position" ItemStyle-CssClass="grid-item" />
        <asp:TemplateField ItemStyle-Width="90px">
            <ItemTemplate>

                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="grid-button grid-button-access" ToolTip="سطح دسترسی" Visible='<%# (HttpContext.Current.User.Identity.Name != Eval("UserName").ToString()) && Access.AccessRules %>'
                    NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "UserAccessRules.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>

                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="grid-button grid-button-edit" ToolTip="ویرایش اطلاعات" Visible='<%# (HttpContext.Current.User.Identity.Name != Eval("UserName").ToString()) && Access.Edit %>'
                    NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "EditUser.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>

                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="grid-button grid-button-delete" 
                    OnClientClick="return confirm('آیا اطمینان دارید؟');" Visible='<%# (HttpContext.Current.User.Identity.Name != Eval("UserName").ToString()) && Access.Delete %>'
                    CommandName="DeleteMember" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف"></asp:LinkButton>

            </ItemTemplate>
        </asp:TemplateField>
            
    </Columns>
</asp:GridView>

<asp:Panel ID="pnl_noItem" runat="server" CssClass="no-items" Visible="false">
    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td>
                <div class="error-icon"></div>
            </td>
            <td class="td_pad1">
                موردی جهت نمایش وجود ندارد.
            </td>
        </tr>
    </table>
</asp:Panel>

<!-- ********************** hidden fields ********************** -->
<asp:HiddenField ID="hid_Access" runat="server" Value="11111"/>