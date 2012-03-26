<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePayments.aspx.cs" Inherits="Shady_Pines.ManagePayments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<!-- LOADS THE EXTERNAL CSS PAGE(s)-->
    <link rel="stylesheet" type="text/css" href="Styles/Main1.css" /> 
    <link rel="stylesheet" type="text/css" href="Styles/Registration.css" />
    <title>Manage Payments</title>
</head>
<body background="Images/grass_diff.jpg" style="width: 100%; height: 100%">
    <form id="form1" runat="server">

    <div>
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <asp:Image ID="imgLogo" runat="server" 
            ImageUrl="~//Images/Logo.png" />
    </asp:Panel>
    </div>

    <div id="dLinks"> <!-- USED FOR THE LINKS NAVIGATION -->
        <a id="Link0" href="Default.aspx" runat="server">Home</a> <br />
        <a id="Link1" href="EmployeeManagement.aspx" runat="server">Employee Management</a> <br />
        <a id="Link2" href="Registration.aspx" runat="server">Registration</a> <br />
        <a id="Link3" href="Reservation.aspx" runat="server">Reservation</a> <br />
    </div>
    
   
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="getAllMembers" 
        TypeName="Shady_Pines.Member">
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        ConflictDetection="CompareAllValues" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetMemberByID" 
        TypeName="Shady_Pines.Member">
        <SelectParameters>
            <asp:ControlParameter ControlID="MemberList" Name="MemberID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div>
    <asp:DropDownList ID="MemberList" runat="server" 
        DataSourceID="ObjectDataSource1" DataTextField="_MemberLName" 
        DataValueField="_MemberID" AutoPostBack="True">
    </asp:DropDownList>
    </div>
    <div id="Payments">
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" 
        AutoGenerateRows="False" DataSourceID="ObjectDataSource2" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <Fields>
            <asp:BoundField DataField="_MemberID" HeaderText="_MemberID" 
                SortExpression="_MemberID" />
            <asp:BoundField DataField="_MemberStatusID" HeaderText="_MemberStatusID" 
                SortExpression="_MemberStatusID" />
            <asp:BoundField DataField="_MembershipCategoryID" 
                HeaderText="_MembershipCategoryID" SortExpression="_MembershipCategoryID" />
            <asp:BoundField DataField="_MembershipID" HeaderText="_MembershipID" 
                SortExpression="_MembershipID" />
            <asp:BoundField DataField="_MemberFName" HeaderText="_MemberFName" 
                SortExpression="_MemberFName" />
            <asp:BoundField DataField="_MemberLName" HeaderText="_MemberLName" 
                SortExpression="_MemberLName" />
            <asp:BoundField DataField="_MemberAddress" HeaderText="_MemberAddress" 
                SortExpression="_MemberAddress" />
            <asp:BoundField DataField="_MemberCity" HeaderText="_MemberCity" 
                SortExpression="_MemberCity" />
            <asp:BoundField DataField="_MemberCountry" HeaderText="_MemberCountry" 
                SortExpression="_MemberCountry" />
            <asp:BoundField DataField="_MemberState" HeaderText="_MemberState" 
                SortExpression="_MemberState" />
            <asp:BoundField DataField="_MemberZip" HeaderText="_MemberZip" 
                SortExpression="_MemberZip" />
            <asp:BoundField DataField="_MemberPhone" HeaderText="_MemberPhone" 
                SortExpression="_MemberPhone" />
            <asp:BoundField DataField="_MemberDateStarted" HeaderText="_MemberDateStarted" 
                SortExpression="_MemberDateStarted" />
        </Fields>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
    </asp:DetailsView>
    </div>

    </form>
</body>
</html>
