﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Demo.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
    <div>
        <f:PageManager ID="pageManager_01" runat="server"></f:PageManager>

        <f:Window ID="windowLogin" Title="登陆" EnableClose="false" IsModal="false" WindowPosition="GoldenSection" Width="350px" runat="server">
            <Items>
                <f:SimpleForm ID="simpleForm_01" ShowBorder="false" BodyPadding="10px" LabelWidth="60px" ShowHeader="false" runat="server">
                    <Items>
                        <f:TextBox ID="txbUserName" Label="用户名" Required="true" runat="server"></f:TextBox>
                        <f:TextBox ID="txbPassword" Label="密码" TextMode="Password" Required="true" runat="server"></f:TextBox>
                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar ID="toolbar_01" ToolbarAlign="Center" Position="Bottom" runat="server">
                    <Items>
                        <f:Button ID="btnLogin" Type="Submit" Text="登录" ValidateForms="sf_01" ValidateTarget="Top" OnClick="btnLogin_Click" runat="server"></f:Button>
                        <f:Button ID="btnRegister" Type="Button" Text="注册" EnablePostBack="true" runat="server" OnClick="btnRegister_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
    </div>
    </form>
</body>
</html>
