<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Views_Admins_EditUser" %>
<%@ Register Src="~/Views/UserControls/MemberEditor.ascx" TagName="MemberEditor" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
     ویرایش مشخصات کاربر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-users');
    </script>
    <!-- ========================= SCRIPTS ======================= -->
    <uc:MemberEditor runat="server" ID="uc_MemberEditor" FormAction="Edit"/>
</asp:Content>
