<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="Views_Admins_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
     پانل کاربری
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlace" Runat="Server">
    
    <div class="panel-row">
        <div class="panel-item">
            <div class="panel-icon panel-icon-basicInfo" title="اطلاعات پایه"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Admins/NewPassName.aspx" 
                    CssClass="panel-link">افزودن به بانک اسامی</asp:HyperLink>
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Views/Admins/PassNames.aspx" 
                    CssClass="panel-link">جستجو در بانک اسامی</asp:HyperLink>
            </div>
        </div>

        <div class="panel-item">
            <div class="panel-icon panel-icon-mosavabat" title="مصوبات"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Views/Admins/NewMosavvab.aspx" 
                    CssClass="panel-link">ثبت مصوبه جدید</asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Views/Admins/Mosavvabs.aspx" 
                    CssClass="panel-link">جستجو در مصوبات</asp:HyperLink>
            </div>
        </div>
    </div>

    <div class="panel-row">
        <div class="panel-item">
            <div class="panel-icon panel-icon-maaber" title="معابر شهر"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Views/Admins/NewPassway.aspx" 
                    CssClass="panel-link">تعریف معبر جدید</asp:HyperLink>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Views/Admins/Passways.aspx" 
                    CssClass="panel-link">جستجو در معابر</asp:HyperLink>
                <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Views/Admins/SearchArea.aspx" 
                    CssClass="panel-link">جستجو در محدوده</asp:HyperLink>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Views/Admins/UrmiaMap.aspx" 
                    CssClass="panel-link">نقشه شهر</asp:HyperLink>
            </div>
        </div>

        <div class="panel-item">
            <div class="panel-icon panel-icon-reports" title="گزارشات و آمارها"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Views/Admins/ReportOfPassNameTypes.aspx" 
                    CssClass="panel-link">آمار انواع اسامی استفاده شده</asp:HyperLink>
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Views/Admins/ReportOfPassways.aspx" 
                    CssClass="panel-link">آمار معابر ثبت شده به تفکیک نوع</asp:HyperLink>
            </div>
        </div>
    </div>

    <div class="panel-row">
        <div class="panel-item">
            <div class="panel-icon panel-icon-users" title="کاربران سامانه"></div>
            <div class="panel-links-container">
                <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Views/Admins/NewUser.aspx" 
                    CssClass="panel-link">تعریف کاربر جدید</asp:HyperLink>
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Views/Admins/Users.aspx" 
                    CssClass="panel-link">لیست کاربران و سطوح دسترسی</asp:HyperLink>
            </div>
        </div>

        <div class="panel-item">
            
        </div>
    </div>

</asp:Content>

