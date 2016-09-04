<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Material.aspx.cs" Inherits="Demo.Web.Trigger.Material" %>

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
                <f:Grid ID="gridMaterial" Title="物料信息表" ShowBorder="false" AllowPaging="false" ShowHeader="true" IsDatabasePaging="true"
                    DataKeyNames="ID" AllowSorting="false" EnableCollapse="false" EnableCheckBoxSelect="true"
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
                        <f:BoundField Width="120px" ColumnID="MaterialNO" SortField="MaterialNO" DataField="MaterialNO"
                            TextAlign="Center" HeaderText="物料编号"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="MaterialName" SortField="MaterialName" DataField="MaterialName"
                            TextAlign="Center" HeaderText="物料名称"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Specification" SortField="Specification" DataField="Specification"
                            TextAlign="Center" HeaderText="规格"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Model" SortField="Model" DataField="Model"
                            TextAlign="Center" HeaderText="型号"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Unit" SortField="Unit" DataField="Unit"
                            TextAlign="Center" HeaderText="单位"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Property" SortField="Property" DataField="Property"
                            TextAlign="Center" HeaderText="属性"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
