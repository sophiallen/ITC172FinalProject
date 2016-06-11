using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    ShowTrackerEntities db = new ShowTrackerEntities();
    public List<ArtistNames> GetArtistNames()
    {
        var artNames = from a in db.Artists
                       orderby a.ArtistName
                       select new { a.ArtistName, a.ArtistKey };

        List<ArtistNames> artistNames = new List<ArtistNames>();
        foreach (var an in artNames)
        {
            ArtistNames namesA = new ArtistNames();
            namesA.ArtistName = an.ArtistName;
            namesA.ArtistKey = an.ArtistKey;
            artistNames.Add(namesA);
        }
        return artistNames;
    }


    //added a method so the fans can see all the shows on a particular date
    public List<MyShowDate> GetShowsByDate(DateTime date)
    {
        var shows = from s in db.Shows
                    where s.ShowDate.Equals(date.Date)
                    orderby s.ShowTime
                    select new MyShowDate() { ShowTime = s.ShowTime, ShowName = s.ShowName, ShowTicketInfo = s.ShowTicketInfo };

        return shows.ToList();
    }


    public List<string> GetShowNames()
    {
        var shows = from sh in db.Shows
                    orderby sh.ShowName
                    select new { sh.ShowName };
        List<string> showNames = new List<string>();
        foreach (var s in shows)
        {
            showNames.Add(s.ShowName);
        }
        return showNames;
    }

    public List<string> GetVenueNames()
    {
        var venues = from v in db.Venues
                     orderby v.VenueName
                     select new { v.VenueName };

        List<string> VenueNames = new List<string>();
        foreach (var ven in venues)
        {
            VenueNames.Add(ven.VenueName);
        }
        return VenueNames;
    }

    public List<ShowsPerVenue> GetVenueShows(string venue)
    {
        var spv = from v in db.Venues
                  from s in v.Shows
                  where s.Venue.VenueName.Equals(venue)
                  select new { s.ShowName, s.ShowDate, s.ShowTime };

        List<ShowsPerVenue> VenueShows = new List<ShowsPerVenue>();

        foreach (var show in spv)
        {
            ShowsPerVenue venueshows = new ShowsPerVenue();
            venueshows.VenueShowName = show.ShowName;
            venueshows.VenueShowDate = show.ShowDate.ToShortDateString();
            venueshows.VenueShowTime = show.ShowTime.ToString();


            VenueShows.Add(venueshows);
        }
        return VenueShows;
    }


    public List<ShowsPerArtist> GetArtistShows(string artist)
    {

        var spa = from s in db.Shows
                  from sd in s.ShowDetails
                  where sd.Artist.ArtistName.Equals(artist)
                  select new {sd.Artist.ArtistName, s.Venue.VenueName, s.ShowName, s.ShowDate, s.ShowTime };

        List<ShowsPerArtist> artistShows = new List<ShowsPerArtist>();

        foreach (var shows in spa)
        {
            ShowsPerArtist sPERa = new ShowsPerArtist();
            sPERa.ArtistShowName = shows.ShowName;
            sPERa.ArtistShowTime = shows.ShowTime.ToString();
            sPERa.ArtistShowDate = shows.ShowDate.ToShortDateString();
            sPERa.ArtistVenueName = shows.VenueName;
            sPERa.ArtistName = shows.ArtistName;

            artistShows.Add(sPERa);

        }
        return artistShows;

    }
    public int FanLogin(string userName, string password)
    {
        //temp key value
        int FanKey = 0;
        int result = db.usp_FanLogin(userName, password);
        if (result != -1)
        {
            var key = (from f in db.FanLogins
                       where f.FanLoginUserName.Equals(userName) /*f.FanEmail.Equals(userName)*/
                       select new { f.FanLoginKey }).FirstOrDefault();
            FanKey = key.FanLoginKey;
        }
        return FanKey;
    }

    public bool RegisterFan(string fanName, string fanEmail, string fanPassword)
    {
        //default result = true
        bool result = true;

        int SuccessVal = db.usp_RegisterFan(fanName, fanEmail, fanEmail, fanPassword);
        if (SuccessVal == -1)
        {
            result = false;
        }
        return result;
    }

    public bool AddFanArtist(int fanKey, string artistName)
    {
        bool result = true;
        Fan currentFan = (from f in db.Fans
                          where f.FanKey.Equals(fanKey)
                          select f).First();

        Artist followArtist = (from a in db.Artists
                               where a.ArtistName.Equals(artistName)
                               select a).First();

        currentFan.Artists.Add(followArtist);
        db.SaveChanges();
        return result;
    }


    public List<ShowsPerArtist> GetFanShows(int fanKey)
    {
        List<string> fanArtists = GetFanArtists(fanKey);
        List<ShowsPerArtist> showList = new List<ShowsPerArtist>();
        foreach (var ar in fanArtists)
        {
            List<ShowsPerArtist> artistshows = GetArtistShows(ar);
            foreach (var s in artistshows)
            {
                showList.Add(s);
            }
        }

        return showList;
    }

    //List<string> IFanService.GetFanArtists(int fanKey)
    public List<string> GetFanArtists(int fanKey)
    {
        var fanartists = (from f in db.Fans
                          from a in f.Artists
                          where f.FanKey.Equals(fanKey)
                          select new { a.ArtistName });
        List<string> artistList = new List<string>();
        foreach (var ar in fanartists)
        {
            artistList.Add(ar.ArtistName);
        }
        return artistList;
    }
}
