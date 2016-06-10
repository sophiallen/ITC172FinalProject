using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showExplorer : System.Web.UI.Page
{
    FanServices.ServiceClient showtracker = new FanServices.ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_Artist_Dropdown();
            Fill_Venue_Dropdown();
            Fill_Show_Dropdown();
        }
        noshows.Text = "";
    }
    protected void Fill_Artist_Dropdown()
    {
        FanServices.ArtistNames[] artists = showtracker.GetArtistNames();
        ArtistDropDownList.DataSource = artists;
        ArtistDropDownList.DataValueField = "ArtistKey";
        ArtistDropDownList.DataTextField = "ArtistName";
        ArtistDropDownList.DataBind();
    }

    protected void Fill_Venue_Dropdown()
    {
        string[] venues = showtracker.GetVenueNames();
        VenueDropDownList.DataSource = venues;
        VenueDropDownList.DataBind();
    }
    protected void Fill_Show_Dropdown()
    {
        string[] shows = showtracker.GetShowNames();
        ShowDropDownList.DataSource = shows;
        ShowDropDownList.DataBind();
    }
    protected void ShowsbyArtistButton_Click(object sender, EventArgs e)
    {
        string artist = ArtistDropDownList.SelectedItem.Text;
        FanServices.ShowsPerArtist[] spa = showtracker.GetArtistShows(artist);
        ShowGridView.DataSource = spa;
        ShowGridView.DataBind();
    }
    protected void ShowsbyVenueButton_Click(object sender, EventArgs e)
    {

        string venue = VenueDropDownList.SelectedItem.Text;
        FanServices.ShowsPerVenue[] spv = showtracker.GetVenueShows(venue);
        if (spv.Length == 0)
        {
            noshows.Text = "There are no shows for this venue";
        }
        ShowGridView.DataSource = spv;
        ShowGridView.DataBind();
    }
    protected void loginButton_Click(object sender, EventArgs e)
    {
        FanLogin();
    }

    protected void FanLogin()
    {
        int key = showtracker.FanLogin(userTextBox.Text, passTextBox.Text);
        if (key != 0)
        {
            //errorLabel.Text = "Welcome!";
            Session["Userkey"] = key;
            Response.Redirect("Fans.aspx");

        }
        else
        {
            errorLabel.Text = "Invalid Login";
        }
    }



    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime selectedDate = Calendar1.SelectedDate;
        FanServices.MyShowDate[] shows = showtracker.GetShowsByDate(selectedDate);
        ShowGridView.DataSource = shows;
        ShowGridView.DataBind();        
        if (shows.Length <= 0)
        {
            noshows.Text = "No shows available on that date.";
        }
       
    }
}