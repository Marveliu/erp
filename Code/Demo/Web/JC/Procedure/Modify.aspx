<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Demo.Web.JC.Procedure.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01"  AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="False" AutoScroll="true" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveContinue" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="infoForm" Icon="SystemSaveNew">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="infoForm" ShowBorder="true" LabelAlign="Left" ShowHeader="false" runat="server"
                    EnableCollapse="false" Expanded="true" LabelWidth="80px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbProcedureNO" Width="300px" Label="工序编码" Readonly="true" runat="server" ></f:TextBox>
                                <f:TextBox ID="txbProcedureName" Width="300px" Label="工序名称" Readonly="true" runat="server" ></f:TextBox>                                        
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TriggerBox ID="tgbWorkCenter" Label="工艺路线编号" Width="300px" EnableEdit="false" TriggerIcon="Search" runat="server">
                                </f:TriggerBox>
                                <f:HiddenField ID="hdfWorkCenterNO" runat="server"></f:HiddenField>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="选择" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>

