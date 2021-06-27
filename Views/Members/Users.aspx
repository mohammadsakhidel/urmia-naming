<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Views_Members_Users" %>
<%@ Register Src="~/Views/UserControls/Members.ascx" TagPrefix="uc" TagName="Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    لیست کاربران و سطوح دسترسی
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-users');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:Members runat="server" ID="uc_Members" />

</asp:Content>

