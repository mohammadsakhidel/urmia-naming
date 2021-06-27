<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PasswayEditor.ascx.cs" Inherits="Views_UserControls_PasswayEditor" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<fieldset style="margin-bottom: 15px;">
    <legend>اطلاعات پایه</legend>

    <table border="0">
        <tr>
            <td class="form-label-conteiner">
                <label>شناسه فرم:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_RecordId" runat="server" CssClass="textbox2" Width="70px"></asp:TextBox>
            </td>
            <td class="form-col-sep"></td>
            <td class="form-label-conteiner">
                <label>منطقه شهرداری:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:DropDownList ID="cmb_Region" runat="server" CssClass="combobox2" Width="140px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="form-label-conteiner">
                <asp:CheckBox ID="ch_HasName" runat="server" Text="نام معبر:" CssClass="required" Checked="true" ClientIDMode="Static" />
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_Name" runat="server" CssClass="textbox2" Width="140px" ClientIDMode="Static"></asp:TextBox>
                <a class="link" onclick="<%= "return openNames('" + MyHelper.Url(MyHelper.GetFolderUrl()) + "');" %>">جستجو</a>
            </td>
            <td class="form-col-sep"></td>
            <td class="form-label-conteiner">
                <label class="required">نوع معبر:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:DropDownList ID="cmb_Type" runat="server" CssClass="combobox2" Width="140px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" CssClass="validator"
                    ControlToValidate="cmb_Type" ValidationGroup="SaveFormData"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="form-label-conteiner">
                <label>شناسه فرم معبر ماقبل:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_PrecedingRecordId" runat="server" CssClass="textbox2" Width="70px"></asp:TextBox>
            </td>
            <td class="form-col-sep"></td>
            <td class="form-label-conteiner">
                <label>نوع معبر ماقبل:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:DropDownList ID="cmb_PrecedingType" runat="server" CssClass="combobox2" Width="140px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="form-label-conteiner">
                <label>نام معبر ماقبل:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_PrecedingName" runat="server" CssClass="textbox2" Width="140px"></asp:TextBox>
            </td>
            <td class="form-col-sep"></td>
            <td class="form-label-conteiner">
                <label>شماره مصوبه:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_MosavabID" runat="server" CssClass="textbox2" Width="80px"></asp:TextBox>
                <a class="link" onclick="<%= "return openMosavabs('" + MyHelper.Url(MyHelper.GetFolderUrl()) + "');" %>">جستجو</a>
            </td>
        </tr>
        <tr>
            <td class="form-label-conteiner">
                <label>عرض معبر:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_Width" runat="server" CssClass="textbox2" Width="50px"></asp:TextBox>
                متر
            </td>
            <td class="form-col-sep"></td>
            <td class="form-label-conteiner">
                <label>نوع کف معبر:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:DropDownList ID="cmb_FloorType" runat="server" CssClass="combobox2" Width="140px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="form-label-conteiner">
                <asp:CheckBox runat="server" ID="ch_HasBoard" Text="تابلو:" />
            </td>
            <td class="form-input-conteiner">
                <asp:DropDownList ID="cmb_BoardType" runat="server" CssClass="combobox2" Width="80px"></asp:DropDownList>
                ابعاد:
                <asp:TextBox ID="tb_BoardSize" runat="server" CssClass="textbox" Width="50px"></asp:TextBox>
            </td>
            <td class="form-col-sep"></td>
            <td class="form-label-conteiner">
                <label>منطقه پستی:</label>
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_PostArea" runat="server" CssClass="textbox2" Width="70px"></asp:TextBox>
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
                <asp:TextBox ID="tb_CountOfStores" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tb_CountOfShoppingCenters" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tb_CountOfCondominiums" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tb_CountOfOfficeComplexes" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tb_CountOfHouses" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tb_CountOfOfficeBuildings" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tb_CountOfOthers" runat="server" CssClass="textbox"></asp:TextBox>
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

<fieldset>
    <legend>سایر اطلاعات</legend>

    <table border="0" style="width: 100%; border-spacing: 8px;">
        <tr>
            <td>
                <asp:CheckBox ID="ch_HasChannel" runat="server" Text="دارای کانال" />
                <asp:DropDownList ID="cmb_ChannelType" runat="server" CssClass="combobox" Width="80px"></asp:DropDownList>
            </td>
            <td>
                <asp:CheckBox ID="ch_HasPlanting" runat="server" Text="درختکاری دارد" />
            </td>
            <td colspan="2">
                <asp:CheckBox ID="ch_HasSidewalk" runat="server" Text="دارای پیاده رو" />
                <asp:DropDownList ID="cmb_SidewalkFloorType" runat="server" CssClass="combobox" Width="80px"></asp:DropDownList>
                <label>عرض:</label>
                <asp:TextBox ID="tb_SidewalkWidth" runat="server" Width="40px" CssClass="textbox"></asp:TextBox>
                <asp:CheckBox ID="ch_IsSidewalkIncomplete" runat="server" Text="ناقص" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="form-table" style="direction: ltr;">
                    <tr>
                        <td colspan="2">
                            <span>مختصات ابتدای معبر</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Latitude (عرض جغرافیایی)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_BeginingLatitude" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
                        </td>
                        <td>Longitude (طول جغرافیایی)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_BeginingLongitude" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
                        </td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table class="form-table" style="direction: ltr;">
                    <tr>
                        <td colspan="2">
                            <span>مختصات انتهای معبر</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Latitude (عرض جغرافیایی)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_EndingLatitude" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
                        </td>
                        <td>Longitude (طول جغرافیایی)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_EndingLongitude" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
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
                            <span>مختصات ابتدای معبر</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Y (UTM)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_BeginingY" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
                        </td>
                        <td>X (UTM)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_BeginingX" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
                        </td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <table class="form-table" style="direction: ltr;">
                    <tr>
                        <td colspan="2">
                            <span>مختصات انتهای معبر</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Y (UTM)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_EndingY" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
                        </td>
                        <td>X (UTM)
                            <br />
                            <br />
                            <asp:TextBox ID="tb_EndingX" runat="server" Width="150px" CssClass="textbox" ClientIDMode="Static" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="up_PasswayLength" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btnCalcPasswayLength" runat="server" CssClass="link" OnClick="btnCalcPasswayLength_Click">طول معبر:</asp:LinkButton>
                                    <asp:Label ID="lblPasswayLength" runat="server" Text="-"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="loading-container">
                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="up_PasswayLength">
                                <ProgressTemplate>
                                    <div class="loading"></div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <label>توضیحات:</label><br />
                <asp:TextBox ID="tb_Explanation" runat="server" CssClass="textbox2" Width="90%" Height="40px" TextMode="MultiLine" Style="margin-top: 5px;"></asp:TextBox>
            </td>
        </tr>
    </table>

</fieldset>

<div class="form-submit">
    <table border="0" cellpadding="0" cellspacing="0" class="center">
        <tr>
            <td>
                <asp:UpdatePanel ID="up_save" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="btn-submit"
                            ValidationGroup="SaveFormData" OnClick="btnSave_Click">ذخیره اطلاعات</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="loading-container">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up_save">
                    <ProgressTemplate>
                        <div class="loading"></div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <div class="form-message">
        <asp:UpdatePanel ID="up_message" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lbl_Message" runat="server" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>

<!-- ***************** hidden fields: *************** -->
<asp:HiddenField ID="hid_PasswayID" runat="server" Value="0" />
<asp:HiddenField ID="hid_FormAction" runat="server" Value="1" />

<script>
    $(function () {
        $('#ch_HasName').change(function () {
            if ($(this).is(":checked")) {
                $('#tb_Name').prop("disabled", false);
            } else {
                $('#tb_Name').prop("disabled", true);
                $('#tb_Name').val("");
            }
        });
    });

    function selectPasswayEndPoint(root) {

        var shape = "";
        var lat = String($("input#tb_EndingLatitude").val());
        var lng = String($("input#tb_EndingLongitude").val());
        if (lat.length > 0 && lng.length > 0) {
            shape = "line: abc," + lng + "," + lat;
        }

        return openMap(root, 'end', shape);

    }

    function selectPasswayBeginPoint(root) {

        var shape = "";
        var lat = String($("input#tb_BeginingLatitude").val());
        var lng = String($("input#tb_BeginingLongitude").val());
        if (lat.length > 0 && lng.length > 0) {
            shape = "line: abc," + lng + "," + lat;
        }

        return openMap(root, 'begin', shape);

    }
</script>
