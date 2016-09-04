<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.Sys.Role.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .x-grid-row.highlight td {
            background-color: lightgreen;
            background-image: none;
        }

        .x-grid-row-selected.highlight td {
            background-color: yellow;
            background-image: none;
        }
    </style>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" ShowBorder="false" ShowHeader="false" Layout="Fit" runat="server">
            <Items>
                <f:Grid ID="gridRole" Title="角色信息表" PageSize="10" ShowBorder="false" AllowPaging="true" OnPageIndexChange="grid_PageIndexChange"
                    ShowHeader="true" IsDatabasePaging="true" DataKeyNames="ID" SortField="RoleNO" SortDirection="ASC" OnSort="gridRole_Sort"
                    AllowSorting="true" EnableCollapse="true" EnableCheckBoxSelect="true" EnableMultiSelect="false" OnRowDataBound="gridRole_RowDataBound" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnAdd" Text="新增" EnablePostBack="false" Icon="Add" runat="server">
                                </f:Button>

                                <f:ToolbarSeparator ID="toolbarSeparator_01" runat="server"></f:ToolbarSeparator>

                                <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" OnClick="btnDelete_Click" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>

                    <Columns>
                        <f:BoundField Width="120px" ColumnID="RoleID" SortField="RoleNO" DataField="RoleNO" DataFormatString="{0}"
                            HeaderText="角色ID" TextAlign="Center" />

                        <f:BoundField Width="120px" ColumnID="RoleName" SortField="RoleName" DataField="RoleName" DataFormatString="{0}"
                            HeaderText="角色名称" TextAlign="Center" />

                        <f:BoundField Width="120px" ColumnID="ParentID" SortField="ParentID" DataField="ParentID" DataFormatString="{0}"
                            HeaderText="父项角色名称" TextAlign="Center" />

                        <f:BoundField Width="120px" ColumnID="DefaultUrl" SortField="DefaultUrl" DataField="DefaultUrl" DataFormatString="{0}"
                            HeaderText="默认首页地址" TextAlign="Center" />

                        <f:WindowField ColumnID="AuthorizationEdit" Width="80px" TextAlign="Center" WindowID="windowPop" HeaderText="权限设置" Icon="CdEdit"
                            ToolTip="权限设置" DataTextFormatString="{0}" DataIFrameUrlFormatString="..//RoleAuthorization//List.aspx?ID={0}" DataIFrameUrlFields="ID"
                            DataWindowTitleField="RoleName" DataWindowTitleFormatString="权限设置 - {0}" />

                        <f:WindowField ColumnID="Modify" Width="80px" TextAlign="Center" WindowID="windowPop" HeaderText="编辑" Icon="Pencil"
                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFormatString="Modify.aspx?ID={0}&ParentName={1}" DataIFrameUrlFields="ID,ParentName"
                            DataWindowTitleField="RoleName" DataWindowTitleFormatString="编辑 - {0}" />
                    </Columns>
                </f:Grid>
                <f:HiddenField ID="hdfMarkRawNO" runat="server">
                </f:HiddenField>
            </Items>
        </f:Panel>

        <f:Window ID="windowPop" Title="编辑" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
    <script src="../../Js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var highlightRowsClientID = '<%= hdfMarkRawNO.ClientID %>';
        var gridClientID = '<%= gridRole.ClientID %>';

        function highlightRows() {
            // 增加延迟，等待HiddenField更新完毕
            window.setTimeout(function () {
                var highlightRows = F(highlightRowsClientID);
                var grid = F(gridClientID);

                $(grid.el.dom).find('.x-grid-row.highlight').removeClass('highlight');

                $.each(highlightRows.getValue().split(','), function (index, item) {
                    if (item !== '') {
                        var row = grid.getView().getNode(parseInt(item, 10));

                        $(row).addClass('highlight');
                    }
                });
            }, 100);
        }

        // 页面第一个加载完毕后执行的函数
        F.ready(function () {

            var grid = F(gridClientID);

            grid.on('columnhide', function () {
                highlightRows();
            });

            grid.on('columnshow', function () {
                highlightRows();
            });

            grid.getStore().on('refresh', function () {
                highlightRows();
            });

            highlightRows();

        });
    </script>
</body>
</html>
