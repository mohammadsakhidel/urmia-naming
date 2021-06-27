<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="MosavabDetails.aspx.cs" Inherits="Views_Members_MosavabDetails" %>
<%@ Register Src="~/Views/UserControls/MosavabDetails.ascx" TagPrefix="uc" TagName="MosavabDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    جزئیات مشخصات مصوبه
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-mosavabat');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:MosavabDetails runat="server" ID="uc_MosavabDetails"/>

</asp:Content>

