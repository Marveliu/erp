<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="Demo.Web.JC.Deptment.list1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />
            <f:Panel ID="Panel1" runat="server" ShowBorder="True" EnableCollapse="true"
                Layout="HBox" AutoScroll="true" BodyPadding="5"
                ShowHeader="True" Title="部门信息">
                <Items>

                    <f:Panel ID="Panel2" Title="部门" BoxFlex="1" runat="server" Margin="0 5 0 0"
                        BodyPadding="5px" ShowBorder="true" ShowHeader="True" Layout="VBox">
                        <Items>


                            <f:Grid ID="Grid1" Title="表格" EnableCollapse="true" PageSize="5" ShowBorder="true" ShowHeader="false"
                                AllowPaging="true" runat="server" EnableCheckBoxSelect="True" Width="800px" Height="240px" OnRowDoubleClick="Grid1_RowDoubleClick"
                                DataKeyNames="ID,DepartmentNO" OnPageIndexChange="Grid1_PageIndexChange" IsDatabasePaging="true" EnableRowDoubleClickEvent="true">
                                <Columns>
                                    <f:RowNumberField />

                                    <f:BoundField ID="ID" DataField="ID" SortField="ID" DataFormatString="{0}"
                                        HeaderText="ID" />

                                    <f:BoundField ID="DepartmentNO" DataField="DepartmentNO" SortField="DepartmentNO" DataFormatString="{0}"
                                        HeaderText="部门编号" />

                                    <f:BoundField DataField="DepartmentName" SortField="DepartmentName" DataFormatString="{0}"
                                        HeaderText="部门名称" />
                                </Columns>
                                <PageItems>
                                    <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                    </f:ToolbarSeparator>
                                    <f:ToolbarText runat="server" Text="每页记录数：">
                                    </f:ToolbarText>
                                    <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                        <f:ListItem Text="5" Value="5" />
                                        <f:ListItem Text="10" Value="10" />
                                        <f:ListItem Text="15" Value="15" />
                                        <f:ListItem Text="20" Value="20" />
                                    </f:DropDownList>
                                </PageItems>
                                <Toolbars>
                                    <f:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <f:Button ID="btnInsert1" EnableAjax="false" Text="增加数据" Icon="Add" runat="server" OnClick="btnInsert1_Click">
                                            </f:Button>
                                            <f:Button ID="btnEdit1" EnableAjax="false" Text="编辑数据" Icon="PageEdit" runat="server" OnClick="btnEdit1_Click">
                                            </f:Button>
                                            <f:Button ID="btnDelete1" Text="删除选中行" Icon="Delete" EnableAjax="false" OnClick="btnDelete1_Click" runat="server">
                                            </f:Button>


                                            <f:Button ID="btnExport1" EnableAjax="false" DisableControlBeforePostBack="false" runat="server" Text="导出Excel" OnClick="btnExport1_Click">
                                            </f:Button>
                                            <f:TwinTriggerBox runat="server" EmptyText="搜索部门名称" ShowLabel="false" ID="ttbSearch1"
                                                ShowTrigger1="false" OnTrigger1Click="ttbSearch1_Trigger1Click" OnTrigger2Click="ttbSearch1_Trigger2Click"
                                                Trigger1Icon="Clear" Trigger2Icon="Search">
                                            </f:TwinTriggerBox>
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                            </f:Grid>

                        </Items>
                    </f:Panel>
                    <f:Panel ID="Panel3" Title="职位" BoxFlex="1"
                        runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true">
                        <Items>

                            <f:Grid ID="Grid2" Title="表格" EnableCollapse="true" PageSize="5" ShowBorder="true" ShowHeader="false"
                                AllowPaging="true" runat="server" EnableCheckBoxSelect="True" Width="800px" Height="240px" OnRowDoubleClick="Grid2_RowDoubleClick"
                                DataKeyNames="ID,PositionNO" OnPageIndexChange="Grid2_PageIndexChange" IsDatabasePaging="true" EnableRowDoubleClickEvent="true">
                                <Columns>
                                    <f:RowNumberField />
                                    <f:BoundField DataField="ID" SortField="ID" DataFormatString="{0}"
                                        HeaderText="ID" />
                                    <f:BoundField DataField="PositionNO" SortField="PositionNO" DataFormatString="{0}"
                                        HeaderText="职位编号" />

                                    <f:BoundField DataField="PositionName" SortField="PositionName" DataFormatString="{0}"
                                        HeaderText="职位名称" />

                                    <f:BoundField DataField="PositionNO" SortField="PositionNO" DataFormatString="{0}"
                                        HeaderText="所属部门" />
                                </Columns>
                                <PageItems>
                                    <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                    </f:ToolbarSeparator>
                                    <f:ToolbarText runat="server" Text="每页记录数：">
                                    </f:ToolbarText>
                                    <f:DropDownList runat="server" ID="ddlPageSize2" Width="80px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPageSize2_SelectedIndexChanged">
                                        <f:ListItem Text="5" Value="5" />
                                        <f:ListItem Text="10" Value="10" />
                                        <f:ListItem Text="15" Value="15" />
                                        <f:ListItem Text="20" Value="20" />
                                    </f:DropDownList>
                                </PageItems>
                                <Toolbars>
                                    <f:Toolbar ID="Toolbar2" runat="server">
                                        <Items>
                                            <f:Button ID="btnInsert2" EnableAjax="false" Text="增加数据" Icon="Add" runat="server" OnClick="btnInsert2_Click">
                                            </f:Button>
                                            <f:Button ID="btnEdit2" EnableAjax="false" Text="编辑数据" Icon="PageEdit" runat="server" OnClick="btnEdit2_Click">
                                            </f:Button>
                                            <f:Button ID="btnDelete2" Text="删除选中行" Icon="Delete" EnableAjax="false" OnClick="btnDelete2_Click" runat="server">
                                            </f:Button>

                                            <f:Button ID="btmImport2" EnableAjax="false" DisableControlBeforePostBack="false" runat="server" Text="导出Excel" OnClick="btmImport2_Click">
                                            </f:Button>
                                            <f:TwinTriggerBox runat="server" EmptyText="搜索职位名称" ShowLabel="false" ID="ttbSearch2"
                                                ShowTrigger1="false" OnTrigger1Click="ttbSearch2_Trigger1Click" OnTrigger2Click="ttbSearch2_Trigger2Click"
                                                Trigger1Icon="Clear" Trigger2Icon="Search">
                                            </f:TwinTriggerBox>
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                            </f:Grid>

                        </Items>
                    </f:Panel>
                </Items>
            </f:Panel>

            <f:Panel ID="Panel4" runat="server" Height="450px" ShowBorder="True" EnableCollapse="true"
                Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" BodyPadding="5px" ShowHeader="True" Title="员工信息">
                <Items>
                    <f:Grid ID="Grid3" Title="员工" EnableCollapse="true" PageSize="5" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" EnableCheckBoxSelect="True" Width="800px" Height="400px" OnRowDoubleClick="Grid3_RowDoubleClick"
                        DataKeyNames="ID,EmployeeNO" OnPageIndexChange="Grid3_PageIndexChange" IsDatabasePaging="true" EnableRowDoubleClickEvent="true">
                        <Columns>
                            <f:RowNumberField />

                            <f:BoundField DataField="ID" SortField="ID" DataFormatString="{0}"
                                HeaderText="ID" />

                            <f:BoundField DataField="EmployeeNO" SortField="EmployeeNO" DataFormatString="{0}"
                                HeaderText="员工编号" />

                            <f:BoundField DataField="EmployeeName" SortField="EmployeeName" DataFormatString="{0}"
                                HeaderText="员工名称" />


                            <f:BoundField DataField="DepartmentNO" SortField="DepartmentNO" DataFormatString="{0}"
                                HeaderText="所在部门" />

                            <f:BoundField DataField="PositionNO" SortField="PositionNO" DataFormatString="{0}"
                                HeaderText="所任职位" />

                            <f:BoundField DataField="Age" SortField="Age" DataFormatString="{0}"
                                HeaderText="年龄" />

                            <f:BoundField DataField="Sex" SortField="Sex" DataFormatString="{0}"
                                HeaderText="性别" />

                            <f:BoundField DataField="MobileNumber" SortField="MobileNumber" DataFormatString="{0}"
                                HeaderText="联系电话" />

                            <f:BoundField DataField="Email" SortField="Email" DataFormatString="{0}"
                                HeaderText="电子邮箱" />
                            <f:BoundField DataField="Nation" SortField="Nation" DataFormatString="{0}"
                                HeaderText="国籍" />

                            <f:BoundField DataField="NativePlace" SortField="NativePlace" DataFormatString="{0}"
                                HeaderText="籍贯" />

                            <f:BoundField DataField="PoliticalStatus" SortField="PoliticalStatus" DataFormatString="{0}"
                                HeaderText="政治身份" />
                            <f:BoundField DataField="MaritialStatus" SortField="MaritialStatus" DataFormatString="{0}"
                                HeaderText="婚姻状况" />

                            <f:BoundField DataField="EntryDate" SortField="EntryDate" DataFormatString="{0}"
                                HeaderText="入职时间" />

                            <f:BoundField DataField="LeaveDate" SortField="LeaveDate" DataFormatString="{0}"
                                HeaderText="离职时间" />


                        </Columns>
                        <PageItems>
                            <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </f:ToolbarSeparator>
                            <f:ToolbarText runat="server" Text="每页记录数：">
                            </f:ToolbarText>
                            <f:DropDownList runat="server" ID="ddlPageSize3" Width="80px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlPageSize3_SelectedIndexChanged">
                                <f:ListItem Text="5" Value="5" />
                                <f:ListItem Text="10" Value="10" />
                                <f:ListItem Text="15" Value="15" />
                                <f:ListItem Text="20" Value="20" />
                            </f:DropDownList>
                        </PageItems>
                        <Toolbars>
                            <f:Toolbar ID="Toolbar3" runat="server">
                                <Items>
                                    <f:Button ID="btnInsert3" EnableAjax="false" Text="增加数据" Icon="Add" runat="server" OnClick="btnInsert3_Click">
                                    </f:Button>
                                    <f:Button ID="btnEdit3" EnableAjax="false" Text="编辑数据" Icon="PageEdit" runat="server" OnClick="btnEdit3_Click">
                                    </f:Button>
                                    <f:Button ID="btnDelete3" Text="删除选中行" Icon="Delete" EnableAjax="false" OnClick="btnDelete3_Click" runat="server">
                                    </f:Button>

                                    <f:Button ID="btmImport3" EnableAjax="false" DisableControlBeforePostBack="false" runat="server" Text="导出Excel" OnClick="btmImport3_Click">
                                    </f:Button>
                                    <f:TwinTriggerBox runat="server" EmptyText="搜索职位名称" ShowLabel="false" ID="ttbSearch3"
                                        ShowTrigger1="false" OnTrigger1Click="ttbSearch3_Trigger1Click" OnTrigger2Click="ttbSearch3_Trigger2Click"
                                        Trigger1Icon="Clear" Trigger2Icon="Search">
                                    </f:TwinTriggerBox>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>
                    </f:Grid>

                </Items>
            </f:Panel>


            <f:Window ID="Window1" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
                CloseAction="HidePostBack"
                EnableMaximize="true" EnableResize="true" OnClose="Window1_Close" Target="Top"
                IsModal="True" Width="850px" Height="450px">
            </f:Window>



        </div>
    </form>
</body>
</html>

