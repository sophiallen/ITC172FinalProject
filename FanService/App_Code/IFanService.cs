using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFanService" in both code and config file together.
[ServiceContract]
public interface IFanService
{
    [OperationContract]
    List<string> GetVenueNames();

    [OperationContract]
    List<ArtistNames> GetArtistNames();

    [OperationContract]
    List<string> GetShowNames();

    [OperationContract]
    List<ShowsPerVenue> GetVenueShows(int venueKey);

    [OperationContract]
    List<ShowsPerArtist> GetArtistShows(string artist);

    [OperationContract]
    bool RegisterFan(string fanName, string fanEmail, string fanPassword);

    [OperationContract]
    int FanLogin(string userName, string password);

    [OperationContract]
    bool AddFanArtist(int fanKey, string artistName);

    [OperationContract]
    List<string> GetFanArtists(int fanKey);

    [OperationContract]
    List<ShowsPerArtist> GetFanShows(int fanKey);

}

[DataContract]

public class ShowsPerVenue
{
    [DataMember]
    public string VenueShowName { set; get; }

    [DataMember]
    public string VenueShowDate { set; get; }

    [DataMember]
    public string VenueShowTime { set; get; }

    [DataMember]
    public int VenueShowKey { set; get; }
}

[DataContract]
public class ShowsPerArtist
{
    [DataMember]
    public string ArtistShowName { set; get; }

    [DataMember]
    public string ArtistShowDate { set; get; }

    [DataMember]
    public string ArtistShowTime { set; get; }

    [DataMember]
    public string ArtistVenueName { set; get; }
}

public class ArtistNames
{

    [DataMember]
    public string ArtistName { set; get; }

    [DataMember]
    public int ArtistKey { set; get; }


}


