<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="EditMosavvab.aspx.cs" Inherits="Views_Admins_EditMosavvab" %>
<%@ Register Src="~/Views/UserControls/MosavabEditor.ascx" TagPrefix="uc" TagName="MosavabEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
    ویرایش مشخصات مصوبه
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <!-- ========================= SCRIPTS ======================= -->
    <script type="text/javascript">
        showSubmenu('mi-mosavabat');
    </script>
    <!-- ========================= SCRIPTS ======================= -->

    <uc:MosavabEditor runat="server" ID="uc_MosavabEditor" FormAction="Edit"/>

</asp:Content>

