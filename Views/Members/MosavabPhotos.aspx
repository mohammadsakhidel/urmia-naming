<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="MosavabPhotos.aspx.cs" Inherits="Views_Members_MosavabPhotos" %>
<%@ Register Src="~/Views/UserControls/MosavabPhotos.ascx" TagPrefix="uc" TagName="MosavabPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    تصاویر مصوبه
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">

    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-mosavabat');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:MosavabPhotos runat="server" ID="uc_MosavabPhotos" />
</asp:Content>