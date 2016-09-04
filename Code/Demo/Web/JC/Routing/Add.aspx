<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Demo.Web.JC.Routing.Add" %>

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
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" Icon="SystemClose" runat="server" >
                        </f:Button>
                        <f:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" ValidateForms="infoForm" Icon="SystemSave">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Form ID="infoForm" LabelAlign="Left" ShowHeader="false" EnableCollapse="false" Expanded="true" 
                    LabelWidth="100px" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txbRoutingNO" Width="300px" Label="工艺路线编号" Required="true" runat="server" ></f:TextBox>
                                <f:TextBox ID="txbRoutingName" Width="300px" Label="工艺路线名称" Required="true" runat="server" ></f:TextBox>        
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:NumberBox ID="nbxProcedureAmount" Width="300px" Label="工序数量" NoDecimal="true" NoNegative="true" 
                                    Required="true" runat="server"></f:NumberBox>     
                            </Items>
                        </f:FormRow>       
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>        
    </form>
</body>
</html>
