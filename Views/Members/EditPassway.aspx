<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="EditPassway.aspx.cs" Inherits="Views_Members_EditPassway" %>
<%@ Register Src="~/Views/UserControls/PasswayEditor.ascx" TagPrefix="uc" TagName="PasswayEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../Scripts/passwayEditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    ویرایش مشخصات معبر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-maaber');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PasswayEditor runat="server" ID="uc_PasswayEditor" FormAction="Edit"/>
</asp:Content>

