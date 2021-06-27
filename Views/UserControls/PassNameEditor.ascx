<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PassNameEditor.ascx.cs" Inherits="Views_UserControls_PassNameEditor" %>
<%@ Register Src="~/Views/UserControls/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td class="form-label-conteiner">
            نام :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Name" runat="server" CssClass="textbox2" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" CssClass="validator" 
                ControlToValidate="tb_Name" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            نوع:
        </td>
        <td class="form-input-conteiner">
            <asp:DropDownList ID="cmb_Type" runat="server" CssClass="combobox2" Width="150px"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" CssClass="validator" 
                ControlToValidate="cmb_Type" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شرح:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Description" runat="server" CssClass="textbox2" Width="400px" Height="60px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class="form-input-conteiner" style="padding-bottom: 10px;">
            <asp:CheckBox ID="ch_IsSuggestion" runat="server" Text="پیشنهاد شده بصورت رسمی" Checked="false"/>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            پیشنهاد دهنده:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_SuggestedBy" runat="server" CssClass="textbox2" Width="180px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            تاریخ پیشنهاد:
        </td>
        <td class="form-input-conteiner">
            <uc:DateSelector runat="server" ID="uc_DateOfSuggest" YearMinMax="1370;1410" Enabled="false"/>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شماره نامه پیشنهاد:
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_LetterNo" runat="server" CssClass="textbox2" Width="100px" Enabled="false"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            
        </td>
        <td class="form-input-conteiner" style="padding-top: 10px;">
            <asp:HiddenField ID="hid_ShapeInfo" runat="server" />
            <a class="link" onclick="<%= "return openMap('" + MyHelper.Url(MyHelper.GetFolderUrl()) + "');" %>">موقعیت معبر مورد درخواست روی نقشه</a>
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
<asp:HiddenField ID="hid_PassNameID" runat="server" Value="0"/>
<asp:HiddenField ID="hid_FormAction" runat="server" Value="1"/>