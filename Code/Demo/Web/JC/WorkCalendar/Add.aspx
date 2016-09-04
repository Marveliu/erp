<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Demo.Web.JC.WorkCalendar.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工厂日历设置</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pagemanager_01" AutoSizePanelID="panel_01" runat="server"></f:PageManager>

        <f:Panel ID="panel_01" Layout="Fit" ShowBorder="False" ShowHeader="false" runat="server">
            <Items>
                <f:Form ID="formInfo" ShowBorder="true" LabelAlign="Left" ShowHeader="false" EnableCollapse="false" Expanded="true" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnSave" Text="保存" ValidateForms="formInfo" Icon="SystemSave" OnClick="btnSave_Click" runat="server">
                                </f:Button>
                                <f:Button ID="btnClose" Text="关闭" Icon="SystemClose" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                   <Rows>
                        <f:FormRow>
                            <Items>
                                <f:DropDownList ID="ddlExceptionType" Label="例外类型" AutoPostBack="true"  Required="true"
                                    OnSelectedIndexChanged="ddlExceptionType_SelectedIndexChanged" runat="server">
                                    <f:ListItem Text="--请选择--" Value="C" Selected="true" />
                                    <f:ListItem Text="按星期" Value="W" />
                                    <f:ListItem Text="按日期" Value="D" />
                                    <f:ListItem Text="按月份" Value="M" />
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:DropDownList ID="ddlWeek" Label="星期" Hidden="true" runat="server"></f:DropDownList>

                                <f:NumberBox ID="nbxMonth" Label="月" MinValue="1" MaxValue="12" Hidden="true" runat="server">
                                </f:NumberBox>

                                <f:NumberBox ID="nbxDay" Label="日" Hidden="true" MinValue="1" runat="server"></f:NumberBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
