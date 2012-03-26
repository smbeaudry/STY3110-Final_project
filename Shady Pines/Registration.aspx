<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Shady_Pines.Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <!-- LOADS THE EXTERNAL CSS PAGE(s)-->
    <link rel="stylesheet" type="text/css" href="Styles/Main1.css" /> 
    <link rel="stylesheet" type="text/css" href="Styles/Registration.css" />
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

    <!-- Labels -->
    <asp:Label ID="lblNewMember" runat="server" Text="New Member Entry Form"></asp:Label>
    <asp:Label ID="lblMemberID" runat="server" Text="Member ID"></asp:Label>
    <asp:Label ID="lblMemberFName" runat="server" Text="First Name"></asp:Label>
    <asp:Label ID="lblMemberLName" runat="server" Text="Last Name"></asp:Label>
    <asp:Label ID="lblMemberCity" runat="server" Text="City"></asp:Label>
    <asp:Label ID="lblMemberCountry" runat="server" Text="Country"></asp:Label>
    <asp:Label ID="lblMemberState" runat="server" Text="Province/State"></asp:Label>
    <asp:Label ID="lblMemberAddress" runat="server" Text="Home Address"></asp:Label>
    <asp:Label ID="lblMemberZip" runat="server" Text="Postal Code/Zip"></asp:Label>
    <asp:Label ID="lblMemberPhone" runat="server" Text="Phone"></asp:Label>
    <asp:Label ID="lblError" runat="server" Text="Shits fucked"></asp:Label> <!-- Used for sending error messages to user -->
    <asp:Label ID="lblMemberType" runat="server" Text="Membership Type"></asp:Label>
    <asp:Label ID="lblMemberPackage" runat="server" Text="Package"></asp:Label>
    <asp:Label ID="lblMemberPayment" runat="server" Text="Payment Status"></asp:Label>

    <!-- Textboxes -->
    <asp:TextBox ID="txtMemberID" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberFName" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberLName" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberCity" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberCountry" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberState" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberAddress" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberZip" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtMemberPhone" runat="server"></asp:TextBox>

    <!-- Drop Down Lists -->
    <asp:DropDownList ID="ddlMemberType" runat="server" AutoPostBack="True" 
        DataSourceID="sqlMembershipType" DataTextField="Description" 
        DataValueField="MembershipID" >
    </asp:DropDownList>

    <asp:DropDownList ID="ddlMemberPackage" runat="server" AutoPostBack="True" 
        DataSourceID="sqlMembershipCategory" DataTextField="Membership Type" 
        DataValueField="MembershipCategoryID" >
    </asp:DropDownList>
    
    <asp:DropDownList ID="ddlMemberPayment" runat="server" AutoPostBack="True" 
        DataSourceID="sqlMemberPayment" DataTextField="Payment Status" 
        DataValueField="MemberStatusID">
    </asp:DropDownList>


    <!-- Buttons -->
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="createNewMember"/>

    <!-- Object/SQL Data Source(s)-->
    <asp:ObjectDataSource ID="odsMembers" runat="server" 
        DataObjectTypeName="Shady_Pines.Member" InsertMethod="InsertMember" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="getAllMembers" 
        TypeName="Shady_Pines.Member">
    </asp:ObjectDataSource>

    <asp:SqlDataSource ID="sqlMembershipType" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShadyPinesDBSql %>" 
        SelectCommand="GetMembershipInformation" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlMembershipCategory" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShadyPinesDBSql %>" 
        SelectCommand="GetMembershipPackage" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sqlMemberPayment" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ShadyPinesDBSql %>" 
        SelectCommand="GetMemberStatusCodes" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>


    </form>
    
</body>
</html>
