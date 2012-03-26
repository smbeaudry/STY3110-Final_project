<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shady_Pines._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body background="Images/grass_diff.jpg" style="width: 100%; height: 100%">
    <form id="form1" runat="server">
    <div>
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Image ID="imgLogo" runat="server" 
            ImageUrl="~//Images/Logo.png" />
    </asp:Panel>
    </div>

    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow runat="server" Width ="100%">
        <asp:TableCell Width="25%">
        <asp:Panel ID="Panel1" runat="server" BorderColor="#996600" BorderStyle="Groove" Wrap="True" Height="100%" BackColor="#996600">
        <asp:Label runat="server">Other Links <br />Other Links <br />Other Links <br />Other Links <br /></asp:Label>
    </asp:Panel>
        </asp:TableCell>
        <asp:TableCell Width="50%">
        <asp:Panel ID="Panel2" runat="server" Width="50%">
    </asp:Panel>
        </asp:TableCell>
        
        <asp:TableCell Width="25%">
            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" 
        BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
        ShowGridLines="True" Width="220px">
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
            ForeColor="#FFFFCC" />
    </asp:Calendar>
    
    </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>
