<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchArea.ascx.cs" Inherits="Views_UserControls_SearchArea" %>
<%@ Register Src="~/Views/UserControls/GoogleMap.ascx" TagPrefix="uc" TagName="GoogleMap" %>

<script>
    $(function () {
        var map_center = $('.map-center');
        var wc = ($('#map').width() / 2) - 10;
        var hc = ($('#map').height() / 2) - 20;
        map_center.css('position', 'absolute').css('top', hc + 'px').css('left', wc + 'px');
    });
</script>

<div class="advance-search">
    <label>
        فاصله از مرکز:
    </label>
    <asp:TextBox ID="tb_Radius" runat="server" CssClass="textbox" Width="60px"></asp:TextBox>
    متر

    <asp:LinkButton ID="btn_ShowArea" runat="server" OnClick="btn_ShowArea_Click" Style="margin-right: 10px;" CssClass="link">نمایش محدوده</asp:LinkButton>

    <label style="margin-right: 10px;">
        نوع معبر:
    </label>
    <asp:DropDownList ID="cmb_PasswayType" runat="server" CssClass="combobox">
        <asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="20" Value="20"></asp:ListItem>
        <asp:ListItem Text="50" Value="50"></asp:ListItem>
        <asp:ListItem Text="100" Value="100"></asp:ListItem>
        <asp:ListItem Text="200" Value="200"></asp:ListItem>
    </asp:DropDownList>

    <asp:CheckBox ID="ch_HasName" runat="server" Text="دارای نام" style="margin-right: 10px;" />

    <label style="margin-right: 10px;">
        تعداد:
    </label>
    <asp:DropDownList ID="cmb_PageSize" runat="server" CssClass="combobox">
        <asp:ListItem Text="10" Value="10"></asp:ListItem>
        <asp:ListItem Text="20" Value="20"></asp:ListItem>
        <asp:ListItem Text="50" Value="50"></asp:ListItem>
        <asp:ListItem Text="100" Value="100"></asp:ListItem>
        <asp:ListItem Text="200" Value="200"></asp:ListItem>
    </asp:DropDownList>

    <asp:HiddenField ID="hid_Center" runat="server" Value="" />

    <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn-submit" OnClick="btnSearch_Click" style="margin-right: 10px;">جستجو</asp:LinkButton>
</div>

<div id="map" style="position: relative; margin-top: 15px;">

    <div class="map-center"></div>

    <uc:GoogleMap ID="uc_GoogleMap" runat="server" Width="710" Height="600" />

</div>

<div style="margin-top: 10px;">

    <asp:GridView ID="grid_items" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-CssClass="grid-header"
        CssClass="grid" AllowPaging="false" AllowSorting="false" GridLines="Horizontal"
        OnRowCreated="grid_items_RowCreated">
        <Columns>
            <asp:BoundField HeaderText="نام معبر" DataField="Name" ItemStyle-CssClass="grid-item" />
            <asp:BoundField HeaderText="نوع معبر" DataField="TypeText" ItemStyle-CssClass="grid-item" />
            <asp:BoundField HeaderText="نام معبر ماقبل آخر" DataField="PrecedingName" ItemStyle-CssClass="grid-item" />
            <asp:BoundField HeaderText="منطقه شهرداری" DataField="RegionText" ItemStyle-CssClass="grid-item" />
            <asp:TemplateField ItemStyle-Width="90px">
                <ItemTemplate>

                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="grid-button grid-button-details" ToolTip="مشاهده جزئیات" Visible='<%# Access.Details %>'
                        NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "PasswayDetails.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>&nbsp;

                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="grid-button grid-button-photos" ToolTip="تصاویر معبر" Visible='<%# Access.Photos %>'
                        NavigateUrl='<%# MyHelper.Url(MyHelper.GetFolderUrl() + "PasswayPhotos.aspx") + "?id=" + Eval("ID") %>'></asp:HyperLink>&nbsp;

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
                <td class="td_pad1">موردی جهت نمایش وجود ندارد.
                </td>
            </tr>
        </table>
    </asp:Panel>

</div>

<!-- ********************** hidden fields ********************** -->
<asp:HiddenField ID="hid_Access" runat="server" Value="11111111" />
