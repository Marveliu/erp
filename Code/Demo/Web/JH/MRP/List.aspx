<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JH.MRP.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>物料需求计划</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" runat="server" ShowBorder="true" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Panel ID="panelTop" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                    <Items>
                        <f:Grid ID="gridMPS" Title="主生产计划" PageSize="15" ShowBorder="false" AllowPaging="true" DataKeyNames="ID"
                            ShowHeader="true" Icon="Table" IsDatabasePaging="true" OnRowCommand="gridMPS_RowCommand" AllowSorting="false"
                            OnRowSelect="gridMPS_RowSelect" EnableRowSelectEvent="true" runat="server">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_01" runat="server">
                                    <Items>
                                        <f:DatePicker ID="dapStartDate" Label="起始日期" LabelWidth="70px" Width="200px" EnableEdit="false" runat="server"></f:DatePicker>
                                        <f:DatePicker ID="dapEndDate" Label="截止日期" LabelWidth="70px" Width="200px" EnableEdit="false" runat="server"></f:DatePicker>
                                        <f:Button ID="btnResearch" Text="查询" Icon="Find" OnClick="btnResearch_Click" runat="server">
                                        </f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>

                            <Columns>
                                <f:LinkButtonField HeaderText="分解" ConfirmTitle="提醒" TextAlign="Center" ConfirmText="确认分解？" Icon="Add"
                                    ConfirmTarget="Top" ColumnID="Assign " Width="50px" CommandName="ActionAssign" />
                                <f:BoundField Width="120px" SortField="PlanNO" DataField="PlanNO" HeaderText="计划编号"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="PlannedSourceNO" DataField="PlannedSourceNO" HeaderText="来源单据编号"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="MaterialNO" DataField="MaterialNO" HeaderText="物料编号" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="MaterialName" DataField="MaterialName" HeaderText="物料名称" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="EndDate" DataField="EndDate" HeaderText="结束日期"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="PlanAmount" DataField="PlanAmount" HeaderText="计划数量"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="ResolveAmount" DataField="ResolveAmount" HeaderText="已分解数量"  TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="Unit" DataField="Unit" HeaderText="单位"  TextAlign="Center"/>
                                <f:TemplateField Width="120px" HeaderText="状态" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("MPS_JH",Eval("Status").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>                        
                            </Columns>
                        </f:Grid>     
                    </Items>
                </f:Panel>

                <f:Panel ID="panelBottom" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                    <Items>
                        <f:Grid ID="gridMRP" Title="物料需求计划" PageSize="15" ShowBorder="false" AllowPaging="true"
                            ShowHeader="true" Icon="Table" IsDatabasePaging="true" DataKeyNames="ID" AllowSorting="true" runat="server">
                            <Columns>
                                <f:LinkButtonField HeaderText="删除" Hidden="true" ConfirmTitle="警告" TextAlign="Center" ConfirmText="确定要删除吗？" Icon="Delete"
                                    ConfirmTarget="Top" Width="50px" CommandName="ActionDel" />
                                <f:BoundField Width="180px" SortField="PlanNO" DataField="PlanNO" HeaderText="计划编号"  TextAlign="Center"/>
                                <f:BoundField Width="180px" SortField="MPSNO" DataField="MPSNO" HeaderText="主生产计划编号"  TextAlign="Center"/>
                                <f:BoundField Width="180px" SortField="MaterialNO" DataField="MaterialNO" HeaderText="物料编号" TextAlign="Center"/>
                                <f:BoundField Width="180px" SortField="MaterialName" DataField="MaterialName" HeaderText="物料名称" TextAlign="Center"/>
                                <f:BoundField Width="180px" SortField="NeedAmount" DataField="NeedAmount" HeaderText="需求数量"  TextAlign="Center"/>
                                <f:BoundField Width="180px" SortField="Unit" DataField="Unit" HeaderText="单位"  TextAlign="Center"/>
                                <f:BoundField Width="180px" SortField="NeedDate" DataField="NeedDate" HeaderText="需求日期"  TextAlign="Center"/>
                                <f:TemplateField Width="180px" HeaderText="状态" TextAlign="Center" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("MRP_JH",Eval("Status").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                            </f:TemplateField>  
                            </Columns>   
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>

        <f:Window ID="windowPop" Title="编辑" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
                EnableResize="false" EnableClose="false" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
