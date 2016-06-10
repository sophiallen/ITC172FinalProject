<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fan Register</title>
    <link type="text/css" href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="register">
            <h2>Fans Register</h2>
            <table>
                <tr>
                    <td>Your Name</td>
                    <td>
                        <asp:TextBox ID="userTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nameRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="userTextBox"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="emailTextBox"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server" ErrorMessage="Please provide a valid email" ControlToValidate="emailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="passTextBox" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="passRequiredFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="passTextBox"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Retype Password</td>
                    <td>
                        <asp:TextBox ID="repassTextBox" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="passCompareValidator" runat="server" ErrorMessage="Passwords do not match" ControlToCompare="passTextBox" ControlToValidate="repassTextBox"></asp:CompareValidator>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click"  />
                    </td>
                    <td>
                        <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
         </div>
    </form>
</body>
</html>
