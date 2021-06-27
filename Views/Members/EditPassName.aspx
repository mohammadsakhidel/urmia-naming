<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="EditPassName.aspx.cs" Inherits="Views_Members_EditPassName" %>
<%@ Register Src="~/Views/UserControls/PassNameEditor.ascx" TagPrefix="uc" TagName="PassNameEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../Scripts/passNameEditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    ویرایش نام
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-basicInfo');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:PassNameEditor runat="server" ID="uc_PassNameEditor" FormAction="Edit"/>

</asp:Content>

