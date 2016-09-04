<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Demo.Web.JC.RoutingSub.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01"  AutoSizePanelID="panelMain" runat="server" />

        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="False" AutoScroll="true" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="infoForm" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="infoForm" ShowBorder="true" LabelAlign="Left" ShowHeader="false" runat="server"
                    EnableCollapse="false" Expanded="true" LabelWidth="100px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TriggerBox ID="tgbProcedureNO" Label="工序编码" Width="300px" EnablePostBack="false" TriggerIcon="Search" Required="true" runat="server"></f:TriggerBox>    
                                <f:TextBox ID="txbProcedureName" Width="300px" Label="工序名称" Readonly="true" runat="server" ></f:TextBox>    
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:NumberBox ID="nbxProcedureOrder" Width="300px" Label="工序次序" NoDecimal="true" NoNegative="true" Required="true" runat="server" > </f:NumberBox>           
                                <f:HiddenField ID="hdfRoutingID" runat="server"></f:HiddenField> 
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>    
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
