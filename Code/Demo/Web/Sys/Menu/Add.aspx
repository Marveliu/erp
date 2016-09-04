<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Demo.Web.Sys.Menu.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pagemanager_01" AutoSizePanelID="panel_01" runat="server"></f:PageManager>

        <f:Panel ID="panel_01" Layout="Fit" ShowBorder="False" ShowHeader="false" runat="server">
            <Items>
                <f:Form ID="formInfo" ShowBorder="true" LabelAlign="Left" ShowHeader="false" EnableCollapse="false" Expanded="true" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnSave" Text="保存" ValidateForms="formInfo" Icon="SystemSave" OnClick="btnSave_Click" runat="server">
                                </f:Button>
                                <f:Button ID="btnClose" Text="关闭" Icon="SystemClose" OnClick="btnClose_Click" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:NumberBox ID="nbbMenuNO" Enabled="false" Label="菜单级别" MinValue="1" MaxValue="3" NoDecimal="true" NoNegative="true" runat="server">
                                </f:NumberBox>

                                <f:TextBox ID="txbMenuName" Label="菜单名称" Required="true" runat="server">
                                </f:TextBox>

                                <%--未实现嵌套检测,存在坏数据--%>
                                <f:TriggerBox ID="tgbParentName" Label="父项菜单名称" EnableEdit="false" EnablePostBack="false"
                                    TriggerIcon="Search" Required="false" runat="server">
                                </f:TriggerBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbMenuUrl" Label="页面地址" Required="false" runat="server">
                                </f:TextBox>

                                <%-- 2016年1月29日移除
                                <f:TextBox ID="txbImageUrl" Label="图标地址" Required="false" runat="server">
                                </f:TextBox>
                                --%>

                                <f:DropDownList ID="ddlState" Label="菜单状态" AutoPostBack="false" runat="server">
                                    <f:ListItem Text="有效" Value="1" Selected="true"/>
                                    <f:ListItem Text="无效" Value="0" EnableSelect="false"/>
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <%--隐藏项：父项菜单ID--%>
                                <f:HiddenField ID="hdfParentID" runat="server">
                                </f:HiddenField>
                                <%--隐藏项：父项菜单级别--%>
                                <f:HiddenField ID="hdfParentNO" runat="server">
                                </f:HiddenField>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="选择" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
