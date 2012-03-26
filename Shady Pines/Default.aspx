<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shady_Pines._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Shady Pines</title>
    <link rel="stylesheet" type="text/css" href="Styles/Main1.css" /> <!-- LOADS THE EXTERNAL CSS PAGE-->
</head>

    <body background="Images/grass_diff.jpg" style="width: 100%; height: 100%"> <!-- LOADS THE BACKGROUND -->
    <form id="form1" runat="server">
    
    <div id="dTitle">
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Image ID="imgLogo" runat="server" ImageUrl="~//Images/Logo.png" /> <!-- LOADS OUR IMAGE FOR SHADY PINES -->
    </asp:Panel>
    </div>

    <div id="dLinks"> <!-- USED FOR THE LINKS NAVIGATION -->
        <a id="Link0" href="Default.aspx" runat="server">Home</a> <br />
        <a id="Link1" href="EmployeeManagement.aspx" runat="server">Employee Management</a> <br />
        <a id="Link2" href="Registration.aspx" runat="server">Registration</a> <br />
        <a id="Link3" href="Reservation.aspx" runat="server">Reservation</a> <br />
    </div>

    <div id="dCal"> <!-- CALENDAR -->
        <asp:Calendar ID="Cal" runat="server" BackColor="#FFFFCC" 
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
    </div>

            
    
    </form>
</body>
</html>
