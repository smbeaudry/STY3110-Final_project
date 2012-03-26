<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="Shady_Pines.EmployeeManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <link rel="stylesheet" type="text/css" href="Styles/Main1.css" /> <!-- LOADS THE EXTERNAL CSS PAGE-->
</head>
<body background="Images/grass_diff.jpg" style="width: 100%; height: 100%">
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
        <asp:Image ID="imgLogo" runat="server" 
            ImageUrl="~//Images/Logo.png" />
    </asp:Panel>
    </div>

    <!-- Grid View for members -->
    <div id="gvMembersAllDiv">
        <asp:GridView ID="gvMembers" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="odsMembers" 
            GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="_MemberID" HeaderText="MemberID" 
                    SortExpression="_MemberID" />
                <asp:BoundField DataField="_MemberStatusID" HeaderText="MemberStatusID" 
                    SortExpression="_MemberStatusID" />
                <asp:BoundField DataField="_MembershipCategoryID" 
                    HeaderText="MembershipCategoryID" SortExpression="_MembershipCategoryID" />
                <asp:BoundField DataField="_MembershipID" HeaderText="MembershipID" 
                    SortExpression="_MembershipID" />
                <asp:BoundField DataField="_MemberFName" HeaderText="First Name" 
                    SortExpression="_MemberFName" />
                <asp:BoundField DataField="_MemberLName" HeaderText="Last Name" 
                    SortExpression="_MemberLName" />
                <asp:BoundField DataField="_MemberAddress" HeaderText="Address" 
                    SortExpression="_MemberAddress" />
                <asp:BoundField DataField="_MemberCity" HeaderText="City" 
                    SortExpression="_MemberCity" />
                <asp:BoundField DataField="_MemberCountry" HeaderText="Country" 
                    SortExpression="_MemberCountry" />
                <asp:BoundField DataField="_MemberState" HeaderText="Province/State" 
                    SortExpression="_MemberState" />
                <asp:BoundField DataField="_MemberZip" HeaderText="Zip" 
                    SortExpression="_MemberZip" />
                <asp:BoundField DataField="_MemberPhone" HeaderText="Phone" 
                    SortExpression="_MemberPhone" />
                <asp:BoundField DataField="_MemberDateStarted" HeaderText="Date Registered" 
                    SortExpression="_MemberDateStarted" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </div>

    <!-- Object Data source-->
    <asp:ObjectDataSource ID="odsMembers" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="getAllMembers" 
        TypeName="Shady_Pines.Member"></asp:ObjectDataSource>


    </form>
</body>
</html>
