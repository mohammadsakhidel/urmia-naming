<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="ReportOfPasswaysTable.aspx.cs" Inherits="Views_Admins_ReportOfPasswaysTable" %>

<%@ Register Src="~/Views/UserControls/ReportPasswaysTable.ascx" TagPrefix="uc1" TagName="ReportPasswaysTable" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    گزارش جامع معابر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-reports');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc1:ReportPasswaysTable runat="server" ID="ReportPasswaysTable" />

</asp:Content>
