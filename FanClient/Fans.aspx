<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fans.aspx.cs" Inherits="Fans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fan Page</title>
    <link href="https://fonts.googleapis.com/css?family=Work+Sans:100,400" rel="stylesheet" type="text/css">
    <link type="text/css" href ="styles.css" rel="stylesheet"/>

</head>
<body>
    <form id="form" runat="server">
    <div>
        <h1>Welcome to your Fan Page!</h1>
        <a href="showExplorer.aspx">Back to Main Page</a>
        <table class="fanpage">
            <tr>
                <td>
                    <asp:GridView ID="FanArtistGridView" OnRowDataBound="FanArtist_RowDataBound" runat="server"></asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="FanShowGridView"  OnRowDataBound="FanShowGridView_RowDataBound" runat="server"></asp:GridView>
                </td>
            </tr>
        </table>

        <div class="inner">
            <h2>Select Artists To Follow!</h2>
            <asp:CheckBoxList ID="ArtistCheckBoxList" RepeatColumns="4" runat="server"></asp:CheckBoxList>
            <asp:Button ID="FollowArtist" runat="server" Text="Follow Artist" OnClick="FollowArtist_Click" />
            <asp:Label ID="artistAdded" runat="server" Text=""></asp:Label>


        
<!--            <h2>You are currently following these artists:</h2>
            <asp:RadioButtonList ID="followArtistRadioButtonList" runat="server"></asp:RadioButtonList>
            
        
            <h2>Select the artist you would like to see all the shows for</h2>
            <asp:Button ID="ShowsbyArtist" runat="server" Text="Shows per Artist" OnClick="ShowsbyArtistButton_Click" />
            <asp:GridView ID="ShowGridView" runat="server"></asp:GridView>
            <asp:Label ID="nodata" runat="server" Text=""></asp:Label>    -->
        </div>
    </div>
    </form>
</body>
</html>