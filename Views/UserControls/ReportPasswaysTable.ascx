<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportPasswaysTable.ascx.cs" Inherits="Views_UserControls_ReportPasswaysTable" %>
<%@ Register Src="~/Views/UserControls/SearchPassway.ascx" TagPrefix="uc1" TagName="SearchPassway" %>

<uc1:SearchPassway runat="server" ID="ucSearchPassway" />

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