<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="ReportOfPasswaysDynamic.aspx.cs" Inherits="Views_Admins_ReportOfPasswaysDynamic" %>

<%@ Register Src="~/Views/UserControls/ReportOfPasswaysDynamic.ascx" TagPrefix="uc1" TagName="ReportOfPasswaysDynamic" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    گزارش ساز پویا
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-reports');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc1:ReportOfPasswaysDynamic runat="server" ID="ReportOfPasswaysDynamic" />

</asp:Content>