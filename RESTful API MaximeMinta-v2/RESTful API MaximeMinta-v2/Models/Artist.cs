using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RESTful_API_MaximeMinta_v2
{
    public class Artist
    {
        public int ArtistID { get; set; } //primaire sleutel
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Track> Tracks { get; set; } = new Collection<Track>();

        [JsonIgnore]
        public IList<TrackArtist> TrackArtists { get; set; } = new List<TrackArtist>();
    }
}
