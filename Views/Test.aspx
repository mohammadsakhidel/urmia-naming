<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Views_Test" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadMap ID="RadMap1" runat="server">
        <LayersCollection>
            <telerik:MapLayer UrlTemplate="https://a.tile.openstreetmap.org/#=zoom#/#=x#/#=y#.png"></telerik:MapLayer>
        </LayersCollection>
    </telerik:RadMap>
    
</body>
</html>
