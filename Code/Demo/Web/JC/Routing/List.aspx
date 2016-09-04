<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JC.Routing.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
     <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" Layout="VBox" ShowBorder="false" ShowHeader="false">
            <Items>
                <f:Panel ID="panelTop" BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Layout="Fit">
                    <Items>                        
                        <f:Grid ID="gridRouting" Title="工艺路线信息" PageSize="10" ShowBorder="false" AllowPaging="true" 
                            ShowHeader="true" runat="server" Icon="Table" IsDatabasePaging="true" DataKeyNames="ID" AllowSorting="true" 
                            EnableCheckBoxSelect="true" EnableRowSelectEvent="true" OnRowSelect="gridRouting_RowSelect" OnSort="grid_Sort"
                            OnPageIndexChange="grid_PageIndexChange">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_01" runat="server">
                                    <Items>
                                        <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                        </f:Button>
                                        <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" OnClick="btnDelete_Click" runat="server">
                                        </f:Button>  
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:WindowField Width="80px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="Pencil" ToolTip="编辑" 
                                    DataIFrameUrlFormatString="Modify.aspx?ID={0}" DataIFrameUrlFields="ID"
                                    DataWindowTitleField="RoutingName" DataWindowTitleFormatString="编辑 - {0}"/>
                                <f:BoundField Width="120px" SortField="RoutingNO" DataField="RoutingNO" HeaderText="工艺路线编码" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="RoutingName" DataField="RoutingName" HeaderText="工艺路线名称" TextAlign="Center"/>
                                <f:BoundField Width="120px" SortField="ProcedureAmount" DataField="ProcedureAmount" HeaderText="工序数量" TextAlign="Center"/>         
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
                <f:Panel ID="panelBottom" ShowBorder="false" ShowHeader="false" BoxFlex="1" Layout="Fit" runat="server">
                    <Items>                        
                        <f:Grid ID="gridRoutingSub" Title="工序信息" PageSize="10" ShowBorder="false" AllowPaging="true" 
                            ShowHeader="true" runat="server" Icon="Table" IsDatabasePaging="true" DataKeyNames="ID" AllowSorting="true" 
                            EnableCheckBoxSelect="true" EnableMultiSelect="false" OnPageIndexChange="grid_PageIndexChange" OnSort="grid_Sort">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_02" runat="server">
                                    <Items>
                                        <f:Button ID="btnAddSub" Text="新增" Icon="Add" OnClick="btnAddSub_Click" runat="server">
                                        </f:Button>
                                         <f:Button ID="btnDeleteSub" Text="删除选中行" Icon="Delete" OnClick="btnDelete_Click" runat="server">
                                         </f:Button>                                     
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:WindowField Width="80px" TextAlign="Center" WindowID="windowPop" HeaderText="编辑" Icon="Pencil"
                                ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFormatString="..\RoutingSub\Modify.aspx?ID={0}" DataIFrameUrlFields="ID"
                                DataWindowTitleField="ProcedureName" DataWindowTitleFormatString="编辑 - {0}"/>
                                <f:BoundField Width="100px" SortField="RoutingNO" DataField="RoutingNO" TextAlign="Center"
                                    HeaderText="工艺路线编号" />
                                <f:BoundField Width="100px" SortField="ProcedureOrder" DataField="ProcedureOrder" TextAlign="Center"
                                    HeaderText="工序次序" /> 
                                <f:BoundField Width="100px" SortField="ProcedureNO" DataField="ProcedureNO" TextAlign="Center"
                                    HeaderText="工序编码" />
                                <f:BoundField Width="100px" SortField="ProcedureName" DataField="ProcedureName" TextAlign="Center"
                                    HeaderText="工序名称" />                           
                                <f:BoundField Width="100px" SortField="WorkCenter" DataField="WorkCenter" TextAlign="Center"
                                    HeaderText="所属工作中心" />                                  
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="编辑"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
