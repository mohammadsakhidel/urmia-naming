<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/ToolWindow.master" AutoEventWireup="true" CodeFile="SelectPassName.aspx.cs" Inherits="Views_Admins_ToolWindows_SelectPassName" %>
<%@ Register Src="~/Views/UserControls/SelectPassName.ascx" TagPrefix="uc" TagName="SelectPassName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../../Scripts/selectPassName.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WindowTitle" Runat="Server">
    جستجو در اسامی پیشنهادی
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WindowContent" Runat="Server">

    <uc:SelectPassName runat="server" ID="uc_SelectPassName" />

</asp:Content>

