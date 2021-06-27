<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PasswayPhotos.ascx.cs" Inherits="Views_UserControls_PasswayPhotos" %>

<asp:Panel ID="pnl_UploadFile" runat="server">
    <table border="0" cellpadding="3" cellspacing="0">

        <tr>
            <td>
                <asp:FileUpload ID="fileUploader" runat="server" CssClass="uploader" Width="250px"/>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-submit" OnClick="LinkButton1_Click">ارسال تصویر</asp:LinkButton>
            </td>
        </tr>

    </table>
</asp:Panel>

<asp:Panel ID="pnl_Photos" runat="server" Visible="false">

    <asp:DataList ID="list_PasswayPhotos" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="list_PasswayPhotos_ItemCommand">
        
        <ItemTemplate>
            
            <div class="list-thumb-container">

                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="grid-button grid-button-delete2" 
                    OnClientClick="return confirm('آیا اطمینان دارید؟');" Visible='<%# Access.DeletePhoto %>'
                    style="position: absolute; left: 10px; top: 10px;" CommandName="DeletePasswayPhoto" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>

                <img alt="" title="" src='<%# MyHelper.Url(Urls.PasswayThumbnails) + Eval("FileName") %>' width="140px" class="thumbnail"/>

            </div>

        </ItemTemplate>

    </asp:DataList>

</asp:Panel>


<!-- -------------------------------- hiddens -------------------------------- -->
<asp:HiddenField ID="hid_PasswayID" runat="server" Value="0"/>
<asp:HiddenField ID="hid_Access" runat="server" Value="11111111"/>