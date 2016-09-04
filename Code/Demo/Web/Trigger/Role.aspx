<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="Demo.Web.Trigger.Role" %>

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
                <f:Grid ID="gridRole" Title="角色信息表" ShowBorder="false" AllowPaging="false"
                    ShowHeader="true" DataKeyNames="ID,RoleName" AllowSorting="false" EnableCollapse="false" EnableCheckBoxSelect="true"
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
                        <f:BoundField Width="120px" ColumnID="RoleName" SortField="RoleName" DataField="RoleName"
                             DataFormatString="{0}" ExpandUnusedSpace="true" HeaderText="角色名称">
                        </f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
