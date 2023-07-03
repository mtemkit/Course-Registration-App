<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Course_Registration_App.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="App_Themes/SiteStyles2.css" rel="stylesheet"/>
</head>
<body>
    <h1>Student</h1>
    <form id="form1" runat="server">
        <div>Student Name:&nbsp;
            <asp:TextBox ID="txtStudentName" class="input" runat="server" Width="223px"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="txtStudentNameValidator" runat="server" 
                ControlToValidate="txtStudentName" ForeColor="Red" Display="Dynamic" ErrorMessage="Required!"></asp:RequiredFieldValidator>
            <div>
            </div>
            <br />
            <br />
        </div>
        <div>Student Type:&nbsp;&nbsp;
            <asp:DropdownList ID="drpStudent" class="input" runat="server"  Width="230.5px">
                <asp:ListItem Value ="-1" Text="Select ..."></asp:ListItem>    
                <asp:ListItem Value="0">Full Time</asp:ListItem>
                <asp:ListItem Value="1">Part Time</asp:ListItem>
                <asp:ListItem Value="2">Coop</asp:ListItem>
            </asp:DropdownList>
        &nbsp;&nbsp;
            <asp:RangeValidator ID="drpStudentValidator" runat="server" ControlToValidate="drpStudent" 
             ErrorMessage="Must select one!"
             MaximumValue="2" MinimumValue="0" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
        </div>
            <br />
            <br />
        <asp:Button ID="cmdOK" Text="Add" class="button" runat="server" OnClick="add_Click" />
        <asp:Panel runat="server" ID="pnlResult" Visible="false" >
        <br />
        <asp:Table ID="tblStudents" runat="server" CssClass="table"> 
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Type</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        </asp:Panel>
        <br />
        <br />
        <a href="RegisterCourse.aspx" >Register Courses</a>
    </form>
</body>
</html>

