<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listpositionadd.aspx.cs" Inherits="Demo.Web.JC.Deptment.add" %>

<!DOCTYPE html>
<html>
<head runat="server">
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
                        <f:TextBox runat="server" ID="positionnno" Label="职位编号" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="positionname" Label="职位名称" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:DropDownList runat="server" ID="DropDownList1" Label="所属部门">
                        </f:DropDownList>
                        <f:Button ID="btnGetSelection" Text="查看部门编号" runat="server" OnClick="btnGetSelection_Click">
                        </f:Button>
                        <f:Label runat="server" ID="labResult">
                        </f:Label>
                    </Items>
                </f:FormRow>
            </Rows>

        </f:Form>






    </form>
</body>
</html>
