<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Demo.Web.JH.RequirementPlan.Add" %>

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
                                <f:TextBox ID="txbBillNO" Width="300px" Label="单据编号" Required="true" runat="server" ></f:TextBox>
                                <f:DropDownList ID="ddlBillType" Width="300px" Label="单据类型" Required="true" runat="server">
                                    <f:ListItem Text="销售订单" Value="S" />
                                    <f:ListItem Text="预测单" Value="F" />
                                    <f:ListItem Text="紧急订单" Value="R" />
                                </f:DropDownList>                                        
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TriggerBox ID="tgbMaterialNO" Label="物料编号" Width="300px" EnableEdit="false" TriggerIcon="Search" 
                                    Required="true" runat="server">
                                </f:TriggerBox>
                                <f:TextBox ID="txbMaterialName" Label="物料名称" Width="300px" Readonly="true" runat="server">
                                </f:TextBox>                                         
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:NumberBox ID="nbxPlanAmount" Label="计划数量" Width="300px" NoNegative="true" DecimalPrecision="2" 
                                    Required="true" runat="server"></f:NumberBox>
                                <f:DatePicker ID="dapEndDate" Label="截至日期" Width="300px" EnableEdit="false" OnPreRender="dap_PreRender" Required="true"  runat="server"></f:DatePicker>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
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
