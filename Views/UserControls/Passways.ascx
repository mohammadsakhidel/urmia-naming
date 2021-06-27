<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Passways.ascx.cs" Inherits="Views_UserControls_Passways" %>
<%@ Register Src="~/Views/UserControls/SearchPassway.ascx" TagPrefix="uc" TagName="SearchPassway" %>

<uc:SearchPassway runat="server" ID="uc_SearchPassway" />

<div style="padding-top: 10px;">

    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-submit" OnClick="Button1_Click">جستجو</asp:LinkButton>

</div>

<div style="padding-top: 10px;">

    <asp:Panel ID="pnl_grid" runat="server">
        <asp:GridView ID="grid_items" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-CssClass="grid-header"
            CssClass="grid" AllowPaging="true" PageSize="20" AllowSorting="false" GridLines="Horizontal" PagerSettings-Mode="NumericFirstLast"
            OnRowCreated="grid_items_RowCreated" OnPageIndexChanging="grid_items_PageIndexChanging" OnRowCommand="grid_items_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="نام معبر" DataField="Name" ItemStyle-CssClass="grid-item" />
                <asp:BoundField HeaderText="نوع معبر" DataField="TypeText" ItemStyle-CssClass="grid-item" />
                <asp:BoundField HeaderText="نام معبر ماقبل آخر" DataField="PrecedingName" ItemStyle-CssClass="grid-item" />
                <asp:BoundField HeaderText="منطقه شهرداری" DataField="RegionText" ItemStyle-CssClass="grid-item" />
                <asp:TemplateField ItemStyle-Width="90px">
                    <ItemTemplate>

                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="grid-button grid-button-details" ToolTip="مشاهده جزئیات" Visible='<%# Access.Details %>'
                            NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "PasswayDetails.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>&nbsp;

                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="grid-button grid-button-edit" ToolTip="ویرایش اطلاعات" Visible='<%# Access.Edit %>'
                            NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "EditPassway.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>&nbsp;

                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="grid-button grid-button-photos" ToolTip="تصاویر معبر" Visible='<%# Access.Photos %>'
                            NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "PasswayPhotos.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>&nbsp;

                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="grid-button grid-button-delete" Visible='<%# Access.Delete %>'
                            OnClientClick="return confirm('آیا اطمینان دارید؟');" CommandName="DeletePass" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف"></asp:LinkButton>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div style="padding-top: 10px;">
            <asp:Label ID="lblCount" runat="server" Text="" Font-Bold="true"></asp:Label>
        </div>

    </asp:Panel>

    <asp:Panel ID="pnl_noItem" runat="server" CssClass="no-items" Visible="false">
        <table border="0" cellpadding="2" cellspacing="0">
            <tr>
                <td>
                    <div class="error-icon"></div>
                </td>
                <td class="td_pad1">موردی جهت نمایش وجود ندارد.
                </td>
            </tr>
        </table>
    </asp:Panel>

</div>

<!-- ********************** hidden fields ********************** -->
<asp:HiddenField ID="hid_Access" runat="server" Value="11111111" />
