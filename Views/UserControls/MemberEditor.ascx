<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberEditor.ascx.cs" Inherits="Views_UserControls_MemberEditor" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td class="form-label-conteiner">
            نام کامل :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_FullName" runat="server" CssClass="textbox2" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" CssClass="validator" 
                ControlToValidate="tb_FullName" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            سازمان مربوطه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Organization" runat="server" CssClass="textbox2" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            سمت در سازمان :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Position" runat="server" CssClass="textbox2" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            نام کاربری :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_UserName" runat="server" CssClass="textbox2" Width="110px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" CssClass="validator" 
                ControlToValidate="tb_UserName" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            رمز عبور :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Password" runat="server" CssClass="textbox2" Width="110px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" CssClass="validator" 
                ControlToValidate="tb_Password" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>

<div class="form-submit">
    <table border="0" cellpadding="0" cellspacing="0" class="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="btn_Save" runat="server" CssClass="btn-submit" 
                            ValidationGroup="SaveFormData" OnClick="btn_Save_Click">ذخیره اطلاعات</asp:LinkButton>
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

<!-- ***************** hidden fields: *************** -->
<asp:HiddenField ID="hid_MemberID" runat="server" Value="0"/>
<asp:HiddenField ID="hid_FormAction" runat="server" Value="1"/>