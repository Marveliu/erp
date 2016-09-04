<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Demo.Web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <br />
        <f:Window ID="Window1" runat="server" Title="注册表单" IsModal="false" EnableClose="false"
            WindowPosition="GoldenSection" Width="350px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" BodyPadding="10px"
                    LabelWidth="60px" ShowHeader="false">
                    <Items>
                        <f:TextBox ID="tbxUserName" Label="用户名" Required="true" runat="server">
                        </f:TextBox>
                        <f:TextBox ID="tbxPassword" Label="输入密码" TextMode="Password" Required="true" runat="server">
                        </f:TextBox>
                        <f:TextBox ID="tbxPassword1" Label="确认密码" TextMode="Password" CompareControl="tbxPassword" CompareMessage="两次输入不一致" CompareOperator="Equal" Required="true" runat="server">
                        </f:TextBox>
                        <f:TextBox ID="tbxCaptcha" Label="验证码" Required="true" runat="server">
                        </f:TextBox>
                        <f:Panel CssStyle="padding-left:65px;" ShowBorder="false" ShowHeader="false"
                            runat="server">
                            <Items>
                                <f:Image ID="imgCaptcha" CssStyle="float:left;width:160px;" runat="server">
                                </f:Image>
                                <f:LinkButton CssStyle="float:left;margin-top:8px;" ID="btnRefresh" Text="看不清？"
                                    runat="server" OnClick="btnRefresh_Click">
                                </f:LinkButton>
                            </Items>
                        </f:Panel>
                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="btnRegister" Text="注册" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top"
                            runat="server" OnClick="btnRegister_Click">
                        </f:Button>
                        <f:Button ID="btnReset" Text="重置" Type="Reset" EnablePostBack="false"
                            runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
    </form>
</body>
</html>
