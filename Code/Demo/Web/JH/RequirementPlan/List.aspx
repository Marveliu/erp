<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JH.RequirementPlan.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />  
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">                 
            <Items>
                <f:Grid ID="gridPlanSource" Title="需求计划" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                    DataKeyNames="ID" AllowSorting="false" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="20" 
                    EnableMultiSelect="false" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                </f:Button>
                                <f:Button ID="btnDelete" Text="删除选中行" OnClick="btnDelete_Click" Icon="Delete" runat="server">
                                </f:Button>
                                <f:ToolbarSeparator ID="toolbarSeparator_01" runat="server"></f:ToolbarSeparator>
                                <f:DatePicker ID="dapStartDate" Label="起始日期" LabelWidth="70px" Width="200px" EnableEdit="false" runat="server"></f:DatePicker>
                                <f:DatePicker ID="dapEndDate" Label="截止日期" LabelWidth="70px" Width="200px" EnableEdit="false" runat="server"></f:DatePicker>
                                <f:Button ID="btnResearch" Text="查询" Icon="Find" OnClick="btnResearch_Click" runat="server"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>

                    <Columns>
                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                            DataWindowTitleField="MaterialName" DataWindowTitleFormatString="编辑 - {0}" />
                            <f:BoundField Width="120px" ColumnID="BillNO" SortField="BillNO" DataField="BillNO"
                                TextAlign="Center" HeaderText="单据编号"></f:BoundField>
                            <f:TemplateField Width="120px" HeaderText="单据类别" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBillType" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("SOURCE_JH",Eval("BillType").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>
                            <f:BoundField Width="120px" ColumnID="MaterialNO" SortField="MaterialNO" DataField="MaterialNO"
                                TextAlign="Center" HeaderText="物料编号"></f:BoundField>
                            <f:BoundField Width="120px" ColumnID="MaterialName" SortField="MaterialName" DataField="MaterialName"
                                TextAlign="Center" HeaderText="物料名称"></f:BoundField>
                            <f:BoundField Width="120px" ColumnID="Unit" SortField="Unit" DataField="Unit"
                                TextAlign="Center" HeaderText="单位"></f:BoundField>
                            <f:BoundField Width="120px" ColumnID="PropertyName" SortField="PropertyName" DataField="PropertyName"
                                TextAlign="Center" HeaderText="属性"></f:BoundField>
                            <f:BoundField Width="120px" ColumnID="PlanAmount" SortField="PlanAmount" DataField="PlanAmount"
                                TextAlign="Center" HeaderText="计划数量"></f:BoundField>
                            <f:BoundField Width="120px" ColumnID="DownAmount" SortField="DownAmount" DataField="DownAmount"
                                TextAlign="Center" HeaderText="拆分数量"></f:BoundField>
                            <f:BoundField Width="120px" ColumnID="EndDate" SortField="EndDate" DataField="EndDate"
                                TextAlign="Center" HeaderText="需求日期"></f:BoundField>
                            <f:TemplateField Width="120px" HeaderText="状态" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("REQUIREMENT_JH",Eval("Status").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                            </f:TemplateField>  
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
