<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="PassNames.aspx.cs" Inherits="Views_Members_PassNames" %>
<%@ Register Src="~/Views/UserControls/PassNames.ascx" TagPrefix="uc" TagName="PassNames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    جستجو در بانک اسامی
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-basicInfo');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PassNames runat="server" ID="uc_PassNames"/>

</asp:Content>

