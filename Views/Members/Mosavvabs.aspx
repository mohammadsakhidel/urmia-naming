<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="Mosavvabs.aspx.cs" Inherits="Views_Members_Mosavvabs" %>
<%@ Register Src="~/Views/UserControls/Mosavabs.ascx" TagPrefix="uc" TagName="Mosavabs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    جستجو در مصوبات
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-mosavabat');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:Mosavabs runat="server" ID="uc_Mosavabs" />

</asp:Content>

