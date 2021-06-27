<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="Passways.aspx.cs" Inherits="Views_Members_Passways" %>
<%@ Register Src="~/Views/UserControls/Passways.ascx" TagPrefix="uc" TagName="Passways" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    جستجو در معابر
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-maaber');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:Passways runat="server" ID="uc_Passways"/>

</asp:Content>

