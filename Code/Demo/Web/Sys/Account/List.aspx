<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.Sys.Account.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
            <f:Panel ID="panelMain" ShowBorder="false" ShowHeader="false" Layout="Fit" runat="server">
                <Items>
                    <f:Grid ID="gridAccount" Title="账户信息表" PageSize="10" ShowBorder="false" AllowPaging="true" OnPageIndexChange="grid_PageIndexChange"
                        ShowHeader="true" IsDatabasePaging="true" DataKeyNames="ID" SortField="AccountName" SortDirection="ASC" OnSort="gridAccount_Sort"
                        AllowSorting="true" EnableCollapse="true" EnableCheckBoxSelect="true" EnableMultiSelect="false" runat="server">
                        <Toolbars>
                            <f:Toolbar ID="toolbar_01" runat="server">
                                <Items>
                                    <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" OnClick="btnDelete_Click" runat="server">
                                    </f:Button>

<%--                                    <f:ToolbarSeparator ID="toolbarSeparator_01" runat="server"></f:ToolbarSeparator>
                                    
                                    <f:Button ID="btnQuery" Text="筛选" Icon="Zoom" runat="server">
                                    </f:Button>
                                    
                                    <f:ToolbarSeparator ID="toolbarSeparator_03" runat="server"></f:ToolbarSeparator>
                                    
                                    <f:Button ID="btnClearCondition" Text="取消筛选" Icon="Decline" OnClick="btnClearCondition_Click" runat="server">
                                    </f:Button>  --%>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>

                        <Columns>
                            <f:BoundField Width="120px" ColumnID="AccountName" SortField="AccountName" DataField="AccountName" DataFormatString="{0}"
                                HeaderText="账户名称" TextAlign="Center"/>

                            <f:BoundField Width="120px" ColumnID="Password" SortField="Password" DataField="Password" DataFormatString="{0}"
                                HeaderText="密码" TextAlign="Center"/>

                            <f:BoundField Width="120px" ColumnID="RoleID" SortField="RoleID" DataField="RoleID" DataFormatString="{0}"
                                HeaderText="角色ID" TextAlign="Center"/>
                            
                            <f:TemplateField Width="120px" HeaderText="角色名称">
                                <ItemTemplate>
                                    <asp:Label ID="lblRoleName" runat="server" Text='<%# getRoleName(Eval("RoleID").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </f:TemplateField>
                            
                            <f:WindowField ColumnID="Modify" Width="80px" WindowID="windowPop" HeaderText="编辑" Icon="Pencil"
                                ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFormatString="Modify.aspx?ID={0}" DataIFrameUrlFields="ID"
                                DataWindowTitleField="AccountName" DataWindowTitleFormatString="编辑 - {0}"/>                          
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Panel>
            <f:Window ID="windowPop" Title="编辑" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
                EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
            </f:Window>
    </form>
</body>
</html>
