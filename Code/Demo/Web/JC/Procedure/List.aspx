<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JC.Procedure.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="false" ShowHeader="false">
            <Items>                        
                <f:Grid ID="gridProcedure" Title="工序信息" PageSize="10" ShowBorder="false" AllowPaging="true" 
                        ShowHeader="true" runat="server" Icon="Table" IsDatabasePaging="true" OnSort="grid_Sort" OnPageIndexChange="grid_PageIndexChange"
                        DataKeyNames="ID" AllowSorting="true" EnableCheckBoxSelect="true" EnableMultiSelect="false">
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
                        <f:WindowField ColumnID="Modify" Width="80px" WindowID="windowPop" HeaderText="编辑" Icon="Pencil"
                        ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFormatString="Modify.aspx?ID={0}" DataIFrameUrlFields="ID"
                        DataWindowTitleField="MenuName" DataWindowTitleFormatString="编辑 - {0}"/>
                        <f:BoundField Width="100px" ColumnID="ProcedureNO" SortField="ProcedureNO" DataField="ProcedureNO"
                            HeaderText="工序编码" />
                        <f:BoundField Width="100px" ColumnID="ProcedureName" SortField="ProcedureName" DataField="ProcedureName"
                            HeaderText="工序名称" />
                        <f:BoundField Width="100px" ColumnID="WorkCenter" SortField="WorkCenter" DataField="WorkCenter"
                            HeaderText="所属工作中心" />                                          
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
