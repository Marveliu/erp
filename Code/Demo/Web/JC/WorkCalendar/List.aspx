<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JC.WorkCalendar.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工厂日历</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" ShowBorder="false" ShowHeader="false" Layout="VBox" runat="server">
            <Items>
                <f:Panel ID="panelTop" ShowBorder="True" ShowHeader="false" BoxFlex="8" Layout="Fit" runat="server">
                    <Items>
                        <f:Grid ID="gridCalendarRule" Title="日历例外规则" PageSize="6" ShowBorder="false" AllowPaging="true"
                            ShowHeader="true" Icon="Table" IsDatabasePaging="true" AllowSorting="true" runat="server"
                            OnPageIndexChange="grid_PageIndexChange" OnSort="grid_Sort" OnRowCommand="gridCalendarRule_RowCommand">
                            <Toolbars>
                                <f:Toolbar ID="toolbar_01" runat="server">
                                    <Items>
                                        <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server"></f:Button>
                                        <f:Button ID="btnBuildCalendar" Text="生成工作日历" Icon="Build" ConfirmTitle="询问" 
                                            ConfirmText="确定生成工作日历吗？" ConfirmIcon="Question" ConfirmTarget="Top" OnClick="btnBuildCalendar_Click" runat="server"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>

                            <Columns>
                                <f:LinkButtonField Width="60px" TextAlign="Center" HeaderText="删除" Icon="Delete"
                                    CommandName="ActionDel" ConfirmTitle="询问" ConfirmText="确定要删除吗？" ConfirmTarget="Top" ConfirmIcon="Question"/>
                                <f:TemplateField Width="120px" TextAlign="Center" SortField="ExceptionType" HeaderText="例外类型">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExceptionType" runat="server" Text='<%# getExceptionType(Eval("ExceptionType").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:BoundField Width="120px" DataField="ExceptionTime" HeaderText="例外日期" TextAlign="Center" />                     
                            </Columns>
                        </f:Grid>     
                    </Items>
                </f:Panel>
                <f:Panel ID="panelBottom" ShowBorder="True" ShowHeader="true" BoxFlex="9" Layout="Fit" EnableCollapse="true" 
                         Title="工作日历" runat="server">
                    <Content>
                        <iframe id="calendar" style="border:none;width:100%;height:250px;" src="Calendar.aspx" runat="server"></iframe>
                    </Content>
                </f:Panel>        
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="选择" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
