<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Demo.Web.JC.BOMSub.Modify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01"  AutoSizePanelID="panelMain" runat="server" />

        <f:Panel ID="panelMain" runat="server" Layout="Fit" ShowBorder="False" AutoScroll="true" ShowHeader="false">
            <Toolbars>
                <f:Toolbar ID="toolbar_01" runat="server">
                    <Items>
                        <f:Button ID="btnClose" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="formInfo" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="formInfo" ShowBorder="true" LabelAlign="Left" ShowHeader="false" runat="server"
                    EnableCollapse="false" Expanded="true" LabelWidth="80px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbMaterialNO" Width="250px" Label="物料名称" Readonly="true" runat="server" >
                                </f:TextBox>                                           
                                <f:TextBox ID="txbMaterialName" Width="250px" Label="物料名称" Readonly="true" runat="server" >
                                </f:TextBox>                                      
                                <f:TextBox ID="txbPropertyName" Width="250px" Label="属性" Readonly="true" runat="server" >
                                </f:TextBox>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbUnit" Width="250px" Label="单位" Readonly="true" runat="server" >
                                </f:TextBox>
                                <f:NumberBox ID="nbxAmount" Width="250px" Label="数量" NoDecimal="false" DecimalPrecision="2" MinValue="0" Required="true" runat="server" >
                                </f:NumberBox>
                                <f:NumberBox ID="nbxLeadTimeOffset" Width="250px" Label="提前期偏置" NoDecimal="true" runat="server" >
                                </f:NumberBox>               
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:DropDownList ID="ddlBackFlush" Label="是否倒冲" Width="250px" runat="server">
                                    <f:ListItem Text="是" Value="Y"/>
                                    <f:ListItem Text="否" Value="N" Selected="true"/>
                                </f:DropDownList>
                                <f:HiddenField ID="hdfPropertyNO" runat="server"></f:HiddenField>
                            </Items>
                        </f:FormRow>           
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
