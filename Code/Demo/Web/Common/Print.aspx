<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Demo.Web.Common.Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="margin:0 auto">
            <tr>
                <td>
                    <label>1.选择需要打印的列：</label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="cblColumn" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem Text="列1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="列2" Value="2"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>2.设置需要打印的记录范围（n/条）：</label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txbStartNumber" TextMode="Number" Width="90px" runat="server"></asp:TextBox>
                    <label>--</label>
                    <asp:TextBox ID="txbEndNumber" TextMode="Number" Width="90px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>3.目标文件类型：</label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Excel文件</label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
