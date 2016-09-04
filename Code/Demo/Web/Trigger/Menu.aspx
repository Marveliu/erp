<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Demo.Web.Trigger.Menu" %>

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
                <f:Grid ID="gridMenu" Title="菜单信息表" ShowBorder="false" AllowPaging="false"
                    ShowHeader="true" DataKeyNames="ID,MenuNO,MenuName" AllowSorting="false" EnableCollapse="false" EnableCheckBoxSelect="true"
                    EnableMultiSelect="false" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnSave" Text="确认" Icon="SystemSave" OnClick="btnSave_Click" runat="server">
                                </f:Button>
                                <f:Button ID="btnClose" Text="关闭" Icon="SystemClose" OnClick="btnClose_Click" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>

                    <Columns>
                        <f:BoundField Width="120px" ColumnID="MenuName" SortField="MenuName" DataField="MenuName" DataSimulateTreeLevelField="MenuNO"
                             DataFormatString="{0}" ExpandUnusedSpace="true" HeaderText="菜单名称">
                        </f:BoundField>
                        <f:ImageField Width="80px" HeaderText="分组" DataImageUrlField="MenuNO" DataImageUrlFormatString="~/Web/Image/16/{0}.png" TextAlign="Center">
                        </f:ImageField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
