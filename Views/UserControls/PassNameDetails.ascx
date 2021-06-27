<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PassNameDetails.ascx.cs" Inherits="Views_UserControls_PassNameDetails" %>
<%@ Register Src="~/Views/UserControls/GoogleMap.ascx" TagPrefix="uc" TagName="GoogleMap" %>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td class="form-label-conteiner">
            نام :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Name" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            نوع:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Type" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شرح:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Description" runat="server" CssClass="textbox-readonly" Width="350px" Height="70px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="form-input-conteiner" style="padding-bottom: 10px;">
            <asp:CheckBox ID="ch_IsSuggestion" runat="server" Text="پیشنهاد شده بصورت رسمی" Checked="false" Enabled="false"/>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            پیشنهاد دهنده:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_SuggestedBy" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            تاریخ پیشنهاد:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_DateOfSuggest" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شماره نامه پیشنهاد:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_LetterNo" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
</table>

<div style="margin-top: 15px;">
    <uc:GoogleMap ID="uc_GoogleMap" runat="server" Width="700px" Height="500px"/>
</div>

<asp:HiddenField ID="hid_PassNameID" runat="server" Value="0" />