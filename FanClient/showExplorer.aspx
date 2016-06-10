<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showExplorer.aspx.cs" Inherits="showExplorer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show Tracker App</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
<h1>Show Tracker Application</h1>
    <form id="form1" runat="server">
        <div id="logIn">
            <h2>Fans login</h2>
        <table>
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="userTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="userFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="userTextBox" ValidationGroup="validLogin" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="passTextBox" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="passFieldValidator" runat="server" ErrorMessage="*" ControlToValidate="passTextBox" ValidationGroup="validLogin"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="loginButton" runat="server" Text="Login" OnClick ="loginButton_Click" ValidationGroup="validLogin" causesvalidation="true"/>
                </td>
                <td>
                    <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
            <asp:LinkButton ID="RegisterLink" runat="server" PostBackUrl="Register.aspx">Register</asp:LinkButton>


        </div>
        <div id="select_artist">
            <h2>Artists and Shows</h2>
            <p>In order to see all the artists, click on the drop down menu. By selecting an artist and clicking on the "Shows per Artist" Button, you can see all the shows that feature the artist you selected. </p>
            <asp:DropDownList ID="ArtistDropDownList" runat="server" ></asp:DropDownList>
            <asp:Button ID="ShowsbyArtist" runat="server" Text="Shows per Artist" OnClick="ShowsbyArtistButton_Click" />
        </div>
        <div id="select_venue">
            <h2>Venues and Shows</h2>
            <p>Curious about which shows play at which venue? <br />Select a venue from the drop down list, and click on the "Shows per Venue" button to see the shows played there.</p>
            <asp:DropDownList ID="VenueDropDownList" runat="server"></asp:DropDownList>
            <asp:Button ID="ShowsbyVenue" runat="server" Text="Shows per Venue" OnClick="ShowsbyVenueButton_Click" />
        </div>
        <div id="select_date">
            <h2>Shows By Date</h2>
            <p>Click on a date to see any shows available on that day.</p>
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
        </div>
        <!--<div id="select_shows">
            <h2>Shows only</h2>
            <p>Interested in shows only? <br /> If you are looking for overview of all the shows currently available, see the drop down menu below.</p>
            <asp:DropDownList ID="ShowDropDownList" runat="server"></asp:DropDownList>
        </div>-->
        
        <asp:GridView ID="ShowGridView" runat="server"></asp:GridView>
        <asp:Label ID="noshows" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
