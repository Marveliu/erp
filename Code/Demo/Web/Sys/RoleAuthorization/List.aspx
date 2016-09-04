<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.Sys.RoleAuthorization.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server"></f:PageManager>
        <f:Panel ID="panelMain" ShowBorder="false" ShowHeader="false" AutoScroll="true" Layout="Fit" runat="server">
            <Items>
                <f:Grid ID="gridAuthorization" Title="角色权限表" ShowBorder="false" AllowPaging="false" EnableHeaderMenu="true"
                    ShowHeader="true" DataKeyNames="MenuID,RoleMenuID,MenuNO,ParentID" AllowSorting="false" EnableCollapse="false" runat="server" OnRowCommand="gridAuthorization_RowCommand">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:Button ID="btnSave" Text="保存" Icon="SystemSave" OnClick="btnSave_Click" Hidden="true" runat="server">
                                </f:Button>
                                <f:Button ID="btnBack" Text="返回" Icon="PageCancel" OnClick="btnBack_Click" Hidden="true" runat="server">
                                </f:Button>
                                <f:Button ID="btnEdit" Text="编辑" Icon="BookEdit" OnClick="btnEdit_Click" Hidden="false" runat="server">
                                </f:Button>
                                <f:Button ID="btnClose" Text="关闭" Icon="SystemClose" OnClick="btnClose_Click" Hidden="false" runat="server">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>

                    <Columns>
                        <f:BoundField Width="120px" ColumnID="MenuName" SortField="MenuName" DataField="MenuName" DataSimulateTreeLevelField="MenuNO"
                             DataFormatString="{0}" ExpandUnusedSpace="true" HeaderText="菜单名称">
                        </f:BoundField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationSelect_1" DataField="AuthorizationSelect" RenderAsStaticField="false" AutoPostBack="true"
                             CommandName="CheckBoxSelect" HeaderText="访问权限" TextAlign="Center" Hidden="true" EnableColumnHide="false">
                        </f:CheckBoxField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationInsert_1" DataField="AuthorizationInsert" RenderAsStaticField="false" AutoPostBack="true"
                             CommandName="CheckBoxOther" HeaderText="新增权限" TextAlign="Center" Hidden="true" EnableColumnHide="false">
                        </f:CheckBoxField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationUpdate_1" DataField="AuthorizationUpdate" RenderAsStaticField="false" AutoPostBack="true"
                             CommandName="CheckBoxOther" HeaderText="修改权限" TextAlign="Center" Hidden="true" EnableColumnHide="false">
                        </f:CheckBoxField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationDelete_1" DataField="AuthorizationDelete" RenderAsStaticField="false" AutoPostBack="true"
                             CommandName="CheckBoxOther" HeaderText="删除权限" TextAlign="Center" Hidden="true" EnableColumnHide="false">
                        </f:CheckBoxField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationSelect_2" RenderAsStaticField="true" DataField="AuthorizationSelect" HeaderText="访问权限"
                            TextAlign="Center" Hidden="false" EnableColumnHide="false">
                        </f:CheckBoxField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationInsert_2" RenderAsStaticField="true" DataField="AuthorizationInsert" HeaderText="新增权限"
                            TextAlign="Center" Hidden="false" EnableColumnHide="false">
                        </f:CheckBoxField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationUpdate_2" RenderAsStaticField="true" DataField="AuthorizationUpdate" HeaderText="修改权限"
                            TextAlign="Center" Hidden="false" EnableColumnHide="false">
                        </f:CheckBoxField>

                        <f:CheckBoxField Width="80px" ColumnID="AuthorizationDelete_2" RenderAsStaticField="true" DataField="AuthorizationDelete" HeaderText="删除权限"
                            TextAlign="Center" Hidden="false" EnableColumnHide="false">
                        </f:CheckBoxField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
