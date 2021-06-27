<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/ToolWindow.master" AutoEventWireup="true" CodeFile="SelectMosavab.aspx.cs" Inherits="Views_Admins_ToolWindows_SelectMosavab" %>
<%@ Register Src="~/Views/UserControls/SelectMosavab.ascx" TagPrefix="uc" TagName="SelectMosavab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../../Scripts/selectMosavab.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WindowTitle" Runat="Server">
    جستجوی مصوبه
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WindowContent" Runat="Server">

    <uc:SelectMosavab runat="server" ID="uc_SelectMosavab" />

</asp:Content>

