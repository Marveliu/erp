<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JC.Material.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>物料信息</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />  
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">                 
            <Items>
                <f:Grid ID="gridMaterial" Title="物料信息表" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                    DataKeyNames="ID" AllowSorting="true" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="15" 
                    EnableMultiSelect="false" OnSort="grid_Sort" OnPageIndexChange="grid_PageIndexChange" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                </f:Button>
                                <f:Button ID="btnDelete" Text="删除选中行" OnClick="btnDelete_Click" Icon="Delete" runat="server">
                                </f:Button>
                                <f:Button ID="btnFilter" Text="筛选" Icon="Zoom" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>

                    <Columns>
                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                            DataWindowTitleField="MaterialName" DataWindowTitleFormatString="编辑 - {0}" />
                        <f:GroupField HeaderText ="基本属性" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="120px" ColumnID="MaterialNO" SortField="MaterialNO" DataField="MaterialNO"
                                    TextAlign="Center" HeaderText="物料编号"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="MaterialName" SortField="MaterialName" DataField="MaterialName"
                                    TextAlign="Center" HeaderText="物料名称"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="Specification" SortField="Specification" DataField="Specification"
                                    TextAlign="Center" HeaderText="规格"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="Model" SortField="Model" DataField="Model"
                                    TextAlign="Center" HeaderText="型号"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="Unit" SortField="Unit" DataField="Unit"
                                    TextAlign="Center" HeaderText="单位"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="PropertyName" SortField="PropertyName" DataField="PropertyName"
                                    TextAlign="Center" HeaderText="属性"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="UnitStandardCost" SortField="UnitStandardCost" DataField="UnitStandardCost"
                                    TextAlign="Center" HeaderText="单位标准成本"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="UnitStandardTime" SortField="UnitStandardTime" DataField="UnitStandardTime"
                                    TextAlign="Center" HeaderText="单位标准工时"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="FixedLeadTime" SortField="FixedLeadTime" DataField="FixedLeadTime"
                                    TextAlign="Center" HeaderText="固定提前期"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="VariableLeadTime" SortField="VariableLeadTime" DataField="VariableLeadTime"
                                    TextAlign="Center" HeaderText="变动提前期"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="VariableBatch" SortField="VariableBatch" DataField="VariableBatch"
                                    TextAlign="Center" HeaderText="变动批量"></f:BoundField>
                            </Columns>
                        </f:GroupField>
                        <f:GroupField HeaderText="生产属性" TextAlign="Center">
                            <Columns>
                                <f:BoundField Width="120px" ColumnID="ProcessRouteNO" SortField="ProcessRouteNO" DataField="ProcessRouteNO"
                                    TextAlign="Center" HeaderText="工艺路线编码"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="ProductionVolume" SortField="ProductionVolume" DataField="ProductionVolume"
                                    TextAlign="Center" HeaderText="生产批量"></f:BoundField>
                                <f:BoundField Width="120px" ColumnID="IncreaseAmount" SortField="IncreaseAmount" DataField="IncreaseAmount"
                                    TextAlign="Center" HeaderText="批量增量"></f:BoundField>
                            </Columns>
                        </f:GroupField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="编辑"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
