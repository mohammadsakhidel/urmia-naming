<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="PasswayDetails.aspx.cs" Inherits="Views_Admins_PasswayDetails" %>
<%@ Register Src="~/Views/UserControls/PasswayDetails.ascx" TagPrefix="uc" TagName="PasswayDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    جزئیات مشخصات معبر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-maaber');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PasswayDetails runat="server" ID="uc_PasswayDetails"/>

</asp:Content>

