<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswaysTableReport.aspx.cs" Inherits="Views_Reports_PasswaysTableReport" %>
<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش جامع معابر</title>
</head>
<body>
    <form runat="server">
        <cc1:StiWebViewer ID="rep_viewer" runat="server" />
    </form>
</body>
</html>
