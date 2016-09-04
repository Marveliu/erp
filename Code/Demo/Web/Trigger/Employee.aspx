<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Demo.Web.Trigger.Employee" %>

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
                <f:Grid ID="gridEmployee" Title="员工信息表" ShowBorder="false" AllowPaging="false" ShowHeader="true" IsDatabasePaging="true"
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
                        <f:BoundField Width="120px" ColumnID="EmployeeNO" SortField="EmployeeNO" DataField="EmployeeNO"
                            TextAlign="Center" HeaderText="员工编号"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="EmployeeName" SortField="EmployeeName" DataField="EmployeeName"
                            TextAlign="Center" HeaderText="员工名称"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Age" SortField="Age" DataField="Age"
                            TextAlign="Center" HeaderText="年龄"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Sex" SortField="Sex" DataField="Sex"
                            TextAlign="Center" HeaderText="性别"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="DepartmentNO" EnableColumnHide="false" Hidden="true" DataField="DepartmentNO"
                            TextAlign="Center" HeaderText="部门编号"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="DepartmentName" SortField="DepartmentName" DataField="DepartmentName"
                            TextAlign="Center" HeaderText="部门"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="PositionNO" EnableColumnHide="false" Hidden="true" DataField="PositionNO"
                            TextAlign="Center" HeaderText="职位编号"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="PositionName" SortField="PositionName" DataField="PositionName"
                            TextAlign="Center" HeaderText="职位"></f:BoundField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
