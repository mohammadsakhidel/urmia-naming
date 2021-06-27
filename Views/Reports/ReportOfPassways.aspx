<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Report.master" AutoEventWireup="true" CodeFile="ReportOfPassways.aspx.cs" Inherits="Views_Reports_ReportOfPassways" %>
<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <cc1:StiWebViewer ID="rep_viewer" runat="server" />

</asp:Content>

