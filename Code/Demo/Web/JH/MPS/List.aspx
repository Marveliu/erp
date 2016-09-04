<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JH.MPS.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>主生产计划</title>
</head>
<body>
    <form id="form_01" runat="server">
     <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="true" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Panel ID="panelTop" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                    <Items>
                        <f:Grid ID="gridSource" Title="需求计划" PageSize="15" ShowBorder="false" AllowPaging="true" OnPageIndexChange="grid_PageIndexChange"
                            ShowHeader="true" Icon="Table" IsDatabasePaging="true" AllowSorting="false" EnableRowSelectEvent="true"
                            OnRowSelect="gridSource_RowSelect" OnRowCommand="gridMPS_RowCommand" DataKeyNames="ID" runat="server">
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
                                <f:LinkButtonField HeaderText="拆分" ConfirmTitle="提醒" TextAlign="Center" ConfirmText="确认拆分？" Icon="Add"
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
                        <f:Grid ID="gridMPS" Title="主生产计划" PageSize="15" ShowBorder="false" AllowPaging="true" OnPageIndexChange="grid_PageIndexChange"
                            ShowHeader="true" Icon="Table" IsDatabasePaging="true" DataKeyNames="ID" AllowSorting="true" OnSort="grid_Sort" 
                            OnRowCommand="gridMPS_RowCommand" runat="server">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_02" runat="server">
                                    <Items>
                                        <f:Button ID="btnAdd" Text="新增" Icon="Add" Hidden="true" OnClick="btnAdd_Click" runat="server">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:WindowField Width="80px" TextAlign="Center" WindowID="windowPop" HeaderText="编辑" Icon="Pencil"
                                    ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFormatString="Modify.aspx?ID={0}" DataIFrameUrlFields="ID"
                                    DataWindowTitleField="MaterialName" DataWindowTitleFormatString="编辑 - {0}"/>        
                                <f:LinkButtonField HeaderText="删除" Hidden="true" ConfirmTitle="警告" TextAlign="Center" ConfirmText="确定要删除吗？" Icon="Delete"
                                    ConfirmTarget="Top" Width="80px" CommandName="ActionDel" />
                                <f:BoundField Width="120px" SortField="PlanNO" DataField="PlanNO"
                                    HeaderText="计划编号"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="PlannedSourceNO" DataField="PlannedSourceNO"
                                    HeaderText="来源单据编号"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="MaterialNO" DataField="MaterialNO"
                                    HeaderText="物料编号" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="MaterialName" DataField="MaterialName"
                                    HeaderText="物料名称" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="EndDate" DataField="EndDate"
                                    HeaderText="结束日期"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="PlanAmount" DataField="PlanAmount"
                                    HeaderText="计划数量"  TextAlign="Center"/>
                                    <f:BoundField Width="120px" SortField="ResolveAmount" DataField="ResolveAmount"
                                    HeaderText="已分解数量"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="Unit" DataField="Unit"
                                    HeaderText="单位"  TextAlign="Center"/>
                                <f:TemplateField Width="120px" HeaderText="状态" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("MPS_JH",Eval("Status").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>                   
                            </Columns>   
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>

        <f:Window ID="windowPop" Title="编辑" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
                EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
