<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/MemberPanel.master" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="Views_Members_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
     پانل کاربری
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    
    <div class="panel-row">
        <div id="pi_PassNames" runat="server" class="panel-item">
            <div class="panel-icon panel-icon-basicInfo" title="اطلاعات پایه"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="smi_CreatePassName" runat="server" NavigateUrl="~/Views/Members/NewPassName.aspx" 
                    CssClass="panel-link">افزودن به بانک اسامی</asp:HyperLink>
                <asp:HyperLink ID="smi_SearchPassName" runat="server" NavigateUrl="~/Views/Members/PassNames.aspx" 
                    CssClass="panel-link">جستجو در بانک اسامی</asp:HyperLink>
            </div>
        </div>

        <div id="pi_Mosavabs" runat="server" class="panel-item">
            <div class="panel-icon panel-icon-mosavabat" title="مصوبات"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="smi_CreateMosavab" runat="server" NavigateUrl="~/Views/Members/NewMosavvab.aspx" 
                    CssClass="panel-link">ثبت مصوبه جدید</asp:HyperLink>
                <asp:HyperLink ID="smi_SearchMosavab" runat="server" NavigateUrl="~/Views/Members/Mosavvabs.aspx" 
                    CssClass="panel-link">جستجو در مصوبات</asp:HyperLink>
            </div>
        </div>
    </div>

    <div class="panel-row">
        <div class="panel-item">
            <div class="panel-icon panel-icon-maaber" title="معابر شهر"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="smi_CreatePassway" runat="server" NavigateUrl="~/Views/Members/NewPassway.aspx" 
                    CssClass="panel-link">تعریف معبر جدید</asp:HyperLink>
                <asp:HyperLink ID="smi_SearchPassway" runat="server" NavigateUrl="~/Views/Members/Passways.aspx" 
                    CssClass="panel-link">جستجو در معابر</asp:HyperLink>
                <asp:HyperLink ID="smi_SearchArea" runat="server" NavigateUrl="~/Views/Members/SearchArea.aspx" 
                    CssClass="panel-link">جستجو در محدوده</asp:HyperLink>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Views/Members/UrmiaMap.aspx" 
                    CssClass="panel-link">نقشه شهر</asp:HyperLink>
            </div>
        </div>

        <div id="pi_Members" runat="server" class="panel-item">
            <div class="panel-icon panel-icon-users" title="کاربران سامانه"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="smi_CreateMember" runat="server" NavigateUrl="~/Views/Members/NewUser.aspx" 
                    CssClass="panel-link">تعریف کاربر جدید</asp:HyperLink>
                <asp:HyperLink ID="smi_ListMember" runat="server" NavigateUrl="~/Views/Members/Users.aspx" 
                    CssClass="panel-link">لیست کاربران و سطوح دسترسی</asp:HyperLink>
            </div>
        </div>
    </div>

    <div class="panel-row">
        <div class="panel-item">
            <div class="panel-icon panel-icon-settings" title="تنظیمات"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Members/ChangePassword.aspx" 
                    CssClass="panel-link">تغییر رمز حساب کاربری</asp:HyperLink>
            </div>
        </div>
    </div>

</asp:Content>

