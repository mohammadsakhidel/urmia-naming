<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportOfPassways.ascx.cs" Inherits="Views_UserControls_ReportOfPassways" %>

<script type="text/javascript" src="../../Scripts/jquery.maskedinput.min.js"></script>
<script type="text/javascript">

    $(function () {
        $("[id*=tb_BeginDate]").mask("1399/99/99");
        $("[id*=tb_EndDate]").mask("1399/99/99");
    });

</script>

<div class="filtering-container">

    <table border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td class="form-label-conteiner">
                از تاریخ:
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_BeginDate" runat="server" CssClass="textbox ltr" Width="70px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" CssClass="validator" 
                    ControlToValidate="tb_BeginDate" ValidationGroup="ShowChart"></asp:RequiredFieldValidator>
            </td>
            <td class="form-label-conteiner">
                تا تاریخ:
            </td>
            <td class="form-input-conteiner">
                <asp:TextBox ID="tb_EndDate" runat="server" CssClass="textbox ltr" Width="70px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" CssClass="validator" 
                    ControlToValidate="tb_EndDate" ValidationGroup="ShowChart"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="form-label-conteiner">
                منطقه شهرداری:
            </td>
            <td class="form-input-conteiner">
                <asp:DropDownList ID="cmb_Region" runat="server" CssClass="combobox" Width="100px">
                    <asp:ListItem Text="همه مناطق" Value="0"></asp:ListItem>
                    <asp:ListItem Text="منطقه 1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="منطقه 2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="منطقه 3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="منطقه 4" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>

</div>

<div style="padding: 10px 0 10px 0;">

    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-submit" ValidationGroup="ShowChart" OnClick="LinkButton1_Click">نمایش نمودار</asp:LinkButton>

</div>

<div class="table center">

    <asp:Chart ID="chart_Report" runat="server" Width="700px" Height="370px" BackColor="#f8f8f8" Visible="false">
        <Series>
            <asp:Series Name="chart_Report_Series" YValueType="Int32">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="chart_Report_Area" BackColor="#f6f6f6">
                <Area3DStyle Enable3D="false" Inclination="20" LightStyle="Realistic" WallWidth="15" Perspective="0" PointGapDepth="0" PointDepth="40"/>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

</div>