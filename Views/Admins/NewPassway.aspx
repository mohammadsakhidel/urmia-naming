<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="NewPassway.aspx.cs" Inherits="Views_Admins_NewPassway" %>
<%@ Register Src="~/Views/UserControls/PasswayEditor.ascx" TagPrefix="uc" TagName="PasswayEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../Scripts/passwayEditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    تعریف معبر جدید
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-maaber');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PasswayEditor runat="server" ID="uc_PasswayEditor"/>

</asp:Content>

