<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs" Inherits="Views_UserControls_ChangePassword" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table border="0" cellpadding="2" cellspacing="0">
    <tr>
        <td class="form-label-conteiner">
            نام کاربری:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_UserName" runat="server" CssClass="textbox2" Width="130px" MaxLength="50" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" 
                CssClass="validator" ControlToValidate="tb_UserName" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
            <span class="form-tip">
                فقط کاراکترهای a-A تا z-Z و اعداد
            </span>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            رمز عبور قبلی:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_OldPassword" runat="server" CssClass="textbox2" Width="130px" MaxLength="50" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" 
                CssClass="validator" ControlToValidate="tb_OldPassword" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            رمز عبور جدید:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_NewPassword" runat="server" CssClass="textbox2" Width="130px" MaxLength="50" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" 
                CssClass="validator" ControlToValidate="tb_NewPassword" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
            <span class="form-tip">
                فقط کاراکترهای a-A تا z-Z و اعداد
            </span>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            تکرار رمز عبور جدید:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_NewPasswordConfirm" runat="server" CssClass="textbox2" Width="130px" MaxLength="50" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" 
                CssClass="validator" ControlToValidate="tb_NewPasswordConfirm" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="تکرار اشتباه" CssClass="validator-text" ControlToCompare="tb_NewPassword"
                ControlToValidate="tb_NewPasswordConfirm" ValidationGroup="SaveFormData"></asp:CompareValidator>
        </td>
    </tr>
</table>

<div class="form-submit">
    <table border="0" cellpadding="0" cellspacing="0" class="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-submit" 
                            ValidationGroup="SaveFormData" OnClick="LinkButton1_Click">ذخیره اطلاعات</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="loading-container">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_save">
                    <ProgressTemplate>
                        <div class="loading"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <div class="form-message">
        <asp:UpdatePanel ID="up_message" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lbl_Message" runat="server" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

