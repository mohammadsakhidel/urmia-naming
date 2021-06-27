<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AccessRulesEditor.ascx.cs" Inherits="Views_UserControls_AccessRulesEditor" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<fieldset class="group">

    <legend class="group-header">
        نحوه دسترسی به معابر
    </legend>

    <asp:CheckBoxList ID="chl_AccessToPassways" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="70%">
        <asp:ListItem Text="ایجاد" Value="1"></asp:ListItem>
        <asp:ListItem Text="ویرایش" Value="2"></asp:ListItem>
        <asp:ListItem Text="حذف" Value="3"></asp:ListItem>
        <asp:ListItem Text="جستجو" Value="4"></asp:ListItem>
        <asp:ListItem Text="مشاهده جزئیات" Value="5"></asp:ListItem>
        <asp:ListItem Text="مشاهده تصاویر" Value="6"></asp:ListItem>
        <asp:ListItem Text="افزودن تصاویر" Value="7"></asp:ListItem>
        <asp:ListItem Text="حذف تصاویر" Value="8"></asp:ListItem>
    </asp:CheckBoxList>

</fieldset>

<fieldset class="group" style="margin-top: 10px;">

    <legend class="group-header">
        نحوه دسترسی به مصوبات
    </legend>

    <asp:CheckBoxList ID="chl_AccessToMosavabs" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="70%">
        <asp:ListItem Text="ایجاد" Value="1"></asp:ListItem>
        <asp:ListItem Text="ویرایش" Value="2"></asp:ListItem>
        <asp:ListItem Text="حذف" Value="3"></asp:ListItem>
        <asp:ListItem Text="جستجو" Value="4"></asp:ListItem>
        <asp:ListItem Text="مشاهده جزئیات" Value="5"></asp:ListItem>
        <asp:ListItem Text="مشاهده تصاویر" Value="6"></asp:ListItem>
        <asp:ListItem Text="افزودن تصاویر" Value="7"></asp:ListItem>
        <asp:ListItem Text="حذف تصاویر" Value="8"></asp:ListItem>
    </asp:CheckBoxList>

</fieldset>

<fieldset class="group" style="margin-top: 10px;">

    <legend class="group-header">
        نحوه دسترسی به بانک اسامی
    </legend>

    <asp:CheckBoxList ID="chl_AccessToPassNames" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" Width="80%">
        <asp:ListItem Text="ایجاد" Value="1"></asp:ListItem>
        <asp:ListItem Text="ویرایش" Value="2"></asp:ListItem>
        <asp:ListItem Text="حذف" Value="3"></asp:ListItem>
        <asp:ListItem Text="جستجو" Value="4"></asp:ListItem>
        <asp:ListItem Text="مشاهده جزئیات" Value="5"></asp:ListItem>
    </asp:CheckBoxList>

</fieldset>

<fieldset class="group" style="margin-top: 10px;">

    <legend class="group-header">
        نحوه دسترسی به بخش مدیریت کاربران
    </legend>

    <asp:CheckBoxList ID="chl_AccessToMembers" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" Width="80%">
        <asp:ListItem Text="ایجاد" Value="1"></asp:ListItem>
        <asp:ListItem Text="ویرایش" Value="2"></asp:ListItem>
        <asp:ListItem Text="حذف" Value="3"></asp:ListItem>
        <asp:ListItem Text="مشاهده لیست" Value="4"></asp:ListItem>
        <asp:ListItem Text="تعیین سطح دسترسی" Value="5"></asp:ListItem>
    </asp:CheckBoxList>

</fieldset>

<fieldset class="group" style="margin-top: 10px;">

    <legend class="group-header">
        نحوه دسترسی به بخش گزارشات
    </legend>

    <asp:CheckBoxList ID="chl_AccessToReports" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" Width="80%">
        <asp:ListItem Text="مشاهده گزارشات" Value="4"></asp:ListItem>
    </asp:CheckBoxList>

</fieldset>

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