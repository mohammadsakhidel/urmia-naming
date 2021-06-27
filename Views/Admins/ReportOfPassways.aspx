<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="ReportOfPassways.aspx.cs" Inherits="Views_Admins_ReportOfRepeats" %>
<%@ Register Src="~/Views/UserControls/ReportOfPassways.ascx" TagPrefix="uc" TagName="ReportOfPassways" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    آمار معابر ثبت شده به تفکیک نوع
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-reports');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:ReportOfPassways runat="server" ID="uc_ReportOfPassways"/>

</asp:Content>

