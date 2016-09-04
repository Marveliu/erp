<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JH.AssignPlan.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="true" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Panel ID="panelTop" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                    <Items>
                        <f:Grid ID="gridSource" Title="需求计划" PageSize="15" ShowBorder="false" AllowPaging="true"
                            ShowHeader="true" Icon="Table" IsDatabasePaging="true" AllowSorting="false" EnableRowSelectEvent="true"
                            DataKeyNames="ID" OnRowCommand="gridSource_RowCommand" OnRowSelect="gridSource_RowSelect" runat="server">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_01" runat="server">
                                    <Items>
                                        <f:DropDownList ID="ddlBillType" Label="单据类别" LabelWidth="70px" Width="200px" runat="server">
                                            <f:ListItem Text="全部" Value="A" Selected="true"/>
                                            <f:ListItem Text="销售订单" Value="S" />
                                            <f:ListItem Text="预测单" Value="F" />
                                            <f:ListItem Text="紧急订单" Value="R" />
                                        </f:DropDownList>
                                        <f:DatePicker ID="dapStartDate" Label="起始日期" LabelWidth="70px" Width="200px" EnableEdit="false" runat="server"></f:DatePicker>
                                        <f:DatePicker ID="dapEndDate" Label="截止日期" LabelWidth="70px" Width="200px" EnableEdit="false" runat="server"></f:DatePicker>
                                        <f:Button ID="btnResearch" Text="查询" Icon="Find" OnClick="btnResearch_Click" runat="server">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>

                            <Columns>
                                <f:LinkButtonField HeaderText="下达" ConfirmTitle="提醒" TextAlign="Center" ConfirmText="确认下达？" Icon="Add"
                                    ConfirmTarget="Top" ColumnID="Assign" Width="80px" CommandName="ActionAssign" />
                                <f:BoundField Width="120px" ColumnID="BillNO" DataField="BillNO"
                                    HeaderText="单据编号"  TextAlign="Center" />
                                <f:TemplateField Width="120px" HeaderText="单据类别" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBillType" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("SOURCE_JH",Eval("BillType").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:BoundField Width="120px" ColumnID="MaterialNO" DataField="MaterialNO"
                                    HeaderText="物料编号" TextAlign="Center"/>
                                <f:BoundField Width="120px" ColumnID="MaterialName" DataField="MaterialName"
                                    HeaderText="物料名称" TextAlign="Center"/>
                                <f:BoundField Width="120px" ColumnID="EndDate" DataField="EndDate"
                                    HeaderText="需求日期" TextAlign="Center"/>    
                                <f:BoundField Width="120px" ColumnID="PlanAmount" DataField="PlanAmount"
                                    HeaderText="计划数量" TextAlign="Center"/>
                                <f:BoundField Width="120px" ColumnID="DownAmount" DataField="DownAmount"
                                    HeaderText="已拆分数量" TextAlign="Center"/>
                                <f:BoundField Width="120px" ColumnID="Unit" DataField="Unit"
                                    HeaderText="单位" TextAlign="Center"/>
                                <f:TemplateField Width="120px" HeaderText="状态" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("REQUIREMENT_JH",Eval("Status").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>                         
                            </Columns>
                        </f:Grid>     
                    </Items>
                </f:Panel>

                <f:Panel ID="panelBottom" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                    <Items>
                        <f:Grid ID="gridTask" Title="任务计划单" PageSize="15" ShowBorder="false" AllowPaging="true"
                            ShowHeader="true" Icon="Table" IsDatabasePaging="true" DataKeyNames="ID" AllowSorting="false"
                            runat="server">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_02" runat="server">
                                    <Items>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:BoundField Width="120px" SortField="BillNO" DataField="BillNO"
                                    HeaderText="单据编号"  TextAlign="Center"/>
                                <f:TemplateField Width="120px" HeaderText="单据类别" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBillType_" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("BILL",Eval("BillType").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:BoundField Width="120px" SortField="SourceNO" DataField="SourceNO"
                                    HeaderText="需求计划单编号"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="MaterialNO" DataField="MaterialNO"
                                    HeaderText="物料编号" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="MaterialName" DataField="MaterialName"
                                    HeaderText="物料名称" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="Date" DataField="Date"
                                    HeaderText="日期"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="Amount" DataField="Amount"
                                    HeaderText="数量"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="ExecutedAmount" DataField="ExecutedAmount"
                                    HeaderText="已执行数量"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="Unit" DataField="Unit"
                                    HeaderText="单位"  TextAlign="Center"/>
                                <f:TemplateField Width="120px" HeaderText="状态" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("TASK_JH",Eval("Status").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>                   
                            </Columns>   
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
