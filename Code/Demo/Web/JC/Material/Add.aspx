<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Demo.Web.JC.Material.Add" %>

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
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="formInfo_01,formInfo_02" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>                       
                <f:TabStrip ID="tabStripMaterial" ShowBorder="false" EnableTabCloseMenu="true" runat="server">
                    <Tabs>
                        <f:Tab ID="tabBasic" Title="基本属性" runat="server">
                            <Items>
                                <f:Form ID="formInfo_01" ShowBorder="false" LabelAlign="left" ShowHeader="false" runat="server"
                                    EnableCollapse="false" Expanded="true" LabelWidth="100px">
                                    <Rows>
                                        <f:FormRow>
                                            <Items>
                                                <f:TextBox ID="txbMaterialNO" Label="物料编号" Width="300px" Required="true" runat="server">
                                                </f:TextBox>
                                                <f:TextBox ID="txbMaterialName" Label="物料名称" Width="300px" Required="true" runat="server">
                                                </f:TextBox>                                 
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items>
                                                <f:DropDownList ID="ddlPropertyName" Label="物料属性" Width="300px" Required="true" runat="server">
                                                </f:DropDownList>
                                                <f:TextBox ID="txbSpecification" Label="规格" Width="300px" runat="server">
                                                </f:TextBox>
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items> 
                                                <f:TextBox ID="txbModel" Label="型号" Width="300px" runat="server">
                                                </f:TextBox> 
                                                <f:TextBox ID="txbUnit" Label="单位" Width="300px" Required="true" runat="server">
                                                </f:TextBox> 
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items> 
                                                <f:NumberBox ID="nbxFixedLeadTime" Label="固定提前期" Width="300px" MinValue="0" NoDecimal="true" Required="true" runat="server">
                                                </f:NumberBox> 
                                                <f:NumberBox ID="nbxVariableLeadTime" Label="变动提前期" Width="300px" MinValue="0" NoDecimal="true" Required="true" runat="server">
                                                </f:NumberBox> 
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items>
                                                <f:NumberBox ID="nbxVariableBatch" Label="变动批量" Width="300px" MinValue="0" NoDecimal="true" Required="true" runat="server">
                                                </f:NumberBox> 
                                                <f:NumberBox ID="nbxUnitStandardCost" Label="单位标准成本" Width="300px" MinValue="0" DecimalPrecision="2" Required="true" runat="server">
                                                </f:NumberBox>
                                            </Items>
                                        </f:FormRow>
                                    </Rows>
                                </f:Form>
                            </Items>
                        </f:Tab>
                        <f:Tab ID="tabExtend" Title="扩展属性" runat="server">
                            <Items>
                                <f:Form ID="formInfo_02" ShowBorder="false" LabelAlign="left" ShowHeader="false" runat="server"
                                    EnableCollapse="false" Expanded="true" LabelWidth="100px">
                                    <Rows>
                                        <f:FormRow>
                                            <Items>
                                                <f:TriggerBox ID="tgbProcessRouteNO" Label="工艺路线编号" Width="300px" EnableEdit="false" TriggerIcon="Search" runat="server">
                                                </f:TriggerBox> 
                                                <f:NumberBox ID="nbxProductionVolume" Label="生产批量" Width="300px" MinValue="0" NoDecimal="true" runat="server">
                                                </f:NumberBox>                            
                                            </Items>
                                        </f:FormRow>
                                        <f:FormRow>
                                            <Items>
                                                <f:NumberBox ID="nbxIncreaseAmount" Label="批量增量" Width="300px" MinValue="0" NoDecimal="true" runat="server">
                                                </f:NumberBox>
                                                <f:NumberBox ID="nbxUnitStandardTime" Label="单位标准工时" Width="300px" MinValue="0" DecimalPrecision="2" runat="server">
                                                </f:NumberBox> 
                                            </Items>
                                        </f:FormRow>
                                    </Rows>
                                </f:Form>
                            </Items>
                        </f:Tab>
                    </Tabs>
                </f:TabStrip>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="新增" EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
