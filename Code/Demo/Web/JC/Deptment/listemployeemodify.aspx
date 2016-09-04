<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listemployeemodify.aspx.cs" Inherits="Demo.Web.JC.Deptment.listemployeemodify" %>

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
                        <f:TextBox runat="server" ID="emid" Label="ID" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="employeeno" Label="员工编号" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                    <Items>
                        <f:TextBox runat="server" ID="employeename" Label="员工名称" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:DropDownList ID="DropDownList1" Label="部门" ShowRedStar="true" CompareType="String"
                            CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择部门！" runat="server"
                            AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </f:DropDownList>
                    </Items>
                    <Items>
                        <f:DropDownList ID="DropDownList2" Label="职位" ShowRedStar="true" CompareType="String"
                            CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择职位！" runat="server" Enabled="false"
                            AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        </f:DropDownList>

                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="age" Label="年龄" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                    <Items>
                        <f:DropDownList runat="server" ID="sex" Label="性别">
                            <f:ListItem Text="男" Value="1" Selected="true" />
                            <f:ListItem Text="女" Value="2" />
                        </f:DropDownList>
                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="phone" Label="联系电话" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                    <Items>
                        <f:TextBox runat="server" ID="email" Label="电子邮箱" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="nation" Label="国籍" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                    <Items>
                        <f:TextBox runat="server" ID="nativeplace" Label="籍贯" EmptyText="" AutoPostBack="true"></f:TextBox>
                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>

                         <f:DropDownList runat="server" ID="politicalstatus" Label="政治身份">

                            <f:ListItem Text="群众" Value="1"  />
                            <f:ListItem Text="预备党员" Value="2" Selected ="true"/>
                            <f:ListItem Text="党员" Value="2" />
                        </f:DropDownList>

                    </Items>

                    <Items>


                        <f:DropDownList runat="server" ID="Maritialstatus" Label="婚姻状况">
                            <f:ListItem Text="已婚" Value="1"  />
                            <f:ListItem Text="未婚" Value="2" Selected ="true"/>
                            <f:ListItem Text="离婚" Value="2" />
                        </f:DropDownList>

                    </Items>
                </f:FormRow>

                <f:FormRow>
                    <Items>
                        <f:DatePicker runat="server" Required="true" AutoPostBack="true" OnTextChanged="entrydate_TextChanged"
                            Label="入职时间" EmptyText="请选择开始日期" ID="entrydate" ShowRedStar="True">
                        </f:DatePicker>
                    </Items>
                    <Items>
                        <f:DatePicker ID="leavedate" Required="true" Readonly="false" CompareControl="entrydate"
                            DateFormatString="yyyy-MM-dd" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期"
                            Label="离职时间" runat="server" ShowRedStar="True">
                        </f:DatePicker>
                    </Items>
                </f:FormRow>
            </Rows>

        </f:Form>

    </form>
</body>
</html>
