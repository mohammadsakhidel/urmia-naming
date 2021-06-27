<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MosavabDetails.ascx.cs" Inherits="Views_UserControls_MosavabDetails" %>

<table border="0" cellpadding="3" cellspacing="0">
    <tr>
        <td class="form-label-conteiner">
            عنوان مصوبه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Subject" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شماره مصوبه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Shomare" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شرح مصوبات :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Explanation" runat="server" CssClass="textbox-readonly" Width="400px" TextMode="MultiLine" Height="80px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شماره جلسه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_MeetingNo" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            تاریخ جلسه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_DateOfMeeting" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            شرکت کنندگان در جلسه :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_Participants" runat="server" CssClass="textbox-readonly" Width="400px" TextMode="MultiLine" Height="80px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            تاریخ ثبت :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_DateOfCreate" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="form-label-conteiner">
            کاربر ثبت کننده :
        </td>
        <td class="form-input-conteiner">
            <asp:TextBox ID="tb_CreatedBy" runat="server" CssClass="textbox-readonly" Width="200px" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
</table>

<asp:Panel ID="pnl_Photos" runat="server" style="padding: 10px 0 0 0;">

    <asp:DataList ID="list_MosavabPhotos" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
        
        <ItemTemplate>
            
            <div class="list-thumb-container">

                <a href='<%# MyHelper.Url(Urls.MosavabPhotos + Eval("FileName")) %>' style="border :none;">
                    <img alt="" title="" src='<%# MyHelper.Url(Urls.MosavabThumbnails) + Eval("FileName") %>' width="125px" class="thumbnail"/>
                </a>

            </div>

        </ItemTemplate>

    </asp:DataList>

</asp:Panel>

<asp:HiddenField ID="hid_MosavabID" runat="server" Value="0"/>
