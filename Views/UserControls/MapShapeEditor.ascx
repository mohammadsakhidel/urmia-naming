<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MapShapeEditor.ascx.cs" Inherits="Views_UserControls_MapShapeEditor" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">

    <ContentTemplate>

        <asp:Panel ID="pnl_Map" runat="server" CssClass="map-border center" style="width: 95%;">

            <div style="position: relative;">
                <div class="map-center"></div>
                <cc1:GMap ID="GMap1" runat="server" Height="400px" Width="100%" Language="fa" enableServerEvents="true"
                    Key="AIzaSyBmSs4NcvJldLInWx7C21gMK0EBIKk1q8Q" style="position: absolute; bottom: 0px;" />
            </div>
            <div class="map-tools">
                <asp:LinkButton ID="btn_DrawLine" runat="server" CssClass="map-tool map-tool-line" OnClick="btn_DrawLine_Click"></asp:LinkButton>
                <asp:LinkButton ID="btn_DrawPolygon" runat="server" CssClass="map-tool map-tool-polygon-selected" OnClick="btn_DrawPolygon_Click" style="margin-right: 5px;"></asp:LinkButton>
                <asp:LinkButton ID="btn_Mark" runat="server" CssClass="map-tool map-tool-mark" style="margin-right: 5px;" OnClick="btn_Mark_Click"></asp:LinkButton>
                <asp:LinkButton ID="btn_Clear" runat="server" CssClass="map-tool map-tool-clear" style="margin-right: 5px;" OnClick="btn_Clear_Click"></asp:LinkButton>
                <asp:Label ID="lbl_Distance" runat="server" Text="" style="float: left; margin: 5px 10px 0 0; color: #f58220; font-size: 9pt;"></asp:Label>
                <asp:HiddenField ID="hid_Distance" runat="server" />
            </div>

            <asp:HiddenField ID="hid_Shape" runat="server" Value="polygon:" />
            <asp:HiddenField ID="hid_Type" runat="server" Value="passway" />
            <asp:HiddenField ID="hid_LastPoint" runat="server" Value="" ClientIDMode="Static" />

        </asp:Panel>

    </ContentTemplate>

</asp:UpdatePanel>


<div class="table center" style="padding-top: 10px;">
    <% if (Request.QueryString["type"] != "passway") { %>

        <a class="btn-submit" onclick="<%="SaveShapeInfo();" %>">ذخیره</a>

    <% } else if (Request.QueryString["point"] == "begin") {  %>

    <a class="btn-submit" onclick="<%="SavePasswayBegin();" %>">ذخیره</a>

    <% } else if (Request.QueryString["point"] == "end") {  %>

    <a class="btn-submit" onclick="<%="SavePasswayEnd();" %>">ذخیره</a>

    <% } %>
</div>