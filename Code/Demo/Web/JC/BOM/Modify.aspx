<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Demo.Web.JC.BOM.Modify" %>

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
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="infoForm" Icon="SystemSave">
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
                                <f:TextBox ID="txbMaterialName" Label="物料名称" Width="400px" Readonly="true" runat="server"></f:TextBox>
                                <f:TextBox ID="txbMaterialNO" Label="物料编号" Width="400px" Readonly="true" runat="server"></f:TextBox>                               
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>                                                            
                                <f:TextBox ID="txbPropertyName" Label="物料属性" Width="400px" Readonly="true" runat="server"></f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TriggerBox ID="tgbCheckName" Label="审核人" Width="400px" Readonly="true" TriggerIcon="Search" runat="server">
                                </f:TriggerBox>
                                <f:DatePicker ID="dapCheckDate" Label="审核日期" Width="400px" Readonly="true" runat="server">
                                </f:DatePicker>                                   
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:HiddenField ID="hdfCheckNO" Width="400px" runat="server"></f:HiddenField>
                                <f:HiddenField ID="hdfPropertyNO" Width="400px" runat="server"></f:HiddenField>                                 
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>                                      
                                <f:DropDownList ID="ddlCheckStatus" Label="审核状态" Width="400px" runat="server">
                                    <f:ListItem Text="未审核" Value="C" Selected="true"/>
                                    <f:ListItem Text="审核通过" Value="Y" />
                                    <f:ListItem Text="审核不通过" Value="N" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>                                      
                                <f:DropDownList ID="ddlStatus" Label="BOM状态" Width="400px" runat="server">
                                    <f:ListItem Text="不可用" Value="N" Selected="true"/>
                                    <f:ListItem Text="可用" Value="Y" />
                                </f:DropDownList>
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
