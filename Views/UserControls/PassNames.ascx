<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PassNames.ascx.cs" Inherits="Views_UserControls_PassNames" %>
<%@ Register Src="~/Views/UserControls/SearchPassNames.ascx" TagPrefix="uc" TagName="SearchPassNames" %>

<uc:SearchPassNames runat="server" ID="uc_SearchPassNames"/>

<div style="padding-top: 10px;">

    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-submit" OnClick="LinkButton1_Click">جستجو</asp:LinkButton>

</div>

<div style="padding-top: 10px;">
    
    <asp:GridView ID="grid_items" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-CssClass="grid-header"
        CssClass="grid" AllowPaging="true" PageSize="15" AllowSorting="false" GridLines="Horizontal" 
        OnRowCreated="grid_items_RowCreated" OnPageIndexChanging="grid_items_PageIndexChanging" OnRowCommand="grid_items_RowCommand">
        <Columns>

            <asp:TemplateField HeaderText="نام" ItemStyle-CssClass="grid-item">
                <ItemTemplate>
                    <span title="<%# Eval("Description") %>"><%# Eval("Name") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="نوع" DataField="TypeText" ItemStyle-CssClass="grid-item" />
            <asp:BoundField HeaderText="وضعیت" DataField="StatusText" ItemStyle-CssClass="grid-item" />
            <asp:TemplateField ItemStyle-Width="90px">
                <ItemTemplate>

                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="grid-button grid-button-details" ToolTip="مشاهده جزئیات" Visible='<%# Access.Details %>'
                        NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "PassNameDetails.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>&nbsp;

                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="grid-button grid-button-edit" ToolTip="ویرایش اطلاعات" Visible='<%# Access.Edit %>'
                        NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "EditPassName.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>&nbsp;

                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="grid-button grid-button-delete" Visible='<%# Access.Delete %>'
                        OnClientClick="return confirm('آیا اطمینان دارید؟');" CommandName="DeletePassName" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف"></asp:LinkButton>

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

</div>

<!-- ********************** hidden fields ********************** -->
<asp:HiddenField ID="hid_Access" runat="server" Value="11111"/>
