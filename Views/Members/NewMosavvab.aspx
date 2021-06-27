<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="NewMosavvab.aspx.cs" Inherits="Views_Members_NewMosavvab" %>
<%@ Register Src="~/Views/UserControls/MosavabEditor.ascx" TagPrefix="uc" TagName="MosavabEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    ثبت مصوبه جدید
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-mosavabat');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:MosavabEditor runat="server" ID="uc_MosavabEditor" />

</asp:Content>

