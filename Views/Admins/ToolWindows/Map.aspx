<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/ToolWindow.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="Views_Admins_ToolWindows_Map" %>
<%@ Register Src="~/Views/UserControls/MapShapeEditor.ascx" TagPrefix="uc" TagName="MapShapeEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../../Scripts/map.js"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="WindowTitle" Runat="Server">
    نقشه
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="WindowContent" Runat="Server">

    <uc:MapShapeEditor runat="server" ID="uc_MapShapeEditor" Width="100%" Height="500px"/>

</asp:Content>

