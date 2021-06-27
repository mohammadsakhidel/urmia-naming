<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="UserAccessRules.aspx.cs" Inherits="Views_Admins_UserAccessRules" %>
<%@ Register Src="~/Views/UserControls/AccessRulesEditor.ascx" TagPrefix="uc" TagName="AccessRulesEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    تعیین میزان سطح دسترسی کاربر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-users');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:AccessRulesEditor runat="server" ID="uc_AccessRulesEditor" />

</asp:Content>

