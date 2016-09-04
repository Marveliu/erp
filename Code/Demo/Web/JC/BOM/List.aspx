<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Demo.Web.JC.BOM.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOM</title>
</head>
<body>
    <form id="form_01" runat="server">
        <f:PageManager ID="pageManager_01" AutoSizePanelID="panelMain" runat="server" />  
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="HBox">                 
            <Items>
                <f:Panel ID="panelLeft"  BoxFlex="1" runat="server" ShowBorder="true" ShowHeader="false" Layout="Fit">                  
                    <Items>
                        <f:Tree ID="treeBOM" Title="BOM单" ShowBorder="false" ShowHeader="false" EnableSingleClickExpand="true" 
                                EnableCollapse="true" runat="server" AutoScroll="True" EnableMultiSelect="false">
                        </f:Tree>
                    </Items>
                </f:Panel>
                <f:Panel ID="panelRight" BoxFlex="3" runat="server" ShowBorder="false" ShowHeader="false" Layout="VBox">
                    <Items>
                        <f:Panel ID="panelRightTop" BoxFlex="1" ShowHeader="false" ShowBorder="false" Layout="Fit" runat="server">
                            <Items>
                                <f:Grid ID="gridBOMParent" Title="BOM父物料" ShowBorder="false" AllowPaging="true" ShowHeader="true" IsDatabasePaging="true"
                                    DataKeyNames="ID" AllowSorting="true" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="6" 
                                    EnableMultiSelect="false" EnableRowSelectEvent="true" OnRowSelect="gridBOMParent_RowSelect" OnPageIndexChange="grid_PageIndexChange"
                                    OnSort="grid_Sort" runat="server">
                                    <Toolbars>
                                        <f:Toolbar ID="toolbar_01" runat="server">
                                            <Items>
                                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server">
                                                </f:Button>
                                                <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" OnClick="btnDelete_Click" runat="server">
                                                </f:Button>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>

                                    <Columns>
                                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="Modify.aspx?id={0}"
                                            DataWindowTitleField="MaterialName" DataWindowTitleFormatString="编辑 - {0}" />
                                        <f:BoundField Width="120px" ColumnID="MaterialNO" SortField="MaterialNO" DataField="MaterialNO"
                                            TextAlign="Center" HeaderText="物料编号"></f:BoundField>
                                        <f:BoundField Width="120px" ColumnID="MaterialName" SortField="MaterialName" DataField="MaterialName"
                                            TextAlign="Center" HeaderText="物料名称"></f:BoundField>
                                        <f:BoundField Width="120px" ColumnID="Specification" SortField="Specification" DataField="Specification"
                                            TextAlign="Center" HeaderText="规格"></f:BoundField>
                                        <f:BoundField Width="120px" ColumnID="Model" SortField="Model" DataField="Model"
                                            TextAlign="Center" HeaderText="型号"></f:BoundField>
                                        <f:BoundField Width="120px" ColumnID="Unit" SortField="Unit" DataField="Unit"
                                            TextAlign="Center" HeaderText="单位"></f:BoundField>
                                        <f:BoundField Width="120px" ColumnID="PropertyName" SortField="PropertyName" DataField="PropertyName"
                                            TextAlign="Center" HeaderText="属性"></f:BoundField>
                                        <f:BoundField Width="120px" ColumnID="CheckName" SortField="CheckName" DataField="CheckName"
                                            TextAlign="Center" HeaderText="审核人姓名"></f:BoundField>
                                        <f:TemplateField Width="120px" HeaderText="审核状态" runat="server">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCheckStatus" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("CHECK",Eval("CheckStatus").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </f:TemplateField>
                                        <f:BoundField Width="120px" ColumnID="CheckDate" SortField="CheckDate" DataField="CheckDate"
                                            TextAlign="Center" HeaderText="审核时间"></f:BoundField>
                                        <f:TemplateField Width="120px" HeaderText="单据状态" runat="server">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("USE",Eval("Status").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </f:TemplateField>
                                    </Columns>
                                </f:Grid>
                            </Items>
      `                 </f:Panel>
                        <f:Panel ID="panelRightBottom" BoxFlex="1" ShowHeader="false" ShowBorder="false" Layout="Fit" runat="server">          
                            <Items>
                                <f:Grid ID="gridBOMSub" Title="子物料" PageSize="6" ShowBorder="true" AutoScroll="true" AllowPaging="true"
                                        ShowHeader="true" runat="server" Icon="Table" IsDatabasePaging="true" DataKeyNames="ID" AllowSorting="true" 
                                        EnableCheckBoxSelect="true" EnableMultiSelect="false" OnPageIndexChange="grid_PageIndexChange" OnSort="grid_Sort">
                                    <Toolbars>
                                        <f:Toolbar ID="toolbar_02" runat="server">
                                            <Items>
                                                <f:Button ID="btnAddSub" Text="新增" OnClick="btnAddSub_Click" Icon="Add" runat="server">
                                                </f:Button>
                                                <f:Button ID="btnDeleteSub" Text="删除选中行" Icon="Delete" OnClick="btnDelete_Click" runat="server">
                                                </f:Button>
                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                    <Columns>
                                        <f:WindowField Width="60px" WindowID="windowPop" TextAlign="Center" HeaderText="编辑" Icon="ApplicationEdit"
                                            ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ID,ParentNO" DataIFrameUrlFormatString="../BOMSub/Modify.aspx?id={0}&parentNO={1}"
                                            DataWindowTitleField="MaterialName" DataWindowTitleFormatString="编辑 - {0}" />
                                        <f:BoundField Width="120px" SortField="MaterialNO" DataField="MaterialNO" TextAlign="Center"
                                            HeaderText="物料编号"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="MaterialName" DataField="MaterialName" TextAlign="Center"
                                            HeaderText="物料名称"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="ParentNO" DataField="ParentNO" TextAlign="Center"
                                            HeaderText="父项物料编号"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="ParentName" DataField="ParentName" TextAlign="Center" 
                                            HeaderText="父项物料名称"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="Specification" DataField="Specification" TextAlign="Center" 
                                            HeaderText="规格"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="Model" DataField="Model" TextAlign="Center" 
                                            HeaderText="型号"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="Amount" DataField="Amount" TextAlign="Center" 
                                            HeaderText="数量"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="Unit" DataField="Unit" TextAlign="Center" 
                                            HeaderText="单位"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="PropertyName" DataField="PropertyName" TextAlign="Center" 
                                            HeaderText="属性"></f:BoundField>
                                        <f:BoundField Width="120px" SortField="LeadTimeOffset" DataField="LeadTimeOffset" TextAlign="Center" 
                                            HeaderText="提前期偏置"></f:BoundField>
                                        <f:TemplateField Width="120px" HeaderText="是否倒冲" TextAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBackFlush" runat="server" Text='<%# Demo.Web.Code.PublicMethod.getKey("IF",Eval("BackFlush").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </f:TemplateField>
                                    </Columns>
                                </f:Grid>                      
                            </Items>
                        </f:Panel>
                    </Items>    
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Window ID="windowPop" Title="编辑"  EnableCollapse="false" Hidden="true" EnableIFrame="true" IFrameUrl="about:blank" CloseAction="HidePostBack" EnableMaximize="false"
            EnableResize="false" EnableClose="false" OnClose="wd_Close" Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>
