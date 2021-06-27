<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlace" Runat="Server">
    <div class="mipt mipt-login"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageTitlePlace" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <div class="table center" style="padding-top: 80px;">

        <div class="login-header"></div>
        <div>
            <asp:Login ID="LoginControl" runat="server" BorderPadding="8" LoginButtonText="" Orientation="Horizontal" PasswordLabelText="رمز عبور:" PasswordRequiredErrorMessage="رمز عبور را وارد نمایید" RememberMeText="مرا به خاطر بسپار" TextLayout="TextOnTop" TitleText="ورود به سیستم" UserNameLabelText="نام کاربری:" UserNameRequiredErrorMessage="نام کاربری را وارد نمایید" Width="500px" CssClass="login" FailureText="نام کاربری یا رمز عبور اشتباه است، لطفاً مجدداً سعی کنید" LoginButtonType="Button" OnLoggedIn="loginToSite_LoggedIn">
                <FailureTextStyle ForeColor="#b11116" />
                <LoginButtonStyle CssClass="login-button" />
                <TextBoxStyle CssClass="textbox" />
                <TitleTextStyle CssClass="login-title" />
                <LabelStyle CssClass="login-label" />
            </asp:Login>
        </div>
        <div class="login-footer"></div>

    </div>
</asp:Content>

