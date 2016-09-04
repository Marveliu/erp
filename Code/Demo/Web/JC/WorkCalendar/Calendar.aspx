<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Demo.Web.JC.WorkCalendar.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .calendarWork a {
            text-decoration:none;
        }
    </style>
</head>
<body style="border:none;margin:0px;">
    <form id="form_02" runat="server">
        <asp:ScriptManager ID="scriptManager_01" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Calendar ID="calendarWork" Width="100%" Enabled="false" Height="250px" runat="server"
                     Font-Names="微软雅黑" TodayDayStyle-BorderWidth="1px" TodayDayStyle-ForeColor="Red" TodayDayStyle-Font-Bold="true"
                     DayHeaderStyle-BackColor="#70E1FF" TitleStyle-BackColor="#ffffff" OnDayRender="calendarWork_DayRender"
                     BackColor="#ffffff" CssClass="calendarWork" OnVisibleMonthChanged="calendarWork_VisibleMonthChanged"></asp:Calendar>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
