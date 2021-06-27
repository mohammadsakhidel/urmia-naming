<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswaysQueryReport.aspx.cs" Inherits="Views_Reports_PasswaysQueryReport" %>
<%@ Register Assembly="Stimulsoft.Report.Web" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش معابر با پرس و جو</title>
</head>
<body>
    <form runat="server">
        <cc1:StiWebViewer ID="rep_viewer" runat="server" />
    </form>
</body>
</html>
