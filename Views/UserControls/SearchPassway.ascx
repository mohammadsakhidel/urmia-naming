<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchPassway.ascx.cs" Inherits="Views_UserControls_SearchPassway" %>
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
                            <asp:ListItem Text="شناسه فرم" Value="RecordId"></asp:ListItem>
                            <asp:ListItem Text="نام معبر" Value="Name"></asp:ListItem>
                            <asp:ListItem Text="نوع معبر" Value="Type"></asp:ListItem>
                            <asp:ListItem Text="نام معبر ماقبل آخر" Value="PrecedingName"></asp:ListItem>
                            <asp:ListItem Text="نوع معبر ماقبل آخر" Value="PrecedingType"></asp:ListItem>
                            <asp:ListItem Text="منطقه پستی" Value="PostArea"></asp:ListItem>
                            <asp:ListItem Text="منطقه شهرداری" Value="Region"></asp:ListItem>
                            <asp:ListItem Text="عرض معبر" Value="Width"></asp:ListItem>
                            <asp:ListItem Text="طول معبر" Value="Length"></asp:ListItem>
                            <asp:ListItem Text="تاریخ ثبت" Value="DateOfAdd"></asp:ListItem>
                            <asp:ListItem Text="توضیحات" Value="Explanation"></asp:ListItem>
                            <asp:ListItem Text="شناسه فرم معبر ماقبل" Value="PrecedingRecordId"></asp:ListItem>
                            <asp:ListItem Text="وضعیت تابلو" Value="HasBoard"></asp:ListItem>
                            <asp:ListItem Text="نوع تابلو" Value="BoardType"></asp:ListItem>
                            <asp:ListItem Text="ابعاد تابلو" Value="BoardSize"></asp:ListItem>
                            <asp:ListItem Text="وضعیت روشنایی" Value="HasLighting"></asp:ListItem>
                            <asp:ListItem Text="تعداد مغازه تکی" Value="CountOfStores"></asp:ListItem>
                            <asp:ListItem Text="تعداد پاساژ" Value="CountOfShoppingCenters"></asp:ListItem>
                            <asp:ListItem Text="تعداد مجتمع مسکونی" Value="CountOfCondominiums"></asp:ListItem>
                            <asp:ListItem Text="تعداد مجتمع اداری/تجاری" Value="CountOfOfficeComplexes"></asp:ListItem>
                            <asp:ListItem Text="تعداد ساختمان مسکونی" Value="CountOfHouses"></asp:ListItem>
                            <asp:ListItem Text="تعداد ساختمان اداری/تجاری" Value="CountOfOfficeBuildings"></asp:ListItem>
                            <asp:ListItem Text="تعداد سایر ساختمانها" Value="CountOfOthers"></asp:ListItem>
                            <asp:ListItem Text="وضعیت کانال" Value="HasChannel"></asp:ListItem>
                            <asp:ListItem Text="نوع کانال" Value="ChannelType"></asp:ListItem>
                            <asp:ListItem Text="وضعیت درختکاری" Value="HasPlanting"></asp:ListItem>
                            <asp:ListItem Text="وضعیت پیاده رو" Value="HasSidewalk"></asp:ListItem>
                            <asp:ListItem Text="نوع کف پیاده رو" Value="SidewalkFloorType"></asp:ListItem>
                            <asp:ListItem Text="عرض پیاده رو" Value="SidewalkWidth"></asp:ListItem>
                            <asp:ListItem Text="وضعیت مبلمان" Value="HasFur"></asp:ListItem>
                            <asp:ListItem Text="وضعیت نیمکت" Value="HasFurNimkat"></asp:ListItem>
                            <asp:ListItem Text="وضعیت آبخوری" Value="HasFurAbkhori"></asp:ListItem>
                            <asp:ListItem Text="وضعیت سطل زباله" Value="HasFurTrash"></asp:ListItem>
                            <asp:ListItem Text="وضعیت دستگاه بدنسازی" Value="HasFurBodyBuilding"></asp:ListItem>
                            <asp:ListItem Text="وضعیت مجموعه بازی کودکان" Value="HasFurToys"></asp:ListItem>
                            <asp:ListItem Text="وضعیت چراغ های تزئینی" Value="HasFurLamps"></asp:ListItem>
                            <asp:ListItem Text="وضعیت پانل آگهی" Value="HasFurAdv"></asp:ListItem>
                            <asp:ListItem Text="کاربر ثبت کننده" Value="AddedBy"></asp:ListItem>
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