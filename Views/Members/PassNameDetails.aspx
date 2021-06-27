<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="PassNameDetails.aspx.cs" Inherits="Views_Members_PassNameDetails" %>
<%@ Register Src="~/Views/UserControls/PassNameDetails.ascx" TagPrefix="uc" TagName="PassNameDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    جزئیات مشخصات نام در بانک اسامی
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-basicInfo');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PassNameDetails runat="server" ID="uc_PassNameDetails" />

</asp:Content>

