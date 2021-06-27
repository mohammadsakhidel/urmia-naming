﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportOfPasswaysQuery.ascx.cs" Inherits="Views_UserControls_ReportOfPasswaysQuery" %>

<div class="advance-search">
    <table>
        <tr>
            <td class="form-label-conteiner">
                <label>شرط پرس و جو:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tbQuery" runat="server" CssClass="textbox2" Width="385px" TextMode="MultiLine" style="direction: ltr;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" CssClass="validator"
                    ControlToValidate="tbQuery" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <label>Example: WHERE [Name] LIKE N'%name%' ORDER BY [Name]</label>
            </td>
        </tr>
    </table>
</div>

<div class="advance-search">
    <table>
        <tr>
            <td class="form-label-conteiner">
                <label>عنوان گزارش:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tbReportTitle" runat="server" CssClass="textbox2" Width="385px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" CssClass="validator"
                    ControlToValidate="tbReportTitle" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>

<div style="padding-top: 10px;">

    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn-submit" ValidationGroup="SaveFormData" OnClick="btnSubmit_Click">گزارش گیری</asp:LinkButton>

</div>