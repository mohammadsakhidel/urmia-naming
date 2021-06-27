<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectMosavab.ascx.cs" Inherits="Views_UserControls_SelectMosavab" %>
<%@ Register Src="~/Views/UserControls/SearchMosavab.ascx" TagPrefix="uc" TagName="SearchMosavab" %>

<uc:SearchMosavab runat="server" ID="uc_SearchMosavab"/>

<div style="padding-top: 10px;">

    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-submit" OnClick="LinkButton1_Click">جستجو</asp:LinkButton>

</div>

<div style="padding-top: 10px;">
    
    <asp:GridView ID="grid_items" runat="server" AutoGenerateColumns="false" Width="100%" HeaderStyle-CssClass="grid-header"
        CssClass="grid" AllowPaging="true" PageSize="15" AllowSorting="false" GridLines="Horizontal" 
        OnRowCreated="grid_items_RowCreated" OnPageIndexChanging="grid_items_PageIndexChanging">
        <Columns>

            <asp:TemplateField HeaderText="عنوان مصوبه" ItemStyle-CssClass="grid-item">
                <ItemTemplate>
                    <span title="<%# Eval("Explanation") %>"><%# Eval("Subject") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="شماره مصوبه" DataField="Shomare" ItemStyle-CssClass="grid-item" />
            <asp:BoundField HeaderText="شماره جلسه" DataField="MeetingNo" ItemStyle-CssClass="grid-item" />
            <asp:TemplateField ItemStyle-Width="90px">
                <ItemTemplate>

                    <a onclick="<%# "ReturnShomare('" + Eval("Shomare") + "');" %>" class="grid-button grid-button-select"></a>

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