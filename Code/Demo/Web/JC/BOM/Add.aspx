<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Demo.Web.JC.BOM.Add" %>

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
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="formInfo" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="formInfo" ShowBorder="true" LabelAlign="left" ShowHeader="false" runat="server"
                    EnableCollapse="false" Expanded="true" LabelWidth="80px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TriggerBox ID="tgbMaterialNO" Label="物料编号" Width="400px" EnableEdit="false" TriggerIcon="Search" 
                                    Required="true" runat="server">
                                </f:TriggerBox>
                                <f:TextBox ID="txbMaterialName" Label="物料名称" Width="400px" Readonly="true" runat="server">
                                </f:TextBox>                               
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbPropertyName" Label="物料属性" Width="400px" Readonly="true" runat="server"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:HiddenField ID="hdfPropertyNO" OnTextChanged="hdfPropertyNO_TextChanged" runat="server"></f:HiddenField>
                                <f:HiddenField ID="hdfOther" runat="server"></f:HiddenField>
                            </Items>
                        </f:FormRow>  
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="新增" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
