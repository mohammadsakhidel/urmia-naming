<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="ReportOfPassNameTypes.aspx.cs" Inherits="Views_Admins_ReportOfPassNameTypes" %>
<%@ Register Src="~/Views/UserControls/ReportOfPassNameTypes.ascx" TagPrefix="uc" TagName="ReportOfPassNameTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    آمار انواع اسامی استفاده شده
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-reports');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:ReportOfPassNameTypes runat="server" ID="uc_ReportOfPassNameTypes"/>

</asp:Content>