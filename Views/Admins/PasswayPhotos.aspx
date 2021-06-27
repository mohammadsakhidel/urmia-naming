<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="PasswayPhotos.aspx.cs" Inherits="Views_Admins_PasswayPhotos" %>
<%@ Register Src="~/Views/UserControls/PasswayPhotos.ascx" TagPrefix="uc" TagName="PasswayPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    تصاویر معبر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-maaber');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PasswayPhotos runat="server" ID="uc_PasswayPhotos" />
</asp:Content>

