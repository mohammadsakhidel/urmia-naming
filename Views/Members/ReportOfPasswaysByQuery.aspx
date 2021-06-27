<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="ReportOfPasswaysByQuery.aspx.cs" Inherits="Views_Admins_ReportOfPasswaysByQuery" %>

<%@ Register Src="~/Views/UserControls/ReportOfPasswaysQuery.ascx" TagPrefix="uc1" TagName="ReportOfPasswaysQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    گزارش معابر با پرس و جو
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-reports');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc1:ReportOfPasswaysQuery runat="server" ID="ReportOfPasswaysQuery" />

</asp:Content>
