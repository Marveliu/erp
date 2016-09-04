<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listdept.aspx.cs" Inherits="Demo.Web.JC.Deptment.list" %>

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

                            <f:Grid ID="Grid1" EnableCollapse="false" PageSize="5" ShowBorder="true" ShowHeader="false"
                                BoxFlex="1"  AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,DepartmentNO" IsDatabasePaging="true"
                                AllowSorting="true" SortField="DepartmentNO" SortDirection="ASC" >
                                <Columns>
                                    <f:RowNumberField />

                                    <f:BoundField ID="ID" DataField="ID" SortField="ID" DataFormatString="{0}"
                                        HeaderText="ID" />

                                    <f:BoundField ID="DepartmentNO"  DataField="DepartmentNO" SortField="DepartmentNO" DataFormatString="{0}"
                                        HeaderText="部门编号" />

                                    <f:BoundField DataField="DepartmentName" SortField="DepartmentName" DataFormatString="{0}"
                                        HeaderText="部门名称" />
                                </Columns>

                                <Toolbars>
                                    <f:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <f:Button ID="btnExport1" EnableAjax="false" DisableControlBeforePostBack="false"
                                                runat="server" Text="导出Excel" OnClick="btnExport1_Click">
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
                        runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false">

                    </f:Panel>
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
