<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PasswayDetails.ascx.cs" Inherits="Views_UserControls_PasswayDetails" %>
<%@ Register Src="~/Views/UserControls/GoogleMap.ascx" TagPrefix="uc" TagName="GoogleMap" %>

<asp:Panel runat="server" Enabled="false">
    <fieldset style="margin-bottom: 15px;">
        <legend>اطلاعات پایه</legend>

        <table border="0">
            <tr>
                <td class="form-label-conteiner">
                    <label>شناسه فرم:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_RecordId" runat="server" CssClass="textbox-readonly" Width="70px" ReadOnly="true"></asp:TextBox>
                </td>
                <td class="form-col-sep"></td>
                <td class="form-label-conteiner">
                    <label>منطقه شهرداری:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_Region" runat="server" CssClass="textbox-readonly" Width="140px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="form-label-conteiner">
                    <asp:CheckBox ID="ch_HasName" runat="server" Text="نام معبر:" />
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_Name" runat="server" CssClass="textbox-readonly" Width="140px" ReadOnly="true"></asp:TextBox>
                </td>
                <td class="form-col-sep"></td>
                <td class="form-label-conteiner">
                    <label>نوع معبر:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_Type" runat="server" CssClass="textbox-readonly" Width="140px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="form-label-conteiner">
                    <label>شناسه فرم معبر ماقبل:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_PrecedingRecordId" runat="server" CssClass="textbox-readonly" Width="70px" ReadOnly="true"></asp:TextBox>
                </td>
                <td class="form-col-sep"></td>
                <td class="form-label-conteiner">
                    <label>نوع معبر ماقبل:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_PrecedingType" runat="server" CssClass="textbox-readonly" Width="140px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="form-label-conteiner">
                    <label>نام معبر ماقبل:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_PrecedingName" runat="server" CssClass="textbox-readonly" Width="140px" ReadOnly="true"></asp:TextBox>
                </td>
                <td class="form-col-sep"></td>
                <td class="form-label-conteiner">
                    <label>شماره مصوبه:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_MosavabID" runat="server" CssClass="textbox-readonly" Width="80px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="form-label-conteiner">
                    <label>عرض معبر:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_Width" runat="server" CssClass="textbox-readonly" Width="50px" ReadOnly="true"></asp:TextBox>
                    متر
                </td>
                <td class="form-col-sep"></td>
                <td class="form-label-conteiner">
                    <label>نوع کف معبر:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_FloorType" runat="server" CssClass="textbox-readonly" Width="140px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="form-label-conteiner">
                    <asp:CheckBox runat="server" ID="ch_HasBoard" Text="تابلو:" />
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_BoardType" runat="server" CssClass="textbox-readonly" Width="80px" ReadOnly="true"></asp:TextBox>
                    ابعاد:
                    <asp:TextBox ID="tb_BoardSize" runat="server" CssClass="textbox-readonly" Width="50px" ReadOnly="true"></asp:TextBox>
                </td>
                <td class="form-col-sep"></td>
                <td class="form-label-conteiner">
                    <label>منطقه پستی:</label>
                </td>
                <td class="form-input-conteiner">
                    <asp:TextBox ID="tb_PostArea" runat="server" CssClass="textbox-readonly" Width="70px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="form-label-conteiner"></td>
                <td class="form-input-conteiner">
                    <asp:CheckBox ID="ch_HasLighting" runat="server" Text="معبر دارای روشنایی است" />
                </td>
                <td class="form-col-sep"></td>
                <td class="form-label-conteiner"></td>
                <td class="form-input-conteiner"></td>
            </tr>
        </table>

    </fieldset>

    <fieldset style="margin-bottom: 15px;">
        <legend>واحد ها</legend>

        <table class="form-table">
            <tr>
                <td>
                    <label>مغازه تکی</label>
                </td>
                <td>
                    <label>پاساژ</label>
                </td>
                <td>
                    <label>مجتمع مسکونی</label>
                </td>
                <td>
                    <label>مجتمع اداری/تجاری</label>
                </td>
                <td>
                    <label>ساختمان مسکونی</label>
                </td>
                <td>
                    <label>ساختمان اداری/تجاری</label>
                </td>
                <td>
                    <label>سایر</label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tb_CountOfStores" runat="server" CssClass="textbox-readonly"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_CountOfShoppingCenters" runat="server" CssClass="textbox-readonly"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_CountOfCondominiums" runat="server" CssClass="textbox-readonly"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_CountOfOfficeComplexes" runat="server" CssClass="textbox-readonly"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_CountOfHouses" runat="server" CssClass="textbox-readonly"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_CountOfOfficeBuildings" runat="server" CssClass="textbox-readonly"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tb_CountOfOthers" runat="server" CssClass="textbox-readonly"></asp:TextBox>
                </td>
            </tr>
        </table>

    </fieldset>

    <fieldset style="margin-bottom: 15px;">
        <legend>مبلمان</legend>

        <table border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:CheckBox ID="ch_HasFur" runat="server" Text="دارای مبلمان" />
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasFurNimkat" runat="server" Text="نیمکت" />
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasFurAbkhori" runat="server" Text="آبخوری" />
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasFurTrash" runat="server" Text="سطل زباله" />
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasFurBodyBuilding" runat="server" Text="دستگاه بدنسازی" />
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasFurToys" runat="server" Text="مجموعه بازی کودکان" />
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasFurLamps" runat="server" Text="چراغ های تزئینی" />
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasFurAdv" runat="server" Text="پانل آگهی" />
                </td>
            </tr>
        </table>

    </fieldset>

    <fieldset style="margin-bottom: 15px;">
        <legend>سایر اطلاعات</legend>

        <table border="0" style="width: 100%; border-spacing: 8px;">
            <tr>
                <td>
                    <asp:CheckBox ID="ch_HasChannel" runat="server" Text="دارای کانال" />
                    <asp:TextBox ID="tb_ChannelType" runat="server" CssClass="textbox-readonly" Width="80px" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="ch_HasPlanting" runat="server" Text="درختکاری دارد" />
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="ch_HasSidewalk" runat="server" Text="دارای پیاده رو" />
                    <asp:TextBox ID="tb_SidewalkFloorType" runat="server" CssClass="textbox-readonly" Width="80px" ReadOnly="true"></asp:TextBox>
                    <label>عرض:</label>
                    <asp:TextBox ID="tb_SidewalkWidth" runat="server" Width="40px" CssClass="textbox-readonly"></asp:TextBox>
                    <asp:CheckBox ID="ch_IsSidewalkIncomplete" runat="server" Text="ناقص" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="form-table" style="direction: ltr;">
                        <tr>
                            <td colspan="2">
                                <label>مختصات ابتدای معبر</label>
                            </td>
                        </tr>
                        <tr>
                            <td>Latitude (عرض جغرافیایی)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_BeginingLatitude" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                            <td>Longitude (طول جغرافیایی)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_BeginingLongitude" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table class="form-table" style="direction: ltr;">
                        <tr>
                            <td colspan="2">
                                <label>مختصات انتهای معبر</label>
                            </td>
                        </tr>
                        <tr>
                            <td>Latitude (عرض جغرافیایی)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_EndingLatitude" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                            <td>Longitude (طول جغرافیایی)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_EndingLongitude" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <table class="form-table" style="direction: ltr;">
                        <tr>
                            <td colspan="2">
                                <label>مختصات ابتدای معبر</label>
                            </td>
                        </tr>
                        <tr>
                            <td>Y (UTM)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_BeginingY" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                            <td>X (UTM)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_BeginingX" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table class="form-table" style="direction: ltr;">
                        <tr>
                            <td colspan="2">
                                <label>مختصات انتهای معبر</label>
                            </td>
                        </tr>
                        <tr>
                            <td>Y (UTM)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_EndingY" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                            <td>X (UTM)
                            <br />
                                <br />
                                <asp:TextBox ID="tb_EndingX" runat="server" Width="150px" CssClass="textbox-readonly" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                    <label>توضیحات:</label><br />
                    <asp:TextBox ID="tb_Explanation" runat="server" CssClass="textbox-readonly" Width="90%" Height="40px" TextMode="MultiLine" Style="margin-top: 5px;"></asp:TextBox>
                </td>
            </tr>
        </table>

    </fieldset>
</asp:Panel>

<asp:Panel runat="server" ID="pnl_Map">
    <uc:GoogleMap ID="uc_GoogleMap" runat="server" Width="700px" Height="500px" />
</asp:Panel>

<asp:Panel ID="pnl_Photos" runat="server" Style="padding: 10px 0 0 0;">

    <asp:DataList ID="list_PasswayPhotos" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">

        <ItemTemplate>

            <div class="list-thumb-container">

                <a href='<%# MyHelper.Url(Urls.PasswayPhotos + Eval("FileName")) %>' style="border: none;">
                    <img alt="" title="" src='<%# MyHelper.Url(Urls.PasswayThumbnails) + Eval("FileName") %>' width="125px" class="thumbnail" />
                </a>

            </div>

        </ItemTemplate>

    </asp:DataList>

</asp:Panel>

<asp:HiddenField ID="hid_PasswayID" runat="server" Value="0" />
