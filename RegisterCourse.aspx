<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Course_Registration_App.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="App_Themes/SiteStyles1.css" rel="stylesheet"/>
</head>
<body>
    <h1>Course Registration</h1>
    <form id="form1" runat="server">
        <div>Student:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropdownList ID="drpStudent" class="input" runat="server"  Width="230.5px" AutoPostBack="true" OnSelectedIndexChanged = "drpSelect">
                <asp:ListItem Value ="-1" Text="Select ..."></asp:ListItem>    
            </asp:DropdownList>
        &nbsp;&nbsp;
            <asp:RangeValidator ID="drpStudentValidator" runat="server" ControlToValidate="drpStudent" 
             ErrorMessage="Must select one!"
             MaximumValue="9999" MinimumValue="0" Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
        </div>
        <p>
            <asp:Label ID="lblCourseHoursRegistered" runat="server" class="distinct" Visible="true"></asp:Label>
        </p>
        <asp:Panel runat="server" ID="pnlSelection">
            <p>Following Courses are currently available for registration</p>
            <p>
                <asp:Label ID="lblErrorMsg" runat="server" class="error" Visible="false"></asp:Label>
            </p>
            <asp:CheckBoxList ID="chklst" runat="server" OnSelectedIndexChanged="chklst_SelectedIndexChanged" >
            </asp:CheckBoxList>
            <br />
            <asp:Button ID="cmdSumbit" class="button" Text="Save" runat="server" OnClick="cmdSubmit_Click" />
            <br /><br />
            <a href="AddStudent.aspx" >Add Students</a>
        </asp:Panel>
    </form>
</body>
</html>