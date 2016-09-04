<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listdeptadd.aspx.cs" Inherits="Demo.Web.JC.Deptment.listdeptadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="_form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="10px" runat="server">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveRefresh" Text="保存" runat="server" Icon="SystemSave"
                            OnClick="btnSaveRefresh_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>

                    <Items>
                        <f:TextBox runat="server" ID="DepartmentNO" Label="部门编号" EmptyText="" AutoPostBack="true" ></f:TextBox>
                    </Items>
                
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="DepartmentName" Label="部门名称" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
