<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchMosavab.ascx.cs" Inherits="Views_UserControls_SearchMosavab" %>
<%@ Register Src="~/Views/UserControls/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="advance-search">

    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="Up_FieldSelector">
        <ProgressTemplate>
            <div class="overload">
                <div class="loading-large center"></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="Up_FieldSelector" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmb_Fields" runat="server" CssClass="combobox" 
                            Width="180px" AutoPostBack="true" 
                            OnSelectedIndexChanged="cmb_Fields_SelectedIndexChanged">
                            <asp:ListItem Text="عنوان مصوبه" Value="Subject"></asp:ListItem>
                            <asp:ListItem Text="شماره مصوبه" Value="Shomare"></asp:ListItem>
                            <asp:ListItem Text="شرح مصوبات" Value="Explanation"></asp:ListItem>
                            <asp:ListItem Text="شماره جلسه" Value="MeetingNo"></asp:ListItem>
                            <asp:ListItem Text="تاریخ جلسه" Value="DateOfMeeting"></asp:ListItem>
                            <asp:ListItem Text="تاریخ ثبت" Value="DateOfCreate"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_ConditionSelector" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmb_Condition" runat="server" CssClass="combobox" Width="120px">
                            <asp:ListItem Text="مساوی باشد با" Value="1"></asp:ListItem>
                            <asp:ListItem Text="مشابه باشد با" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_ValueEntering" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="tb_Value" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                        <uc:DateSelector runat="server" ID="uc_DateSelector" YearMinMax="1370;1410" Visible="false"/>
                        <asp:DropDownList ID="cmb_Value" runat="server" CssClass="combobox" Width="150px" AutoPostBack="true" Visible="false">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="Up_AddCondition" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-add-item" 
                            onclick="LinkButton1_Click"></asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="Up_AddCondition">
                    <ProgressTemplate>
                        <div class="loading"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>

    <asp:UpdatePanel ID="Up_Conditions" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="grid_conditions" runat="server" AutoGenerateColumns="false" 
                    GridLines="None" HeaderStyle-Height="0px" Width="100%" 
                    OnRowCommand="grid_conditions_RowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30%">
                            <ItemTemplate>
                                <div class="condition-item">
                                    <%# Eval("field_name") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30%">
                            <ItemTemplate>
                                <div class="condition-item">
                                    <%# Eval("condition_name") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="30%">
                            <ItemTemplate>
                                <div class="condition-item">
                                    <%# Eval("value_name") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:LinkButton ID="btn_delete" runat="server" CssClass="grid-button grid-button-delete" CommandName="DeleteItem" CommandArgument='<%# Eval("id") %>' ToolTip="حذف"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</div>