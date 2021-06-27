<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="UrmiaMap.aspx.cs" Inherits="Views_Admins_UrmiaMap" %>
<%@ Register Src="~/Views/UserControls/GoogleMap.ascx" TagPrefix="uc" TagName="GoogleMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    نقشه شهر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-maaber');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:GoogleMap ID="uc_GoogleMap" runat="server" Width="700px" Height="550px"/>

</asp:Content>

