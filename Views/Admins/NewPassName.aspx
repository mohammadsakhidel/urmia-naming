<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="NewPassName.aspx.cs" Inherits="Views_Admins_NewPassName" %>
<%@ Register Src="~/Views/UserControls/PassNameEditor.ascx" TagPrefix="uc" TagName="PassNameEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../Scripts/passNameEditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    افزودن به بانک اسامی
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-basicInfo');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PassNameEditor runat="server" ID="uc_PassNameEditor" />

</asp:Content>

