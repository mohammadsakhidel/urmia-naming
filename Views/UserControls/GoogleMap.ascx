<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GoogleMap.ascx.cs" Inherits="Views_UserControls_GoogleMap" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<style type="text/css">
    .RadMap .k-marker.k-i-marker-my-marker:before {
        color: deepskyblue;
        font-size: 2.2rem;
        text-shadow: none;
        border: solid 1px white;
        stroke: white;
    }
</style>

<asp:Panel ID="pnl_Map" runat="server" CssClass="map-border center">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadMap ID="radMap" runat="server">
        <LayersCollection>
            <telerik:MapLayer
                Subdomains="a,b,c"
                UrlTemplate="https://#=subdomain#.tile.openstreetmap.org/#=zoom#/#=x#/#=y#.png"></telerik:MapLayer>
        </LayersCollection>
    </telerik:RadMap>

</asp:Panel>