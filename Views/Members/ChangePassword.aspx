<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Views_Members_ChangePassword" %>
<%@ Register Src="~/Views/UserControls/ChangePassword.ascx" TagPrefix="uc" TagName="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    تغییر رمز حساب کاربری
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-settings');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:ChangePassword runat="server" ID="uc_ChangePassword"/>

</asp:Content>

