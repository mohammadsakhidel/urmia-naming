<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MosavabEditor.ascx.cs" Inherits="Views_UserControls_MosavabEditor" %>
<%@ Register Src="~/Views/UserControls/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td class="form-label-conteiner">
            عنوان مصوبه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Subject" runat="server" CssClass="textbox2" Width="220px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" CssClass="validator" 
                ControlToValidate="tb_Subject" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شماره مصوبه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Shomare" runat="server" CssClass="textbox2" Width="120px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" CssClass="validator" 
                ControlToValidate="tb_Shomare" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شرح مصوبات :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Explanation" runat="server" CssClass="textbox2" Width="400px" TextMode="MultiLine" Height="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شماره جلسه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_MeetingNo" runat="server" CssClass="textbox2" Width="120px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            تاریخ جلسه :
        </td>
        <td class="form-input-conteiner">
            <uc:DateSelector runat="server" ID="uc_DateOfMeeting" YearMinMax="1370;1410"/>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شرکت کنندگان در جلسه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Participants" runat="server" CssClass="textbox2" Width="400px" TextMode="MultiLine" Height="80px"></asp:TextBox>
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
<asp:HiddenField ID="hid_MosavabID" runat="server" Value="0"/>
<asp:HiddenField ID="hid_FormAction" runat="server" Value="1"/>