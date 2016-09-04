<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Demo.Web.Sys.Account.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pagemanager_01" AutoSizePanelID="panel_01" runat="server"></f:PageManager>

        <f:Panel ID="panel_01" Layout="Fit" ShowBorder="False" ShowHeader="false" runat="server">
            <Toolbars>
                <f:Toolbar ID="toolbar1" runat="server">
                    <Items>
                        <f:Button ID="Button1" Text="保存" ValidateForms="simpleForm_01,simpleForm_02" Icon="SystemSave" OnClick="btnSave_Click" runat="server">
                        </f:Button>
                        <f:Button ID="Button2" Text="关闭" Icon="SystemClose" OnClick="btnClose_Click" runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:TabStrip ID="tabStrip_01" Width="850px" Height="350px" ShowBorder="true" TabPosition="Top" EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server">
                    <Tabs>
                        <f:Tab ID="tab_01" Title="标签一" BodyPadding="5px" Layout="Fit" runat="server">
                            <Items>
                                <f:SimpleForm ID="simpleForm_01" ShowHeader="false" AutoScroll="true" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TextBox ID="txbAccountName" Label="用户名" Enabled="false" runat="server">
                                        </f:TextBox>
                                        <f:TextBox ID="txbPassword" Label="密码" Enabled="false" runat="server">
                                        </f:TextBox>
                                    </Items>
                                </f:SimpleForm>
                            </Items>
                        </f:Tab>
                        <f:Tab ID="tab_02" Title="标签二" BodyPadding="5px" Layout="Fit" runat="server">
                            <Items>
                                <f:SimpleForm ID="simpleForm_02" ShowHeader="false" ShowBorder="false" runat="server">
                                    <Items>
                                        <f:TriggerBox ID="tgbRoleName" Label="角色名称" EnableEdit="false" TriggerIcon="Search" runat="server">
                                        </f:TriggerBox>
                                        <f:HiddenField ID="hdfRoleID" runat="server">
                                        </f:HiddenField>
                                    </Items>
                                </f:SimpleForm>
                            </Items>
                        </f:Tab>
                    </Tabs>
                </f:TabStrip>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="选择" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
