using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API_MaximeMinta_v2
{
    public class Artist
    {
        public int ArtistID { get; set; } //primaire sleutel
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }

        public IList<TrackArtist> TrackArtists { get; set; } = new List<TrackArtist>();
    }
}
