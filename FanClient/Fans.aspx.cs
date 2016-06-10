using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fans : System.Web.UI.Page
{
    FanServices.ServiceClient showtracker = new FanServices.ServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        var userKey = Session["Userkey"];
        if (userKey == null)
        {
            Response.Redirect("showExplorer.aspx");
        }
        if (!IsPostBack)
        {
            Fill_Following_Artists();
            Fill_Fan_Shows();
            Fill_Artist_Checkboxes();
        }
    }

    protected void Fill_Artist_Checkboxes()
    {
        FanServices.ArtistNames[] artistlist = showtracker.GetArtistNames();
        ArtistCheckBoxList.DataSource = artistlist;
        ArtistCheckBoxList.DataTextField = "ArtistName";
        ArtistCheckBoxList.DataBind();
    }

    protected void Fill_Fan_Shows()
    {
        int fanKey = Convert.ToInt32(Session["Userkey"]);
        FanServices.ShowsPerArtist[] fanshows = showtracker.GetFanShows(fanKey);
        FanShowGridView.DataSource = fanshows;
        FanShowGridView.DataBind();
    }


    protected void Fill_Following_Artists()
    {
        int fanKey = Convert.ToInt32(Session["Userkey"]);
        string[] myArtists = showtracker.GetFanArtists(fanKey);
        FanArtistGridView.DataSource = myArtists;
        FanArtistGridView.DataBind();

    }
    protected void FollowArtist_Click(object sender, EventArgs e)
    {
        FollowThisArtist();
        Fill_Following_Artists();
        Fill_Fan_Shows();
    }

    protected void FollowThisArtist()
    {
        int fanKey = Convert.ToInt32(Session["Userkey"]);
        bool result = false;

        for (int i = 0; i < ArtistCheckBoxList.Items.Count; i++)
        {
            if (ArtistCheckBoxList.Items[i].Selected)
            {
                string artistName = ArtistCheckBoxList.Items[i].Text;
                result = showtracker.AddFanArtist(fanKey, artistName);
            }
        }


/*        string artistName = ArtistDropDownList.SelectedItem.Text;

        bool result = showtracker.AddFanArtist(fanKey, artistName); */

        if (result)
        {
            artistAdded.Text = "Artists successfully added!";
        }
        else
        {
            artistAdded.Text = "An Error occurred. :(";
        }

    }

    protected void ShowsbyArtistButton_Click(object sender, EventArgs e)
    {
        string artist = followArtistRadioButtonList.SelectedItem.Text;
        FanServices.ShowsPerArtist[] spa = showtracker.GetArtistShows(artist);
        if (spa.Length == 0)
        {
            nodata.Text = "There are no shows for this artist";

        }
        ShowGridView.DataSource = spa;
        ShowGridView.DataBind();
    }


    protected void FanArtist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "Artists You Follow";
        }
    }


    protected void FanShowGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "Your Artists' Shows";
        }
    }
}