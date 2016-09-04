<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Demo.Web.JH.MPS.Modify" %>

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
                                <f:TextBox ID="txbMaterialNO" Label="物料编号" Width="300px" Readonly="true" runat="server">
                                </f:TextBox> 
                                <f:TextBox ID="txbMaterialName" Label="物料名称" Width="300px" Readonly="true" runat="server">
                                </f:TextBox>                               
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbPlanNO" Label="计划编号" Width="300px" runat="server">
                                </f:TextBox>                              
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:DatePicker ID="dapEndDate" Label="需求日期" Width="300px" EnableEdit="false" Readonly="true" runat="server"></f:DatePicker>
                                <f:NumberBox ID="nbxPlanAmount" Label="计划数量" NoNegative="true" DecimalPrecision="2" Width="300px" Readonly ="true" runat="server"></f:NumberBox>
                            </Items>
                        </f:FormRow> 
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
